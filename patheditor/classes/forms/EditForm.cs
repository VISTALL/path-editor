using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using com.jds.PathEditor.classes.client;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.lm;
using com.jds.PathEditor.classes.services;

namespace com.jds.PathEditor.classes.forms
{
    public partial class EditForm : Form
    {
        private readonly List<ListViewItem> _items = new List<ListViewItem>();
        private readonly DatParser _parser;

        #region Конструктор

        public EditForm(String title, DatParser d)
        {
            InitializeComponent();
            _parser = d;

            _listView.BackColor = ConvertUtilities.HtmlColorToColor(RConfig.Instance.EditorBackColor);
            _listView.ColumnWidthChanged += _listView_ColumnWidthChanged;
            _listView.RetrieveVirtualItem += _listView_RetrieveVirtualItem;
            _listView.ItemSelectionChanged += _listView_ItemSelectionChanged;
            _listView.ColumnClick += _listView_ColumnClick;

            _propertyGid.PropertyValueChanged += _propertyGid_PropertyValueChanged;
            searchColumn.SelectedIndexChanged += _searchColumn_SelectedIndexChanged;
            searchText.KeyUp += _seatchText_KeyUp;
            KeyUp += EditForm_KeyUp;

            Text = Localizate.getMessage(Word.EDITOR) + ": " + title;

            Definition info = d.getDefinition();

            PropertyInfo[] parray = info.GetType().GetProperties();

            foreach (PropertyInfo property in parray)
            {
                if (property.CanWrite)
                {
                    addHeader(property.Name);

                    searchColumn.Items.Add(property.Name);
                }
            }
        }

        #endregion

        #region Действия клавы

        private void EditForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
            {
                if (!searchBtn.Enabled)
                    return;
                searchBtn.PerformClick();
            }
        }

        #endregion

        #region Поиск

        private void _searchColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchBtn.Enabled = searchColumn.SelectedItem != null;
        }

        private void _seatchText_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchColumn.SelectedItem == null)
            {
                return;
            }

            searchBtn.Enabled = !searchText.Text.Trim().Equals("");
        }

        private void _seatchBtn_Click(object sender, EventArgs e)
        {
            if (searchColumn.SelectedItem == null || searchText.Text.Trim().Equals(""))
            {
                return;
            }

            var columnName = (String) searchColumn.SelectedItem;
            String search = searchText.Text.Trim();
            if (!_listView.Columns.ContainsKey(columnName))
            {
                return;
            }

            ColumnHeader col = _listView.Columns[columnName];
            int index = col.Index;

            foreach (ListViewItem item in _items)
            {
                if (_listView.SelectedIndices.Count != 0)
                {
                    if (item.Index < ((_listView.SelectedIndices[0] == -1 ? 0 : _listView.SelectedIndices[0]) + 1))
                    {
                        continue;
                    }
                }

                if (item.SubItems[index].Text.Contains(search))
                {
                    item.Selected = true;
                    _listView.TopItem = item;
                    _listView.FocusedItem = item;
                    break;
                }
            }
        }

        #endregion

        #region Слушатели ListView

        private void _listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
        }

        private void _listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var info = (Definition) e.Item.Tag;
            _removeBtn.Enabled = info != null;

            if (info != null)
            {
                _listView.Tag = info;

                _propertyGid.SelectedObject = info;
            }
        }

        private void _listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int index = e.ItemIndex;
            ListViewItem item = _items.ElementAt(index);
            e.Item = item;
        }


        private void _listView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            String columnName = _listView.Columns[e.ColumnIndex].Text;
            int size = _listView.Columns[e.ColumnIndex].Width;

            RConfig.Instance.setColumnSize(_parser.getDefinition(), columnName, size);
        }

        #endregion

        #region Заголовки + запись даных

        public void addHeader(String name)
        {
            int size = RConfig.Instance.getColumnSize(_parser.getDefinition(), name);

            var h = new ColumnHeader();
            h.Name = name;
            h.Text = name;
            h.Width = size;

            _listView.Columns.Add(h);
        }

        public void write(Definition value)
        {
            Definition info = value;

            var item = new ListViewItem();

            writeSubItems(item, value);

            _items.Add(item);
        }

        public void writeSubItems(ListViewItem item, Definition value)
        {
            Definition info = value;

            bool first = true;

            item.SubItems.Clear();

            item.Text = info.ToString();
            item.Tag = info;

            Color color = Color.White;

            foreach (PropertyInfo prop in info.GetType().GetProperties())
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                foreach (Attribute at in prop.GetCustomAttributes(true))
                {
                    if (at is ListColor)
                    {
                        var co = at as ListColor;
                        color = ConvertUtilities.HtmlColorToColor((String) prop.GetValue(value, null));
                    }
                }

                var sub = new ListViewItem.ListViewSubItem();
                sub.Text = prop.GetValue(value, null).ToString();
                item.SubItems.Add(sub);
            }

            item.ForeColor = color;
        }


        public void refresh()
        {
            _listView.VirtualListSize = _items.Count;
        }

        #endregion

        #region Гид настроек

        private void _propertyGid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            foreach (int index in _listView.SelectedIndices)
            {
                ListViewItem item = _items[index];

                var info = (Definition) item.Tag;
                if (info != null)
                {
                    writeSubItems(item, info);
                    _listView.RedrawItems(index, index, false);
                }
            }
        }

        #endregion

        #region Созранения/Добавления/Удаления евенты

        private void saveButton_Click(object sender, EventArgs e)
        {
            MainForm.Instance.DatDatas.Clear();

            foreach (ListViewItem item in _items)
            {
                MainForm.Instance.DatDatas.Add(item.Tag as Definition);
            }

            MainForm.Instance.StatusLabel.Text = Localizate.getMessage(Word.COMPLETE) +
                                                 String.Format(Localizate.getMessage(Word.IMPORTED_DATA),
                                                               MainForm.Instance.DatDatas.Count);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Definition d = _parser.getDefinition();

            var def = (Definition) d.GetType().InvokeMember(null, BindingFlags.CreateInstance, null, null, null);
            def.InitFieldValues();
            write(def);
            refresh();
            _listView.RedrawItems(0, _items.Count - 1, false);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            foreach (int index in _listView.SelectedIndices)
            {
                ListViewItem item = _items[index];

                var info = (Definition) item.Tag;

                _listView.SelectedIndices.Clear();
                _items.Remove(item);
                refresh();
                _listView.RedrawItems(0, _items.Count - 1, false);
            }
        }

        #endregion
    }
}
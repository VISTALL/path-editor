#region Using
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using com.jds.PathEditor.classes.client.mothers;
using com.jds.PathEditor.classes.services;
#endregion

namespace com.jds.PathEditor.classes.forms
{
    public partial class MergeForm : Form
    {
        private readonly List<Definition> _secondList = new List<Definition>();

        public MergeForm(DatParser dat)
        {
            InitializeComponent();
            foreach (String f in dat.getFieldNames())
            {
                _fieldNames.Items.Add(f);
                _updateFieldNames.Items.Add(f);
                _secondKeyList.Items.Add(f);
            }

            _fieldNames.SelectedIndex = 0;
            _updateFieldNames.SelectedIndex = 0;
            _secondKeyList.SelectedIndex = 0;
        }

        public void readSecond(String t)
        {
            MainForm.Instance.StatusLabel.Text = "";
            Encoding enc = Encoding.GetEncoding(RConfig.Instance.TextEncoding);
            StreamReader sr = new StreamReader(t, enc);

     
            MainForm.Instance.onStart((int)sr.BaseStream.Length);

            String line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("#"))
                    continue;

                String[] TmpStr = line.Split(new[] {'\t'});

                for (int i = 0; i < TmpStr.Length; i++)
                {
                    TmpStr[i] = TmpStr[i].Trim(new[] {'"'});
                }

                Definition item = MainForm.Instance.DatInfo.getDefinition();

                for (int i = 0, j = 0; i < MainForm.Instance.DatInfo.getFieldNames().Count; i++, j++)
                {
                    String FName = MainForm.Instance.DatInfo.getFieldNames()[i];
                    FieldInfo FType = MainForm.Instance.DatInfo.getDefinition().GetType().GetField(FName);

                    if (FType == null)
                    {
                        continue;
                    }

                    Type type = FType.FieldType;
                    Object obj = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

                    if (obj is IType)
                    {
                        var format = (IType) obj;

                        format.parse(TmpStr[j], TmpStr, j, out j);

                        FType.SetValue(item, format);
                    }
                    else
                    {
                        throw new NotImplementedException("Type " + obj.GetType().Name +
                                                          " is not implement IType");
                    }
                }

                _secondList.Add(item);

                MainForm.Instance.setValue((int)sr.BaseStream.Length);
            }

            sr.Close();

            MainForm.Instance.onEnd();

            _statusLabel.Text = Localizate.getMessage(Word.COMPLETE) + String.Format(Localizate.getMessage(Word.IMPORTED_DATA), _secondList.Count);
        }

        private void _updateButton_Click(object sender, EventArgs e)
        {
            if (_secondKey.Checked)
            {
                Dictionary<Object, Dictionary<Object, Definition>> ORI = new Dictionary<Object, Dictionary<Object, Definition>>(MainForm.Instance.DatDatas.Count);
                Dictionary<Object, Dictionary<Object, Definition>> UPDATE = new Dictionary<Object, Dictionary<Object, Definition>>(_secondList.Count);
           
                foreach (Definition def in MainForm.Instance.DatDatas)
                {
                    FieldInfo idField = def.GetType().GetField(_fieldNames.SelectedItem as String);
                    FieldInfo id2Field = def.GetType().GetField(_secondKeyList.SelectedItem as String);
                    
                    Object key = idField.GetValue(def);
                    Object key2 = id2Field.GetValue(def);

                    if (!ORI.ContainsKey(key))
                    {
                        ORI.Add(key, new Dictionary<Object, Definition>());
                    }

                    if (!ORI[key].ContainsKey(key2))
                        ORI[key].Add(key2, def);
                }

                foreach (Definition def in _secondList)
                {
                    FieldInfo idField = def.GetType().GetField(_fieldNames.SelectedItem as String);
                    FieldInfo id2Field = def.GetType().GetField(_secondKeyList.SelectedItem as String);

                    Object key = idField.GetValue(def);
                    Object key2 = id2Field.GetValue(def);

                    if (!UPDATE.ContainsKey(key))
                    {
                        UPDATE.Add(key, new Dictionary<Object, Definition>());
                    }

                    if (!UPDATE[key].ContainsKey(key2))
                        UPDATE[key].Add(key2, def);
                }

                MainForm.Instance.onStart(ORI.Count); 
                
                int i = 0;
                int updateCount = 0; 
                // листаем первые ключи
                // для примера скилы 
                // id
                foreach (Object key in ORI.Keys)
                {
                    // если этого скила нету в даных для с котрых синх, уходим
                    if(!UPDATE.ContainsKey(key))
                         continue;

                    Dictionary<Object, Definition> ori2 = ORI[key];
                    Dictionary<Object, Definition> update2 = UPDATE[key];

                    // листаем терь по уровнях
                    foreach (Object k in ori2.Keys)
                    {
                        if (update2.ContainsKey(k))
                        {
                            Definition oldDef = ori2[k];
                            Definition newDef = update2[k];

                            FieldInfo updateValue = oldDef.GetType().GetField(_updateFieldNames.SelectedItem as String);

                            updateValue.SetValue(oldDef, updateValue.GetValue(newDef));

                            updateCount++;
                        }
                       
                    }

                    MainForm.Instance.setValue(++i);
                }

                MainForm.Instance.onEnd();

                _statusLabel.Text = "Update count: " + updateCount;
            }
            else
            {
                Dictionary<Object, Definition> ori = new Dictionary<Object, Definition>(MainForm.Instance.DatDatas.Count);
                Dictionary<Object, Definition> update = new Dictionary<Object, Definition>(_secondList.Count);

                foreach (Definition def in MainForm.Instance.DatDatas)
                {
                    FieldInfo idField = def.GetType().GetField(_fieldNames.SelectedItem as String);
                    Object key = idField.GetValue(def);

                    if (!ori.ContainsKey(key))
                        ori.Add(key, def);
                }

                foreach (Definition def in _secondList)
                {
                    FieldInfo idField = def.GetType().GetField(_fieldNames.SelectedItem as String);
                    Object key = idField.GetValue(def);

                    if (!update.ContainsKey(key))
                        update.Add(key, def);
                }

                MainForm.Instance.onStart(ori.Count);

                int i = 0;
                int updateCount = 0;
                foreach (Object key in ori.Keys)
                {
                    if (update.ContainsKey(key))
                    {
                        Definition oldDef = ori[key];
                        Definition newDef = update[key];

                        FieldInfo updateValue = oldDef.GetType().GetField(_updateFieldNames.SelectedItem as String);

                        updateValue.SetValue(oldDef, updateValue.GetValue(newDef));

                        updateCount++;
                    }

                    MainForm.Instance.setValue(++i);
                }

                MainForm.Instance.onEnd();

                _statusLabel.Text = "Update count: " + updateCount;
            }
        }

        private void _secondKey_CheckedChanged(object sender, EventArgs e)
        {
            _secondKeyList.Enabled = _secondKey.Checked;
        }
    }
}
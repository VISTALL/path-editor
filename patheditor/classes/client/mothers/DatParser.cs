#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using com.jds.PathEditor.classes.forms;
using com.jds.PathEditor.classes.parser;
using log4net;

#endregion

namespace com.jds.PathEditor.classes.client.mothers
{
    public class DatParser
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof (DatParser));

        private readonly List<String> DatDefFields;

        public DatParser()
        {
            DatDefFields = new List<String>();
        }

        #region Definitions && Fields

        public List<String> getFieldNames()
        {
            if (DatDefFields.Count == 0)
            {
                MemberInfo[] members = getDefinition().GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                foreach (MemberInfo m in members)
                {
                    if (m.MemberType != MemberTypes.Field)
                        continue;
                    DatDefFields.Add(m.Name);
                }
            }
            return DatDefFields;
        }

        public virtual Definition getDefinition()
        {
            return new Definition();
        }

        #endregion

        #region Counts read && write

        public virtual int readCount(BinaryReader f)
        {
            return f.ReadInt32();
        }

        public virtual void writeCount(BinaryWriter f, int i)
        {
            f.Write(i);
        }

        #endregion

        #region Parse

        public List<Definition> Parse(BinaryReader f)
        {
            var res = new List<Definition>();

            int total_records = readCount(f);

            MainForm.Instance.onStart(total_records);

            _log.Info("Total count: " + total_records);

            for (int i = 0; i < total_records; i++)
            {
                res.Add(ParseMain(f, i));

                MainForm.Instance.setValue(i);
            }

            return res;
        }

        public virtual Definition ParseMain(BinaryReader f, int RecNo)
        {
            var info = new Definition();
            info = MainForm.Instance.DatInfo.getDefinition();
            List<String> TmpArr = MainForm.Instance.DatInfo.getFieldNames();
            for (int i = 0; i < TmpArr.Count; i++)
            {
                String FName = TmpArr[i];
                info = ReadFieldValue(f, info, FName);
            }
            return info;
        }

        public Definition ReadFieldValue(BinaryReader f, Definition info, String FromName, String ToName)
        {
            int startPos = 0, endPos = 0;
            List<String> TmpArr = MainForm.Instance.DatInfo.getFieldNames();
            for (int i = 0; i < TmpArr.Count; i++)
            {
                if (TmpArr[i] == FromName)
                    startPos = i;
                if (TmpArr[i] == ToName)
                    endPos = i;
            }
            for (int i = startPos; i <= endPos; i++)
                info = ReadFieldValue(f, info, i);
            return info;
        }

        public Definition ReadFieldValue(BinaryReader f, Definition info, int FNumber)
        {
            String FName = MainForm.Instance.DatInfo.getFieldNames()[FNumber];
            return ReadFieldValue(f, info, FName);
        }

        public Definition ReadFieldValue(BinaryReader f, Definition info, String FName)
        {
            Definition TmpInfo = info;
            long curPos = f.BaseStream.Position;
            try
            {
                FieldInfo FType = MainForm.Instance.DatInfo.getDefinition().GetType().GetField(FName);

                Type field = FType.FieldType;
                Object obj = field.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

                if (obj is IType)
                {
                    var type = (IType) obj;
                    FType.SetValue(info, type.read(f));
                }
                else
                {
                    throw new NotImplementedException("Format " + obj.GetType().Name + " is not implement IType");
                }
            }
            catch (Exception ex)
            {
                TmpInfo.DumpFieldValues();
                ex = new ApplicationException(
                    String.Format("Error parsing string file (FieldName: {0} RecordOffset: 0x{1:X} DumpData: {2})",
                                  FName, f.BaseStream.Position, DatTool.Debug_DumpString(f, curPos, 8)), ex);
            }
            return info;
        }

        #endregion

        #region Compile

        public void Compile(BinaryWriter f, List<Definition> infos)
        {
            writeCount(f, infos.Count);

            int total_records = infos.Count;

            MainForm.Instance.onStart(total_records);

            _log.Info("Total Count:" + total_records);

            for (int i = 0; i < total_records; i++)
            {
                CompileMain(f, infos, i);
                MainForm.Instance.setValue(i);
            }

            DatTool.WriteString(f, "SafePackage");
        }

        public virtual void CompileMain(BinaryWriter f, List<Definition> infos, int RecNo)
        {
            var item = new Definition();
            item = infos[RecNo];
            List<String> TmpArr = MainForm.Instance.DatInfo.getFieldNames();
            for (int i = 0; i < TmpArr.Count; i++)
            {
                String FName = TmpArr[i];
                WriteFieldValue(f, item, FName);
            }
        }

        public void WriteFieldValue(BinaryWriter f, Definition info, String FromName, String ToName)
        {
            int startPos = 0, endPos = 0;
            List<String> TmpArr = MainForm.Instance.DatInfo.getFieldNames();
            for (int i = 0; i < TmpArr.Count; i++)
            {
                if (TmpArr[i] == FromName)
                    startPos = i;
                if (TmpArr[i] == ToName)
                    endPos = i;
            }
            for (int i = startPos; i <= endPos; i++)
                WriteFieldValue(f, info, i);
        }

        public void WriteFieldValue(BinaryWriter f, Definition item, int FNumber)
        {
            String FName = MainForm.Instance.DatInfo.getFieldNames()[FNumber];
            WriteFieldValue(f, item, FName);
        }

        public void WriteFieldValue(BinaryWriter f, Definition item, String FName)
        {
            try
            {
                FieldInfo FType = MainForm.Instance.DatInfo.getDefinition().GetType().GetField(FName);
                Object obj = FType.GetValue(item);
                if (obj is IType)
                {
                    var type = (IType) obj;

                    type.write(f);
                }
                else
                {
                    throw new NotImplementedException("Format " + obj.GetType().Name + " is not implement IType");
                }
            }
            catch (Exception ex)
            {
                item.DumpFieldValues();
                ex = new ApplicationException(
                    String.Format("Error compiling string file (FieldName: {0} RecordOffset: 0x{1:X})",
                                  FName, f.BaseStream.Position), ex);
            }
        }

        #endregion
    }
}
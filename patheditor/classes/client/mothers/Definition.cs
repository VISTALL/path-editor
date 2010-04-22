#region Using directives

using System;
using System.Reflection;
using log4net;

#endregion

namespace com.jds.PathEditor.classes.client.mothers
{
    public class Definition
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof (Definition));
        private readonly MemberInfo[] members;

        public Definition()
        {
            members = GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
        }

        public MemberInfo[] getMembers()
        {
            return members;
        }

        public void InitFieldValues()
        {
            foreach (MemberInfo m in members)
            {
                if (m.MemberType == MemberTypes.Field)
                {
                    FieldInfo FType = GetType().GetField(m.Name);
                    if (FType == null)
                        continue;

                    Type type = FType.FieldType;
                    Object obj = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

                    if (obj is IType)
                    {
                        FType.SetValue(this, obj);
                    }
                    else
                    {
                        throw new NotImplementedException("Type " + obj.GetType().Name + " is not implement IType");
                    }
                }
            }
        }

        public void DumpFieldValues()
        {
            _log.Info("------------------- Dump Field Value ------------------");

            foreach (MemberInfo m in members)
            {
                if (m.MemberType == MemberTypes.Field)
                {
                    FieldInfo FType = GetType().GetField(m.Name);
                    if (FType == null) continue;
                    String TmpStr = "";
                    if (FType.GetValue(this) != null)
                    {
                        TmpStr = FType.GetValue(this).ToString();
                    }
                    _log.Info(m.Name + ": " + TmpStr);
                }
            }

            _log.Info("-----------------------------------------------------------");
        }
    }
}
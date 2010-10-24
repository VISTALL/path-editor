using System;

namespace com.jds.PathEditor.classes.client
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class Lineage2Ver : Attribute
    {
        public Lineage2Ver(int ver)
        {
            Ver = ver;     
        }

        public int Ver
        {
            private set; get;
        }
    }
}
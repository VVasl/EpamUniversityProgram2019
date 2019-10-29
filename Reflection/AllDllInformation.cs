
using System;
using Common;
using System.Reflection;

namespace Reflection
{
    public class AllDllInformation
    {
        public AllDllInformation(string assemblyName)
        {
            this.AssemblyName = assemblyName;

        }

        private string AssemblyName { get; set; }

        public void GetAllInfo(IWriter writer)
        {
            Assembly assembly = Assembly.LoadFrom(AssemblyName);
            writer.Show(0, "\tAssembly: {0}", assembly);

            
            foreach (Type t in assembly.ExportedTypes)
            {
                writer.Show(1, "\nType: {0}", t);

                foreach (MemberInfo mi in t.GetMembers())
                {
                    String typeName = String.Empty;
                    if (mi is Type) typeName = "(Nested) Type";
                    if (mi is FieldInfo) typeName = "FieldInfo";
                    if (mi is MethodInfo) typeName = "MethodInfo";
                    if (mi is ConstructorInfo) typeName = "ConstructoInfo";
                    if (mi is PropertyInfo) typeName = "PropertyInfo";
                    if (mi is EventInfo) typeName = "EventInfo";
                    writer.Show(2, "{0}: {1}", typeName, mi);
                }
            }
        }
    }
}

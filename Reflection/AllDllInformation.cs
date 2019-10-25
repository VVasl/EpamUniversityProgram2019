
using System;
using System.Reflection;

namespace Reflection
{
    public class AllDllInformation
    {
        private string AssemblyName { get; set; }

        public AllDllInformation(string assemblyName)
        {
            AssemblyName = assemblyName;

        }
        public void GetAllInfo()
        {
            Assembly assembly = Assembly.LoadFrom(AssemblyName);
            Show(0, "\tAssembly: {0}\n", assembly);

            
            foreach (Type t in assembly.ExportedTypes)
            {
                Show(1, "\nType: {0}", t);

                foreach (MemberInfo mi in t.GetMembers())
                {
                    String typeName = String.Empty;
                    if (mi is Type) typeName = "(Nested) Type";
                    if (mi is FieldInfo) typeName = "FieldInfo";
                    if (mi is MethodInfo) typeName = "MethodInfo";
                    if (mi is ConstructorInfo) typeName = "ConstructoInfo";
                    if (mi is PropertyInfo) typeName = "PropertyInfo";
                    if (mi is EventInfo) typeName = "EventInfo";
                    Show(2, "{0}: {1}", typeName, mi);
                }
            }
        }

        static void Show(Int32 indent, String format, params Object[] args)
        {
            Console.WriteLine(new String(' ', 3 * indent) + format, args);

        }
    }
}

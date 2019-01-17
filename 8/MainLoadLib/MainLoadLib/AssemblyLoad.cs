using System;
using System.Reflection;
using System.Collections.Generic;
using Attribute;

namespace MainLoadLib
{
    class AssemblyLoad
    {
        private Assembly assembly;

        // loads assembly from file 
        public AssemblyLoad(string filename)
        {
            try
            {
                AssemblyName name = AssemblyName.GetAssemblyName(filename);
                assembly = Assembly.Load(name);
            }
            catch
            {
                throw new DllNotFoundException(filename + " not found");
            }
        }

        // returns sorted list of public types 
        public List<string> GetPublicTypes()
        {
            Type[] types = assembly.GetTypes();

            List<string> output = new List<string>();
            foreach (Type type in types)
            {
                if (type.IsPublic && type.IsDefined(typeof(ExportClass)))
                {
                    ExportClass attr = (ExportClass)type.GetCustomAttribute(typeof(ExportClass));

                    Console.WriteLine("Класс - " + type.Name);
                    Console.WriteLine("Name aтрибута - " + attr.Name);
                }
            }

            output.Sort();

            return output;
        }
    }
}

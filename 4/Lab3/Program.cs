using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lab3
{
    class Program
    {
        private static string[] TypesNameFindInAssembly(string asmPath)
        {
            Assembly asm = Assembly.LoadFrom(asmPath);

            //Using LINQ
            var publicTypes = asm.GetTypes().Where(type => type.IsPublic).OrderBy(type => type.Namespace).ThenBy(type => type.Name);

            string[] typesNames = new string[publicTypes.Count()];
            int i = 0;

            foreach (var type in publicTypes)
            {
                typesNames[i] = type.FullName;
                i++;
            }
            return typesNames;
        }

        static void Main(string[] args)
        {
            string path = @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll";
            

            try
            {
                string[] typesList = TypesNameFindInAssembly(path);
                foreach (string type in typesList)
                {
                    Console.WriteLine(type);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

   

        }
    }
}


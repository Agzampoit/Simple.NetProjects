using System;
using System.Collections.Generic;
using System.IO;

namespace LogBuffer
{
    class Tester
    {
        private string path;
        
        public Tester(string path = @"C:\Users\Kostya\source\repos\LogBuffer\List.txt" )
        {
            this.path = path;
        }

        public Boolean IsCorrect()
        {
            string line;
            int i = 0;

            StreamReader file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                i += 1;
                if (i != Convert.ToInt32(line))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

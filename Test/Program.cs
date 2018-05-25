using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            MainAsync().GetAwaiter().GetResult();
        }


        static async Task MainAsync()
        {


            int i = 5;
            object o = i;
            i = 10;

            int j = (int)o;

            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.WriteLine(o);


            Vector vecteur = new Vector();
            vecteur.X = 0;
            vecteur.Y = 0;

            double lengthVector = vecteur.Length();
            Console.Write(lengthVector);

            WorkingUnit testWorkingUnit = new WorkingUnit();
            testWorkingUnit.WorkingPos = new Coordinates(3, 4);
            var result = await testWorkingUnit.WorkBegins();



            testWorkingUnit.ParkingPos = new Coordinates(10, 14);
             result = await testWorkingUnit.WorkEnds();
            if (result)
            {
                using (System.IO.StreamWriter file =
new System.IO.StreamWriter(@"C:\Temp\cds\test.txt"))
                {
                    file.Write(testWorkingUnit.CurrentPos.X + " y : " + testWorkingUnit.CurrentPos.Y);
                }

            }



        }
    }
}

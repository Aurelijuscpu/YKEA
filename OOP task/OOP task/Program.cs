using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_task
{
    class Program
    {
        static void Main(string[] args)
        {
            FetchData();

            Console.ReadKey();
        }

        static void FetchData()
        {
            for (int i = 1; i < 100; i++)
            {
                INumber nr = new Integer(i);
                nr.Filter();
            }
        }
    }
}

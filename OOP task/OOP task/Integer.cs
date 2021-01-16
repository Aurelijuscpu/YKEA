using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_task
{
    class Integer : INumber
    {
        private int _integer;

        public Integer(int nr)
        {
            _integer = nr;
        }

        public void DoTasks(string text)
        {
            Console.WriteLine(text);
        }

        public void Filter()
        {
            if (_integer % 3 == 0 && _integer % 5 == 0)
            {
                DoTasks("SneakyBox");
            }
            else if (_integer % 3 == 0)
            {
                DoTasks("Sneaky");
            }
            else if (_integer % 5 == 0)
            {
                DoTasks("Box");
            }
            else
            {
                DoTasks(_integer.ToString());
            }
        }
    }
}

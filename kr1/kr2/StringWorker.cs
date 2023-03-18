using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr2
{
    internal class StringWorker
    {
        private StringBuilder line;
        private int n;

        public StringWorker(int n)
        {

            this.n = n;


        }
        public string Line
        {

            get { return line.ToString(); }
            set
            {
                line = new StringBuilder(value);
                line.Remove(n,line.Length);
            }

        }
        public char this[int index]{ get => line[index]; }



    }
}

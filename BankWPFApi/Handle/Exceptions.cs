using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handle
{
        public class BadDateException : Exception
        {
            public BadDateException(string msg) : base(msg) { }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Token
    {
        public Token() { }

        private string _token;

        public string token 
        {   
            get { return _token; } 
            set { _token = value; }
        }
    }
}

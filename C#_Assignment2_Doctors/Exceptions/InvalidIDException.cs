using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Exceptions
{
    public class InvalidIDException : Exception
    {
        private string _message;
        public InvalidIDException()
        {
            _message = "Invalid ID . Try again.";
        }
        public override string Message => _message;
    }
}

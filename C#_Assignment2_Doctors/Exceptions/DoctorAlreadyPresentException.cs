using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Exceptions
{
    public class DoctorAlreadyPresentException : Exception
    {
        private string _message;
        public DoctorAlreadyPresentException()
        {
            _message = "Doctor already present. Try again.";
        }
        public override string Message => _message;
    }
}

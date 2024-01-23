using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Exceptions
{
    public class DoctorNotAvailableException:Exception
    {
        private string _message;
        public DoctorNotAvailableException()
        {
            _message = "Doctor Not Available. Try again.";
        }
        public override string Message => _message;
    }
}

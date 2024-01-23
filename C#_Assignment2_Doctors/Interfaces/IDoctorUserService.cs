using C__Assignment2_Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Interfaces
{
    public interface IDoctorUserService
    {
        Task<ICollection<Doctors>> GetAllDoctors();
        Task<Doctors> GetDoctorById(int id);

       

    }
}

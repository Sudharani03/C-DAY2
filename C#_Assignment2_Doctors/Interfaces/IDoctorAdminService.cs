using C__Assignment2_Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Interfaces
{
    public interface IDoctorAdminService
    {
        Task<Doctors> AddDoctor(Doctors doctor);
        Task<Doctors> UpdateDoctorName(int id, string? name);

        Task<Doctors> UpdateDoctorAge(int id, int age);

        Task<Doctors> UpdateDoctorQualification(int id, string? qualification);

        Task<Doctors> UpdateDoctorExperience(int id, float experience);

        Task<Doctors> UpdateDoctorSpeciality(int id, string? speciality);

        Task<bool> DeleteDoctor(int id);
    }
}

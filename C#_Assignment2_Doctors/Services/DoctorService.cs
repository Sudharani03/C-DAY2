using C__Assignment2_Doctors.Exceptions;
using C__Assignment2_Doctors.Interfaces;
using C__Assignment2_Doctors.Models;
using C__Assignment2_Doctors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Services
{
 

        public class DoctorService : IDoctorAdminService, IDoctorUserService
        {


            readonly IDoctorRepository<int, Doctors> _doctorRepository;

            public DoctorService()
            {
                _doctorRepository = new DoctorRepository();

            }

            public async Task<Doctors> AddDoctor(Doctors doctor)
            {
                
                try
                {
                    doctor = _doctorRepository.Add(doctor);
                    return doctor;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }

            public async Task<ICollection<Doctors>> GetAllDoctors()
            {
                var result = _doctorRepository.GetAll();
                if (result == null || result.Count == 0)
                {
                    throw new DoctorNotAvailableException();
                }
                return result;
            }

            public async Task<Doctors> GetDoctorById(int id)
            {
                var result = _doctorRepository.Get(id);
                if (id == null)
                {
                    throw new InvalidIDException();
                }
                return result;
            }


            public async Task<Doctors> UpdateDoctorExperience(int id, float experience)
            {
                var myDoctor = await GetDoctorById(id);
                if (myDoctor == null)
                {
                    throw new InvalidIDException();
                }
                else
                {
                    myDoctor.Experience = experience;
                    return _doctorRepository.Update(myDoctor);
                }
                
            }

            public async Task<bool> DeleteDoctor(int id)
            {
                var doctorToDelete = await GetDoctorById(id);
                if (doctorToDelete == null)
                {
                    throw new InvalidIDException();
                }
                else
                {
                    int temp_id = doctorToDelete.Id;
                    var doc = _doctorRepository.Delete(temp_id);
                    return true;
                }
                
            }

            public async Task<Doctors> UpdateDoctorName(int id, string? name)
            {
                var myDoctor = await GetDoctorById(id);
                if (myDoctor == null)
                {
                    throw new InvalidIDException();
                }
                else
                {
                    myDoctor.Name = name;
                    return _doctorRepository.Update(myDoctor);
                }
               
            }

            public async Task<Doctors> UpdateDoctorAge(int id, int age)
            {
                var myDoctor = await GetDoctorById(id);
                if (myDoctor == null)
                {
                    throw new InvalidIDException();
                }
                else
                {
                    myDoctor.Age = age;
                    return _doctorRepository.Update(myDoctor);
                }
                
            }

        public async Task<Doctors> UpdateDoctorQualification(int id, string? qualification)
        {
            var myDoctor = await GetDoctorById(id);
            if (myDoctor == null)
            {
                throw new InvalidIDException();
            }
            else
            {
                myDoctor.Qualification = qualification;
                return _doctorRepository.Update(myDoctor);
            }

        }

        public async Task<Doctors> UpdateDoctorSpeciality(int id, string? speciality)
        {
            var myDoctor = await GetDoctorById(id);
            if (myDoctor == null)
            {
                throw new InvalidIDException();
            }
            else
            {
                myDoctor.Speciality = speciality;
                return _doctorRepository.Update(myDoctor);
            }
        }

            
        }
}


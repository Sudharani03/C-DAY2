using C__Assignment2_Doctors.Exceptions;
using C__Assignment2_Doctors.Interfaces;
using C__Assignment2_Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__Assignment2_Doctors.Repository
{
    /// <summary>
    /// Implementation of interface (IDoctorRepository) for Doctor Model
    /// </summary>
    public class DoctorRepository : IDoctorRepository<int, Doctors>
    {
        /// <summary>
        /// List to Doctor entities
        /// </summary>
        List<Doctors> doctors;
        /// <summary>
        /// Constructor to initialize the DoctorReository
        /// </summary>
        public DoctorRepository()
        {
            doctors = new List<Doctors>();
        }

        /// <summary>
        /// Generates a unique id for a new doctor
        /// </summary>
        /// <returns>Returns generated id</returns>

        int GenerateID()
        {
            if (doctors.Count == 0)
            {
                //If no Doctors are present , start with ID 101
                return 101;
            }

            //else Get the ID of last doctor and increment for a new one 

            int id = doctors[doctors.Count - 1].Id;
            return ++id;

        }


        /// <summary>
        /// Adds a new Doctor to the repository
        /// </summary>
        /// <param name="doctor">Doctor obj to be added</param>
        /// <returns>Returns added doctor entity if present , otherwise exception is thrown </returns>
        /// <exception cref="DoctorAlreadyPresentException"></exception>
        public Doctors? Add(Doctors doctor)
        {
            //Generating unique id for new doctor
            doctor.Id = GenerateID();
            //check if doctor is already present 
            if (doctors.Contains(doctor))
            {
                throw new DoctorAlreadyPresentException();

            }
            //Else : Add new doctor to repository
            else
            {
                doctors.Add(doctor);
                Console.WriteLine("Doctor added successfully");
                return doctor;
            }


        }


        /// <summary>
        /// Deletes a doctor from repository based on id 
        /// </summary>
        /// <param name="id">ID of doctor to be deleted</param>
        /// <returns>Returns Deleted Doctor entity if present , otherwise throws exception</returns>
        /// <exception cref="InvalidIDException"></exception>

        public Doctors? Delete(int id)
        {
            //Get doctor by id
            var doctor = Get(id);
            //If : found --> remove doctor item from repository
            if (doctor != null)
            {
                doctors.Remove(doctor);
                return doctor;
            }
            //Else : return null with a msg
            throw new InvalidIDException();
        }


        /// <summary>
        /// Retrieves a doctor from repository based on id
        /// </summary>
        /// <param name="id">The id of doctor to be retrieved</param>
        /// <returns>Returns retrieved doc , otherwise null</returns>
        /// <exception cref="InvalidIDException"></exception>

        public Doctors? Get(int id)
        {
            var doctor = doctors.SingleOrDefault(p => p.Id == id);
            if (doctor != null)
            {
                return doctor;
            }
            else
            {
                throw new InvalidIDException();
            }


        }

            /// <summary>
            /// Maps properties from one doctor entity to another
            /// </summary>
            /// <param name="doctor">The source doctor entity</param>
            /// <returns>A new doctor entity with same props as source</returns>

            Doctors MapDoctor(Doctors doctor)
            {
                Doctors myDoctor = new Doctors();
                myDoctor.Id = doctor.Id;
                myDoctor.Name = doctor.Name;
                myDoctor.Age = doctor.Age;
                myDoctor.Qualification = doctor.Qualification;
                myDoctor.Experience = doctor.Experience;
                myDoctor.Speciality = doctor.Speciality;
                return myDoctor;
            }


            /// <summary>
            /// Retrieves all the doctors presnet in repo
            /// </summary>
            /// <returns>A list of doctors if present , otherwise throws exception</returns>
            /// <exception cref="DoctorNotAvailableException"></exception>
            public List<Doctors> GetAll()
            {
            if (doctors.Count == 0)
            {
                throw new DoctorNotAvailableException();
            }
            return doctors;
            }



        /// <summary>
        /// Updates a doctor in repository 
        /// </summary>
        /// <param name="doctors">The doctor obj to be updated</param>
        /// <returns>Returns updated doctor if presnt , otherwise throws Exception</returns>
        /// <exception cref="InvalidIDException"></exception>
        public Doctors? Update(Doctors doctors)
        {
            var myDoctor = Get(doctors.Id);
            if (myDoctor != null)
            {
                myDoctor = MapDoctor(doctors);
                return myDoctor;
            }

            else
            {
                throw new InvalidIDException();

            }
        }
    }
}

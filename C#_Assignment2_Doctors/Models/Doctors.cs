using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C__Assignment2_Doctors.Models
{
    public class Doctors : IEquatable<Doctors>
    {
        /// <summary>
        /// gets and sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// gets and sets the name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// gets and sets the age 
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// gets and sets the qualification
        /// </summary>
        public string? Qualification { get; set; }
        /// <summary>
        /// gets and sets the experience
        /// </summary>
        public float Experience { get; set; }
        /// <summary>
        /// gets and sets the speciality
        /// </summary>
        public string? Speciality { get; set; }

        /// <summary>
        /// Parameterized constructor of Doctor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="qualification"></param>
        /// <param name="experience"></param>
        /// <param name="speciality"></param>

        public Doctors(int id, string? name, int age, string? qualification, float experience, string? speciality)
        {
            Id = id;
            Name = name ?? "";
            Age = age;
            Qualification = qualification ?? "";
            Experience = experience;
            Speciality = speciality ?? "";
        }

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Doctors()
        {

        }

        /// <summary>
        /// Overrides the toString() method to provide the formatted string representation of Doctor
        /// </summary>
        /// <returns>Returns a formatted string containing doctor details </returns>
        public override string ToString()
        {
            return "Doctor Id\t" + Id +
                    "\nDoctor Name\t" + Name +
                    "\nDoctor Age\t" + Age +
                    "\nDoctor Qualification\t" + Qualification +
                    "\nDoctor Experience\t" + Experience +
                    "\nDoctor Specialty\t" + Speciality;
        }

        /// <summary>
        /// Implements the equality comparision between two doctor objects based on their Name 
        /// </summary>
        /// <param name="other">The other Doctor parameter to compare</param>
        /// <returns>Returns TRUE if Names are equal , otherwise FALSE</returns>

        public bool Equals(Doctors? other)
        {
            if (other == null)
                return false;
            return this.Name == other.Name;
        }
    }
}

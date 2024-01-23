using System;
using System.Dynamic;
using System.Numerics;
using System.Reflection.Emit;
using System.Threading.Channels;
using System.Xml.Linq;
using C__Assignment2_Doctors.Exceptions;
using C__Assignment2_Doctors.Interfaces;
using C__Assignment2_Doctors.Models;
using C__Assignment2_Doctors.Repository;
using C__Assignment2_Doctors.Services;

namespace C__Assignment2_Doctors
{
    public class Program
    {
        readonly IDoctorAdminService _doctorAdminService;
        readonly IDoctorUserService _doctorUserService;
        public Program()
        {
            DoctorService doctorService = new DoctorService();
            _doctorAdminService = doctorService;
            _doctorUserService = doctorService;
        }
        async static Task Main(string[] args)
        {
            Program program = new Program();
        l1: string ch = "y";
            do
            {
                Console.WriteLine("1 -- Admin Service");
                Console.WriteLine("\n2 -- User Service");
                Console.WriteLine("\n3 -- Exit");
                int option1 = int.Parse(Console.ReadLine());
                switch (option1)
                {
                    case 1:
                        string ch1 = "y";
                        do
                        {
                            Console.WriteLine("1 -- Add Doctor");
                            Console.WriteLine("\n2 -- Update Doctor Name");
                            Console.WriteLine("\n3 -- Update Doctor Age");
                            Console.WriteLine("\n4 -- Update Doctor Qualification");
                            Console.WriteLine("\n5 -- Update Doctor Speciality");
                            Console.WriteLine("\n6 -- Exit");
                            int option2 = int.Parse(Console.ReadLine());
                            switch (option2)
                            {
                                case 1:
                                    Console.WriteLine("Enter the name of the doctor\n");
                                   
                                    string name = Console.ReadLine();
                                    Console.WriteLine("\nEnter the age");
                                    int age = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter the experience");
                                    float experience =
                                   float.Parse(Console.ReadLine());
                                    Console.WriteLine("\nEnter the qualification");
                                   
                                    string qualification = Console.ReadLine();
                                    Console.WriteLine("\nEnter the Speciality");
                                    string speciality = Console.ReadLine();
                                    Doctors doctor = new Doctors()
                                    {
                                        Name = name,
                                        Age = age,
                                        Experience = experience,
                                        Qualification = qualification,
                                        Speciality = speciality
                                    };
                                    try
                                    {
                                        var result1 = await
                                       program._doctorAdminService.AddDoctor(doctor);
                                        program._doctorAdminService.AddDoctor(doctor);
                                        if (result1 != null)
                                            Console.WriteLine("Doctor Added");
                                        else
                                            Console.WriteLine("Something went worng");
                                    }
                                    catch (DoctorAlreadyPresentException msg)
                                    {
                                        Console.WriteLine(msg.Message);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the doctor is whose Name is to be updated");
                                   
                                    int change_id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new name of the doctor");
                                   
                                    string? change_name =Console.ReadLine();
                                    var result12 = await
                                   program._doctorAdminService.UpdateDoctorName(change_id, change_name);

                                    if (result12 != null)
                                        Console.WriteLine($"Doctor: ID:{ result12.Id}, Updated Name: { result12.Name}");
                                    else
                                        Console.WriteLine("Something went worng");
                                    break;

                                case 3:
                                    Console.WriteLine("Enter the doctor is whose age is to be updated");

                                    int change_id1 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new age of the doctor");

                                    int change_age = int.Parse(Console.ReadLine());
                                    var result13 = await
                                   program._doctorAdminService.UpdateDoctorAge(change_id1, change_age);

                                    if (result13 != null)
                                        Console.WriteLine($"Doctor: ID:{result13.Id}, Updated Age: {result13.Age}");
                                    else
                                        Console.WriteLine("Something went worng");
                                    break;

                                case 4:
                                    Console.WriteLine("Enter the doctor is whose Qualification is to be updated");

                                    int change_id2 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new Qualification of the doctor");

                                    string? change_qualif = Console.ReadLine();
                                    var result14 = await
                                   program._doctorAdminService.UpdateDoctorQualification(change_id2, change_qualif);

                                    if (result14 != null)
                                        Console.WriteLine($"Doctor: ID:{result14.Id}, Updated Qualification: {result14.Qualification}");
                                    else
                                        Console.WriteLine("Something went worng");
                                    break;

                                case 5:
                                    Console.WriteLine("Enter the doctor is whose Speciality is to be updated");

                                    int change_id3 = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the new speciality of the doctor");

                                    string? change_speciality = Console.ReadLine();
                                    var result15 = await
                                   program._doctorAdminService.UpdateDoctorSpeciality(change_id3, change_speciality);

                                    if (result15 != null)
                                        Console.WriteLine($"Doctor: ID:{result15.Id}, Updated Speciality: {result15.Speciality}");
                                    else
                                        Console.WriteLine("Something went worng");
                                    break;
                                case 6:
                                    goto l1;
                                    break;
                            }
                            Console.WriteLine("\n\t\tDo you want the main menu... ?? (y / n)");
                            
                             ch1 = Console.ReadLine();
                            Console.Clear();
                        } while (ch1 == "y");
                        break;
                    case 2:
                        string ch2 = "y";
                        do
                        {
                            Console.WriteLine("\n1 -- Get All Doctors");
                            Console.WriteLine("\n2 -- Get Doctor By Id");
                            Console.WriteLine("\n3 -- Exit");
                            int option3 = int.Parse(Console.ReadLine());
                            switch (option3)
                            {

                                case 1:
                                    try
                                    {
                                        var result = await
                                       program._doctorUserService.GetAllDoctors();
                                        foreach (var item in result)
                                        {
                                            Console.WriteLine(item);
                                        }
                                    }
                                    catch (DoctorNotAvailableException m)
                                    {
                                        Console.WriteLine(m.Message);
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter the doctor id to retrieve");
                                       
                                        int doctorIdToGet =
                                       int.Parse(Console.ReadLine());
                                        var retrieved_Doctor = await
                                       program._doctorUserService.GetDoctorById(doctorIdToGet);
                                        if (retrieved_Doctor != null)
                                        {
                                            Console.WriteLine($"Retrieved Doctor:ID: { retrieved_Doctor.Id}, Name: { retrieved_Doctor.Name}, Speciality:{ retrieved_Doctor.Speciality}");
                                        }
                                    }
                                    catch (InvalidIDException msg)
                                    {
                                        Console.WriteLine(msg.Message);
                                    }
                                    break;
                                case 3:
                                    goto l1;
                                    break;
                            }
                            Console.WriteLine("\n\tDo you want the main menu... ?? (y / n)");
                            
                             ch1 = Console.ReadLine();
                            Console.Clear();
                        } while (ch2 == "y");
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using our application.Have a great day!");
                       
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("\n\tDo you want the main menu ...?? (y / n)");
                
                 ch = Console.ReadLine();
                Console.Clear();
            } while (ch == "y");
        }
    }
}

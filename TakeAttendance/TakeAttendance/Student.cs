using System;
using System.Collections.Generic;
using System.Text;

namespace TakeAttendance
{
    public class Student
    {
        //[PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        //[MaxLength(255)]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string ModifiedBy { get; set; }
        public string Created { get; set; }
        public string BirthDate { get; set; }
        public string Parentg1 { get; set; }
        public string Parentg2 { get; set; }
        public string AltPhone { get; set; }
        public string Email { get; set; }
        public string Nganh { get; set; }
        public int ChiDoan { get; set; }
        public string Medical { get; set; }
        public string PaidStat { get; set; }
        public string Comments { get; set; }    

        //Consecutive Absences

        //Image Url
    }
}

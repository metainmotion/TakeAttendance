using System;
using System.Collections.Generic;
using System.Text;

namespace TakeAttendance
{
    public class Student
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //[MaxLength(255)]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }

    }
}

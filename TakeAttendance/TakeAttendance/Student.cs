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
        public string UserId { get; set; }
        public string ModifiedBy { get; set; }

    }
}

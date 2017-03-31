using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDeploy.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string DateOfBirth { get; set; }
       // public Gender Gender { get; set; }
       // public IList<string> EducationList { get; set; }
       // public int DepartmentId { get; set; }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}

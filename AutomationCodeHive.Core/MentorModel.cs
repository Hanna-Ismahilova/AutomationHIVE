using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationCodeHive.Models
{
    public class MentorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EducationTypeEnum Education { get; set; }
        public int Experience { get; set; }
        public UserTypeEnum User { get; set; }
        public TechnologiesStackEnum Technologies { get; set; }


    }
}

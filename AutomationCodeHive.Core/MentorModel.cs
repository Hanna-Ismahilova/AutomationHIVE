using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutomationCodeHive.Models
{
    public class MentorModel
    {
        public int Id { get; set; }

        [Required,StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Surname { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(80)]
        public string Phone { get; set; }

        public EducationTypeEnum Education { get; set; }

        [Required]
        public int Experience { get; set; }

        public UserTypeEnum User { get; set; }

        public TechnologiesStackEnum Technologies { get; set; }


    }
}

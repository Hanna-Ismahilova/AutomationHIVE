using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationCodeHive.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using AutomationCodeHive.Models;

namespace AutomationCodeHive.Pages.Mentor
{
    public class MentorListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IMentorData mentorData;

        public IEnumerable<MentorModel> Mentors { get; set; }
        
        [BindProperty(SupportsGet = true )]
        public string SearchTerm { get; set; }
        public MentorListModel(IConfiguration configuration, 
                           IMentorData mentorData)
        {
            this.configuration = configuration;
            this.mentorData = mentorData;
        }
        public void OnGet(string searchTerm)
        {
            Mentors = mentorData.GetMentorByName(searchTerm);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationCodeHive.Data;
using AutomationCodeHive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomationCodeHive
{
    public class MentorDetailModel : PageModel
    {
        private readonly IMentorData mentorData;

        [TempData]
        public string Message { get; set; }
        public MentorModel MentorModel { get; set; }

        public MentorDetailModel(IMentorData mentorData)
        {
            this.mentorData = mentorData;
        }

        public IActionResult OnGet(int mentorId)
        {
            MentorModel = mentorData.GetById(mentorId);
            if (MentorModel == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
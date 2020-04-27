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
    public class MentorDeleteModel : PageModel
    {
        private readonly IMentorData mentorData;

        public MentorModel Mentor { get; set; }

        public MentorDeleteModel(IMentorData mentorData)
        {
            this.mentorData = mentorData;
        }
        public IActionResult OnGet(int mentorId)
        {
            Mentor = mentorData.GetById(mentorId);
            if (Mentor == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult OnPost(int mentorId)
        {
            var mentor = mentorData.Delete(mentorId);
            mentorData.Commit();
            if (mentor == null)
            {
                return RedirectToPage("./NotFound");

            }
            TempData["Message"] = $"{mentor.Name} is successfully deleted!";
            return RedirectToPage("./MentorList");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomationCodeHive.Data;
using AutomationCodeHive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomationCodeHive
{
    public class MentorEditModel : PageModel
    {
        private readonly IMentorData mentorData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty ]
        public MentorModel Mentor { get; set; }
        public IEnumerable<SelectListItem> EducationType { get; set; }
        public IEnumerable<SelectListItem> TechnologiesStack { get; set; }

        public MentorEditModel(IMentorData mentorData,
                               IHtmlHelper htmlHelper)
        {
            this.mentorData = mentorData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? mentorId)
        {
            EducationType = htmlHelper.GetEnumSelectList<EducationTypeEnum>();
            TechnologiesStack = htmlHelper.GetEnumSelectList<TechnologiesStackEnum>();

            if (mentorId.HasValue)
            {
                Mentor = mentorData.GetById(mentorId.Value);
            }
            else
            {
                Mentor = new MentorModel();
            }
            if (Mentor == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                EducationType = htmlHelper.GetEnumSelectList<EducationTypeEnum>();
                TechnologiesStack = htmlHelper.GetEnumSelectList<TechnologiesStackEnum>();
                return Page();
                
            }
            if (Mentor.Id > 0)
            {
                Mentor = mentorData.Update(Mentor);
                TempData["Message"] = "The mentor is updated!";
            }
            else
            {
                Mentor = mentorData.Add(Mentor);
                TempData["Message"] = "The new mentor is saved!";
            }
            
            mentorData.Commit();
            return RedirectToPage("./MentorDetail", new { mentorId = Mentor.Id });


        }
    }
}
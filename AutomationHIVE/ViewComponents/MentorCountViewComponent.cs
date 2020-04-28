using AutomationCodeHive.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomationCodeHive.ViewComponents
{
    public class MentorCountViewComponent
        : ViewComponent
    {
        private readonly IMentorData mentorData;

        public MentorCountViewComponent(IMentorData mentorData)
        {
            this.mentorData = mentorData;
        }

        public IViewComponentResult Invoke()
        {
            var count = mentorData.GetCountOfMentors();
            return View(count);
        }
    }
}

using AutomationCodeHive.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Keyword = dotless.Core.Parser.Tree.Keyword;

namespace AutomationCodeHive.Data
{
    public interface IMentorData
    {
        IEnumerable<MentorModel2> GetMentorByName(string name);
        MentorModel2 GetById(int id);
        MentorModel2 Update(MentorModel2 updatedMentor);
        MentorModel2 Add(MentorModel2 newMentor);
        int Commit();

    }

    public class InMemoryMentorData : IMentorData
    {
        List<MentorModel2> mentors;
        public InMemoryMentorData()
        {
            mentors = new List<MentorModel2>()
            { 
                new MentorModel2 { Id = 1, Name = "Alisa", Surname = "Perkins", Email = "a.perkins@randatmail.com	", Phone = "598-9402-12", 
                     Education = EducationTypeEnum.Master, Experience = 5, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.APITests},
                
                new MentorModel2 { Id = 2, Name = "Briony", Surname = "Mason", Email = "b.mason@randatmail.com", Phone = "598-9402-13", 
                     Education = EducationTypeEnum.Master, Experience = 17, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.NoFunctionalTests}, 
                
                new MentorModel2 { Id = 3, Name = "Eleanor", Surname = "Dixon", Email = "e.dixon@randatmail.com", Phone = "183-3358-06", 
                     Education = EducationTypeEnum.Master, Experience = 23, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.OOP},
                
                new MentorModel2 { Id = 4, Name = "Frederick", Surname = "Harrison", Email = "f.harrison@randatmail.com", Phone = "765-9951-38", 
                     Education = EducationTypeEnum.Associate, Experience = 2, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.UITests},
                
                new MentorModel2 { Id = 5, Name = "Lilianna", Surname = "Montgomery", Email = "l.montgomery@randatmail.com", Phone = "887-9896-16", 
                     Education = EducationTypeEnum.Master, Experience = 14, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.UnitTests},
      

            };    
        }

        public MentorModel2 GetById(int id)
        {
            return mentors.SingleOrDefault(m => m.Id == id);
        }

        public MentorModel2 Add(MentorModel2 newMentor)
        {
            mentors.Add(newMentor);
            newMentor.Id = mentors.Max(m => m.Id) + 1;
            return newMentor;
        }

        public MentorModel2 Update(MentorModel2 updatedMentor)
        {
            var mentor = mentors.SingleOrDefault(m => m.Id == updatedMentor.Id);
            if (mentor != null)
            {
                mentor.Name = updatedMentor.Name;
                mentor.Surname = updatedMentor.Surname;
                mentor.Email = updatedMentor.Email;
                mentor.Phone = updatedMentor.Phone;
                mentor.Education = updatedMentor.Education;
                mentor.Experience = updatedMentor.Experience;
                mentor.Technologies = updatedMentor.Technologies;
            }
            return mentor;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<MentorModel2> GetMentorByName(string name = null)
        {
            return from m in mentors
                   where string.IsNullOrEmpty(name)
                   || m.Name.StartsWith(name)
                   orderby m.Name
                   select m;
        }

          }
}

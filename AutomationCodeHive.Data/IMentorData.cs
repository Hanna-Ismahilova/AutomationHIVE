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
        IEnumerable<MentorModel> GetMentorByName(string name);
        MentorModel GetById(int id);
    }

    public class InMemoryMentorData : IMentorData
    {
        List<MentorModel> mentors;
        public InMemoryMentorData()
        {
            mentors = new List<MentorModel>()
            { 
                new MentorModel { Id = 1, Name = "Alisa", Surname = "Perkins", Email = "a.perkins@randatmail.com	", Phone = "598-9402-12", 
                     Education = EducationTypeEnum.Master, Experience = 5, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.APITests},
                
                new MentorModel { Id = 2, Name = "Briony", Surname = "Mason", Email = "b.mason@randatmail.com", Phone = "598-9402-13", 
                     Education = EducationTypeEnum.Master, Experience = 17, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.NoFunctionalTests}, 
                
                new MentorModel { Id = 3, Name = "Eleanor", Surname = "Dixon", Email = "e.dixon@randatmail.com", Phone = "183-3358-06", 
                     Education = EducationTypeEnum.Master, Experience = 23, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.OOP},
                
                new MentorModel { Id = 4, Name = "Frederick", Surname = "Harrison", Email = "f.harrison@randatmail.com", Phone = "765-9951-38", 
                     Education = EducationTypeEnum.Associate, Experience = 2, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.UITests},
                
                new MentorModel { Id = 5, Name = "Lilianna", Surname = "Montgomery", Email = "l.montgomery@randatmail.com", Phone = "887-9896-16", 
                     Education = EducationTypeEnum.Master, Experience = 14, User = UserTypeEnum.Mentor, Technologies =  TechnologiesStackEnum.UnitTests},
      

            };    
        }

        public MentorModel GetById(int id)
        {
            return mentors.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<MentorModel> GetMentorByName(string name = null)
        {
            return from m in mentors
                   where string.IsNullOrEmpty(name)
                   || m.Name.StartsWith(name)
                   orderby m.Name
                   select m;
        }

          }
}

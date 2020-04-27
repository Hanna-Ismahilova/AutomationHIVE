using AutomationCodeHive.Models;
using System.Collections.Generic;
using AutomationCodeHive;
using AutomationHIVE.Data.Data.Migrations;

namespace AutomationCodeHive.Data
{
    public class SQLMentorData : IMentorData
    {
       
        private readonly AutomationCodeHiveDbContext dbContext;

        public SQLMentorData(AutomationCodeHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public MentorModel Add(MentorModel newMentor)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public MentorModel Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public MentorModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<MentorModel> GetMentorByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public MentorModel Update(MentorModel updatedMentor)
        {
            throw new System.NotImplementedException();
        }
    }
}

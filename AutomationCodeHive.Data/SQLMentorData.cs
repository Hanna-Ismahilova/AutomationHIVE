using AutomationCodeHive.Models;
using System.Collections.Generic;
using AutomationCodeHive;
using AutomationHIVE.Data.Data.Migrations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AutomationCodeHive.Data
{
    public class SQLMentorData : IMentorData
    {

        private readonly AutomationCodeHiveDbContext db;

        public SQLMentorData(AutomationCodeHiveDbContext db)
        {
            this.db = db;
        }
        public MentorModel Add(MentorModel newMentor)
        {
            db.Add(newMentor);
            return newMentor;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public MentorModel Delete(int id)
        {
            var mentor = GetById(id);
            if (mentor != null)
            {
                db.Mentors.Remove(mentor);

            }
            return mentor;
        }

        public MentorModel GetById(int id)
        {
            return db.Mentors.Find(id);
        }

        public IEnumerable<MentorModel> GetMentorByName(string name)
        {
            var query = from m in db.Mentors
                        where m.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby m.Name
                        select m;
            return query;
        }

        public MentorModel Update(MentorModel updatedMentor)
        {
            var entity = db.Mentors.Attach(updatedMentor);
            entity.State = EntityState.Modified;
            return updatedMentor;
        }
    }
}

using AutomationCodeHive.Models;
using System.Collections.Generic;
using System.Text;
using Keyword = dotless.Core.Parser.Tree.Keyword;

namespace AutomationCodeHive.Data
{
    public interface IMentorData
    {
        IEnumerable<MentorModel> GetMentorByName(string name);
        MentorModel GetById(int id);
        MentorModel Update(MentorModel updatedMentor);
        MentorModel Add(MentorModel newMentor);
        MentorModel Delete(int id);
        int Commit();

    }
}

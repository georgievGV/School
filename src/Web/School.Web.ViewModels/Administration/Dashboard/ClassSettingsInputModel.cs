namespace School.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    public class ClassSettingsInputModel
    {
        public ClassSettingsInputModel()
        {
            this.Subjects = new List<SubjectModel>();
            this.SubjectNames = new List<string>();
        }

        public string Id { get; set; }

        public List<SubjectModel> Subjects { get; set; }

        public List<string> SubjectNames { get; set; }
    }
}

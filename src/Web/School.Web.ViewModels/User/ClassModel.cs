namespace School.Web.ViewModels.User
{
    using System.Collections.Generic;

    public class ClassModel
    {
        public int ClassNumber { get; set; }

        public List<SpecialtyModel> Specialties { get; set; }
    }
}

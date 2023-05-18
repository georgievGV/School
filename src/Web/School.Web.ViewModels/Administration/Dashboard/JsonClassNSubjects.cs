namespace School.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class JsonClassNSubjects
    {
        public List<string> Classes { get; set; }

        public List<string> Subjects { get; set; }
    }
}

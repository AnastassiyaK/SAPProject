using System;
using System.Collections.Generic;
using StepComponent = SAPBusiness.Tutorial.Step.Step;

namespace SAPBusiness.Tutorial
{
    public class Tutorial
    {
        public string Author { get; set; }
        public string AuthorProfile { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string PrimaryTag { get; set; }

        public List<StepComponent> Steps { get; }
    }
}

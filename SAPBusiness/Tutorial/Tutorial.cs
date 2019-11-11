namespace SAPBusiness.Tutorial
{
    using System;
    using System.Collections.Generic;
    using SAPBusiness.Tutorial.Step;

    public class Tutorial
    {
        private static readonly string _line = "---\n";

        private List<AccordionStep> _steps;

        public Tutorial()
        {
            _steps = new List<AccordionStep>();
        }

        public string Author { get; set; } = "Test";

        public string AuthorProfile { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public DateTime Time { get; set; }

        public string Title { get; set; }

        public string PrimaryTag { get; set; }

        public void Add(AccordionStep step)
        {
            _steps.Add(step);
        }

        public void Add(List<AccordionStep> steps)
        {
            _steps.AddRange(steps);
        }

        public override string ToString()
        {
            string header = _line;
            header += $"{Author} \n";
            header += _line;

            string tutorial = header;
            foreach (var step in _steps)
            {
                tutorial += step.FormatView();
            }

            return tutorial;
        }
    }
}

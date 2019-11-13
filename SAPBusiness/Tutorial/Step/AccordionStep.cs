namespace SAPBusiness.Tutorial.Step
{
    using System.Collections.Generic;
    using System.Text;

    public class AccordionStep : AccordionCompositeComponent, IAccordion
    {
        private readonly string _header;

        private readonly int _number;

        public AccordionStep(int number, string header)
        {
            _number = number;
            _header = header;
            _components = new List<AccordionComponent>();
        }

        public override string FormatView()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\n");
            builder.Append($"[ACCORDION-BEGIN [STEP {_number}]({_header})]\n\n");

            foreach (var component in _components)
            {
                builder.Append($"{component.FormatView()}");
            }

            int index = builder.ToString().LastIndexOf("\n\n");
            if (index < builder.ToString().Length - 4)
            {
                builder.Append("[ACCORDION-END]\n");
            }
            else
            {
                builder.Append("\n[ACCORDION-END]\n");
            }

            return builder.ToString();
        }
    }
}

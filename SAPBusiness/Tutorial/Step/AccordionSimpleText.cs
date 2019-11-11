namespace SAPBusiness.Tutorial.Step
{
    using System.Collections.Generic;
    using System.Text;

    public class AccordionSimpleText : AccordionBaseText
    {
        public AccordionSimpleText(string text)
            : base(text)
        {
        }

        public override string FormatView()
        {
            return $"{_text}";
        }
    }
}

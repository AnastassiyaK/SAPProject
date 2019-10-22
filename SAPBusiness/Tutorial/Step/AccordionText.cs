using System;

namespace SAPBusiness.Tutorial.Step
{
    public class AccordionText : AccordionBaseText
    {
        public AccordionText(string text) : base(text)
        {
        }

        public override string FormatView()
        {
            return _text;
        }
    }
}

namespace SAPBusiness.Tutorial.Step
{
    public class AccordionReference : AccordionBaseText
    {
        public AccordionReference(string text) : base(text)
        {
        }

        public override string FormatView()
        {
            return $"#{_text}";
        }
    }
}

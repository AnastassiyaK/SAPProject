namespace SAPBusiness.Tutorial.Step
{
    public class AccordionBlockquote : AccordionBaseText
    {
        public AccordionBlockquote(string text)
            : base(text)
        {
        }

        public override string FormatView()
        {
            return $">{_text}";
        }
    }
}

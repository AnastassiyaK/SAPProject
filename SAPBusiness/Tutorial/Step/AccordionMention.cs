namespace SAPBusiness.Tutorial.Step
{
    public class AccordionMention : AccordionBaseText
    {
        public AccordionMention(string text)
            : base(text)
        {
        }

        public override string FormatView()
        {
            return $"@{_text}";
        }
    }
}

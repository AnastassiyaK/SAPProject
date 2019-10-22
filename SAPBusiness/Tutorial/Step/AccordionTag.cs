namespace SAPBusiness.Tutorial.Step
{
    public class AccordionTag : AccordionBaseText
    {
        public AccordionTag(string text) : base(text)
        {
        }

        public override string FormatView()
        {
            return $"~~{_text}~~";
        }
    }
}

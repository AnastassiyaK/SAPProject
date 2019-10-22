namespace SAPBusiness.Tutorial.Step
{
    public class AccordionLink : AccordionBaseText
    {
        private readonly string _name;
        public AccordionLink(string name, string text) : base(text)
        {
            _name = name;
        }

        public override string FormatView()
        {
            return $"[{ _name }] ({ _text })";
        }
    }
}

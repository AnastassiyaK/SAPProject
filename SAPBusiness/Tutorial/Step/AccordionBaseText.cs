namespace SAPBusiness.Tutorial.Step
{
    public abstract class AccordionBaseText : AccordionComponent
    {
        protected string _text;

        public AccordionBaseText(string text)
        {
            _text = text;
        }

        public AccordionBaseText ToBold()
        {
            _text = $"**{_text}**";
            return this;
        }

        public AccordionBaseText ToItalic()
        {
            _text = $"*{_text}";
            return this;
        }
    }
}

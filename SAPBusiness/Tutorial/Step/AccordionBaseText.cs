namespace SAPBusiness.Tutorial.Step
{
    public abstract class AccordionBaseText : AccordionComponent
    {
        protected readonly string _text;

        public AccordionBaseText(string text)
        {
            _text = text;
        }
    }
}

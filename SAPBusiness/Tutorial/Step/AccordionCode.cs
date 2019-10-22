namespace SAPBusiness.Tutorial.Step
{
    public class AccordionCode : AccordionComponent
    {
        private Language _language;
        private string _body;

        public AccordionCode(Language language, string body)
        {
            _language = language;
            _body = body;
        }

        public override string FormatView()
        {
            throw new System.NotImplementedException();
        }
    }
}

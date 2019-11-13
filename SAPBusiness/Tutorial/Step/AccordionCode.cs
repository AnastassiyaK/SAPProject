namespace SAPBusiness.Tutorial.Step
{
    using SAPBusiness.Enums;

    public class AccordionCode : AccordionCompositeComponent, IAccordion
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

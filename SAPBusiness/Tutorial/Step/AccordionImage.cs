namespace SAPBusiness.Tutorial.Step
{
    public class AccordionImage : AccordionComponent
    {
        public string _url;

        public AccordionImage(string url)
        {
            _url = url;
        }

        public override string FormatView()
        {
            return $"![Image] {_url}";
        }
    }
}

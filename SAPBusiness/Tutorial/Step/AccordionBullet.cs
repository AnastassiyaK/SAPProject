namespace SAPBusiness.Tutorial.Step
{
    public class AccordionBullet : AccordionBaseText
    {
        public AccordionBullet(string text)
            : base(text)
        {
        }

        public override string FormatView()
        {
            return $"* {_text}\n";
        }
    }
}

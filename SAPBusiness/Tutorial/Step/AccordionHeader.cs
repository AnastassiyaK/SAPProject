namespace SAPBusiness.Tutorial.Step
{
    using SAPBusiness.Enums;

    public class AccordionHeader : AccordionComponent
    {
        private readonly string _text;

        private readonly HeaderType _type;

        public AccordionHeader(HeaderType type, AccordionBaseText component)
        {
            _type = type;
            _text = component.FormatView().Replace("\n", $" ({type.ToString().ToLower()})");
        }

        public override string FormatView()
        {
            string result = $"{_text}\n\n";
            switch (_type)
            {
                case HeaderType.H1:
                    return $"# {result}";
                case HeaderType.H2:
                    return $"## {result}";
                case HeaderType.H3:
                    return $"### {result}";
                case HeaderType.H4:
                    return $"#### {result}";
                case HeaderType.H5:
                    return $"##### {result}";
                case HeaderType.H6:
                    return $"###### {result}";
                default:
                    return "";
            }
        }
    }
}

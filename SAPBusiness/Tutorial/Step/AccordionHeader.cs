using System;

namespace SAPBusiness.Tutorial.Step
{
    public class AccordionHeader : AccordionComponent
    {
        private HeaderType _type;

        private readonly string _text;
        public AccordionHeader(HeaderType type, string text)
        {
            _type = type;
            _text = text;
        }

        public override string FormatView()
        {
            switch (_type)
            {
                case HeaderType.H1:
                    return $"# {_text}";
                case HeaderType.H2:
                    return $"## {_text}";
                case HeaderType.H3:
                    return $"### {_text}";
                case HeaderType.H4:
                    return $"#### {_text}";
                case HeaderType.H5:
                    return $"##### {_text}";
                case HeaderType.H6:
                    return $"###### {_text}";
                default:
                    return "";
            }
        }
    }
}

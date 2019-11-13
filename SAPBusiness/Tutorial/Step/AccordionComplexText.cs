namespace SAPBusiness.Tutorial.Step
{
    using System.Collections.Generic;

    public class AccordionComplexText : AccordionBaseText, IAccordion
    {
        protected List<AccordionComponent> _components;

        public AccordionComplexText(string text)
            : base(text)
        {
        }

        public void AddComponent(AccordionComponent component)
        {
            _components.Add(component);
        }

        public override string FormatView()
        {
            string result = "";

            foreach (var component in _components)
            {
                result += $" {component.FormatView()}, ";
            }

            result = result.Remove(result.Length - 2, 2);

            return result;
        }
    }
}

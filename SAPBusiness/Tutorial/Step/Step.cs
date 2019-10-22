using System.Collections.Generic;
using System.Text;

namespace SAPBusiness.Tutorial.Step
{
    public class Step : AccordionComponent, IAccordion
    {
        private List<AccordionComponent> _components;

        public void AddComponent(AccordionComponent component)
        {
            _components.Add(component);
        }

        public override string FormatView()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var component in _components)
            {
                builder.Append(component.FormatView());
            }

            return builder.ToString();
        }
    }
}

namespace SAPBusiness.Tutorial.Step
{
    using System.Collections.Generic;

    public abstract class AccordionCompositeComponent : AccordionComponent, IAccordion
    {
        protected List<AccordionComponent> _components;

        public AccordionCompositeComponent()
        {
            _components = new List<AccordionComponent>();
        }

        public void AddComponent(AccordionComponent component)
        {
            _components.Add(component);
        }
    }
}

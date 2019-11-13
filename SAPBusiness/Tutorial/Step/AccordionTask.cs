namespace SAPBusiness.Tutorial.Step
{
    using System;
    using SAPBusiness.Enums;

    public class AccordionTask : AccordionCompositeComponent, IAccordion
    {
        private readonly AccordionTaskType _type;

        public AccordionTask(AccordionTaskType type)
        {
            _type = type;
        }

        public override string FormatView()
        {
            string result = "";

            foreach (var task in _components)
            {
                result += $" {task.FormatView()}, ";
            }

            result = result.Remove(result.Length - 2, 2);

            switch (_type)
            {
                case AccordionTaskType.Complete:
                    return $"- [x] {result}\n";
                case AccordionTaskType.Incomplete:
                    return $"- [] {result}\n";
                default:
                    throw new Exception("Accordion task type was wrong");
            }
        }
    }
}

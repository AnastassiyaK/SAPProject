namespace SAPBusiness.Tutorial.Step
{
    using System.Collections.Generic;

    public class AccordionTaskList : AccordionComponent
    {
        private List<AccordionTask> _tasks;

        public AccordionTaskList()
        {
            _tasks = new List<AccordionTask>();
        }

        public AccordionComponent AddTask(AccordionTask component)
        {
            _tasks.Add(component);
            return this;
        }

        public override string FormatView()
        {
            string result = "";
            foreach (var task in _tasks)
            {
                result += $"{task.FormatView()}\n\n";
            }

            return result;
        }
    }
}

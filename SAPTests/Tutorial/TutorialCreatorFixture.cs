namespace SAPTests.Tutorial
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using SAPBusiness.Enums;
    using SAPBusiness.Tutorial;
    using SAPBusiness.Tutorial.Step;
    using FileTutorial = SAPBusiness.Tutorial.Tutorial;

    [Category("TutorialCreatorFixture")]
    [Parallelizable(ParallelScope.All)]
    public class TutorialCreatorFixture
    {
        [Test]
        public void GenerateFile()
        {
            AccordionStep taskListStep = new AccordionStep(1, "Task list in body");

            taskListStep.AddComponent(CreateCompleteComplexTask());
            taskListStep.AddComponent(CreateCompleteSimpleTask());
            taskListStep.AddComponent(CreateIncompleteTask());

            AccordionStep headersStep = new AccordionStep(2, "Headers in body");

            headersStep.AddComponent(new AccordionHeader(HeaderType.H1, new AccordionSimpleText("This is header")));
            headersStep.AddComponent(new AccordionHeader(HeaderType.H2, new AccordionSimpleText("This is header")));
            headersStep.AddComponent(new AccordionHeader(HeaderType.H6, new AccordionSimpleText("This is header")));

            AccordionStep linkStep = new AccordionStep(3, "Link(s) in body");

            linkStep.AddComponent(new AccordionSimpleText("Some text "));
            linkStep.AddComponent(new AccordionLink("name", "https://g23"));

            AccordionStep bulletStep = new AccordionStep(4, "Bullet in body");

            bulletStep.AddComponent(new AccordionBullet("My first bullet"));

            List<AccordionStep> steps = new List<AccordionStep>()
            {
                taskListStep,
                headersStep,
                linkStep,
                bulletStep
            };

            FileTutorial tutorial = new FileTutorial();
            tutorial.Add(steps);

            MDFileCreator fileCreator = new MDFileCreator();
            fileCreator.SaveInFile("newTutorial", tutorial);
        }

        private AccordionComponent CreateCompleteSimpleTask()
        {
            AccordionTask accordionTaskComplete = new AccordionTask(AccordionTaskType.Complete);
            accordionTaskComplete.AddComponent(new AccordionSimpleText("this is a complete item"));

            return accordionTaskComplete;
        }

        private AccordionTask CreateIncompleteTask()
        {
            AccordionTask accordionTaskInComplete = new AccordionTask(AccordionTaskType.Incomplete);
            accordionTaskInComplete.AddComponent(new AccordionSimpleText("this is an incomplete item"));
            return accordionTaskInComplete;
        }

        private AccordionTask CreateCompleteComplexTask()
        {
            AccordionTask accordionTaskComplete = new AccordionTask(AccordionTaskType.Complete);

            accordionTaskComplete.AddComponent(new AccordionTag("my tag"));
            accordionTaskComplete.AddComponent(new AccordionReference("reference"));
            accordionTaskComplete.AddComponent(new AccordionMention("mention"));
            accordionTaskComplete.AddComponent(new AccordionLink("name", "https://github.com"));
            accordionTaskComplete.AddComponent(new AccordionSimpleText("formatting").ToBold());

            return accordionTaskComplete;
        }
    }
}

namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class ProjectCardNotFoundException : Exception
    {
        public ProjectCardNotFoundException(string message)
          : base($"ProjectCard with title '{message}' was not found")
        {
        }
    }
}

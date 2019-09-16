using System;

namespace SAPBusiness.WEB.Exceptions
{
    public class ProjectCardNotFoundException : Exception
    {
        public ProjectCardNotFoundException(string message)
          : base($"ProjectCard with title '{message}' was not found")
        {
        }
    }
}

using System; 

namespace Ensco.Irma.Business.Workflow
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultRequestVerbAttribute : Attribute
    {
        public DefaultRequestVerbAttribute(string verb)
        {
            Verb = verb;
        }

        public string Verb { get; set; }
    }
}

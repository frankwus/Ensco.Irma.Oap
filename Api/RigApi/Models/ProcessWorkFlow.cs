using System;

namespace Ensco.Irma.Oap.Api.Rig.Models
{
    public class ProcessWorkFlow
    {
        public ProcessWorkFlow(Guid checklist, int user, string transition, string comment = "", int order = 0)
        {
            Checklist = checklist;
            User = user;
            Transition = transition;
            Comment = comment;
            Order = order;
        }

        public Guid Checklist { get; private set; }

        public int User { get; private set; }

        public string Transition { get; private set; }

        public string Comment { get; private set; }
        public int Order { get; set; }
    }
}
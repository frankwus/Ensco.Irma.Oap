using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Models
{
    public class StartWorkFlow
    {
        public StartWorkFlow(Guid checklist, int owner)
        {
            Checklist = checklist;
            Owner = owner;
        }

        public Guid Checklist { get; private set; }

        public int Owner { get; private set; }
    }
}
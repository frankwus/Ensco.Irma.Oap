using Ensco.Irma.Interfaces.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ensco.Irma.Models.Domain.Workflow
{
    [Serializable]
    public abstract class WorkflowRequest : Entity<int>
    {
    }
}

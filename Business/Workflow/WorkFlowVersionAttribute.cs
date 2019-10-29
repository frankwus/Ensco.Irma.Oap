using System.Text;
using System.Collections.Generic;
using System;

namespace Business.Workflow
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited=true)]
    public class WorkFlowVersionAttribute:Attribute
    {
        public WorkFlowVersionAttribute(string oldversion,string currentVersion,string previousWorkFlowFileName)
        {
            OldVersion = new Version(oldversion);
            CurrentVersion = new Version(currentVersion);
            PreviousWorkFlowFileName = previousWorkFlowFileName;
        }

        public Version OldVersion { get; set; }
        public Version CurrentVersion { get; set; }
        public string PreviousWorkFlowFileName { get; set; }
    }
}
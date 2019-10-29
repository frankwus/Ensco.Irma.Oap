namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddChecklistEndDateISMCertifiedColumnsInRigOapChecklist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_RigOapChecklists", "ChecklistDateTimeCompleted", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Oap_RigOapChecklists", "ISMCertified", c => c.String());
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.String(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetRigId()", newValue: null)
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
            DropColumn("dbo.Oap_RigOapChecklists", "ISMCertified");
            DropColumn("dbo.Oap_RigOapChecklists", "ChecklistDateTimeCompleted");
        }
    }
}

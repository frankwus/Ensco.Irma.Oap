namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRigIdRequiredOnDatabaseOnly : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.String(nullable: false, annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.String(annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
        }
    }
}

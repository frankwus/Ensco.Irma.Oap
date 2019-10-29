namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultRigIdValuesToEquipmentsReviewerAndWI : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_OapChecklistWorkInstructions", "RigId", c => c.String(
                nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistEquipments", "RigId", c => c.String(
                nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistReviewers", "RigId", c => c.String(
                nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_OapChecklistReviewers", "RigId", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetRigId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistEquipments", "RigId", c => c.Int(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetRigId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistWorkInstructions", "RigId", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetRigId()", newValue: null)
                    },
                }));
        }
    }
}

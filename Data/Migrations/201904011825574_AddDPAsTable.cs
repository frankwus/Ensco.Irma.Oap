namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddDPAsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_DPAs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AssignedRigId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.AssignedRigId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Oap_DPAs", new[] { "AssignedRigId" });
            DropTable("dbo.Oap_DPAs",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "SiteId",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "dbo.fn_GetSiteId()" },
                        }
                    },
                });
        }
    }
}

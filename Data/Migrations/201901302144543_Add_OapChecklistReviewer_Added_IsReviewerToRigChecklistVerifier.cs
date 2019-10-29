namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_OapChecklistReviewer_Added_IsReviewerToRigChecklistVerifier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_OapChecklistReviewers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OapChecklistId = c.Int(nullable: false),
                        ReviewerPositionId = c.Int(nullable: false),
                        RigId = c.Int(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        BusinessUnitId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapChecklists", t => t.OapChecklistId, cascadeDelete: false)
                .Index(t => t.OapChecklistId);
            
            AddColumn("dbo.Oap_RigOapChecklistVerifiers", "isReviewer", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_OapChecklistReviewers", "OapChecklistId", "dbo.Oap_OapChecklists");
            DropIndex("dbo.Oap_OapChecklistReviewers", new[] { "OapChecklistId" });
            DropColumn("dbo.Oap_RigOapChecklistVerifiers", "isReviewer");
            DropTable("dbo.Oap_OapChecklistReviewers");
        }
    }
}

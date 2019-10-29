namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRigThirdPartyJobAndWorkInstructions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_RigOapChecklistThirdPartyJobs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RigOapChecklistId = c.Guid(nullable: false),
                        JodId = c.Int(nullable: false),
                        ThirdPartyCount = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_RigOapChecklists", t => t.RigOapChecklistId, cascadeDelete: true)
                .Index(t => t.RigOapChecklistId);
            
            CreateTable(
                "dbo.Oap_RigOapChecklistWorkInstructions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RigOapChecklistId = c.Guid(nullable: false),
                        WorkInstructionId = c.Int(nullable: false),
                        Comment = c.String(),
                        Value = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapChecklistWorkInstructions", t => t.WorkInstructionId, cascadeDelete: false)
                .ForeignKey("dbo.Oap_RigOapChecklists", t => t.RigOapChecklistId, cascadeDelete: true)
                .Index(t => t.RigOapChecklistId)
                .Index(t => t.WorkInstructionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistWorkInstructions", "RigOapChecklistId", "dbo.Oap_RigOapChecklists");
            DropForeignKey("dbo.Oap_RigOapChecklistWorkInstructions", "WorkInstructionId", "dbo.Oap_OapChecklistWorkInstructions");
            DropForeignKey("dbo.Oap_RigOapChecklistThirdPartyJobs", "RigOapChecklistId", "dbo.Oap_RigOapChecklists");
            DropIndex("dbo.Oap_RigOapChecklistWorkInstructions", new[] { "WorkInstructionId" });
            DropIndex("dbo.Oap_RigOapChecklistWorkInstructions", new[] { "RigOapChecklistId" });
            DropIndex("dbo.Oap_RigOapChecklistThirdPartyJobs", new[] { "RigOapChecklistId" });
            DropTable("dbo.Oap_RigOapChecklistWorkInstructions");
            DropTable("dbo.Oap_RigOapChecklistThirdPartyJobs");
        }
    }
}

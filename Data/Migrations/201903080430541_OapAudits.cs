namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OapAudits : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_OapAuditProtocols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuditId = c.Int(nullable: false),
                        RigOapCheckListId = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapAudits", t => t.AuditId, cascadeDelete: true)
                .ForeignKey("dbo.Oap_RigOapChecklists", t => t.RigOapCheckListId, cascadeDelete: true)
                .Index(t => t.AuditId)
                .Index(t => t.RigOapCheckListId);
            
            CreateTable(
                "dbo.Oap_OapAudits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 1024),
                        AuditLevel = c.String(nullable: false, maxLength: 64),
                        IsCVT = c.Boolean(nullable: false),
                        RepeatFinding = c.Boolean(nullable: false),
                        Status = c.String(maxLength: 16),
                        AuditPurpose = c.String(maxLength: 128),
                        RigId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oap_OapAuditRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuditId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Edit = c.Boolean(nullable: false),
                        ReadOnly = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapAudits", t => t.AuditId, cascadeDelete: true)
                .Index(t => t.AuditId);
            AddForeignKey("dbo.Oap_OapAuditRights", "UserId", "dbo.Master_Users", "Id");
            AddForeignKey("dbo.Oap_OapAudits", "RigId", "dbo.Master_Rig", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_OapAuditRights", "UserId", "dbo.Master_User");
            DropForeignKey("dbo.Oap_OapAudits", "RigId", "dbo.Master_Rig");
            DropForeignKey("dbo.Oap_OapAuditProtocols", "RigOapCheckListId", "dbo.Oap_RigOapChecklists");
            DropForeignKey("dbo.Oap_OapAuditRights", "AuditId", "dbo.Oap_OapAudits");
            DropForeignKey("dbo.Oap_OapAuditProtocols", "AuditId", "dbo.Oap_OapAudits");
            DropIndex("dbo.Oap_OapAuditRights", new[] { "AuditId" });
            DropIndex("dbo.Oap_OapAuditProtocols", new[] { "RigOapCheckListId" });
            DropIndex("dbo.Oap_OapAuditProtocols", new[] { "AuditId" });
            DropTable("dbo.Oap_OapAuditRights");
            DropTable("dbo.Oap_OapAudits");
            DropTable("dbo.Oap_OapAuditProtocols");
        }
    }
}

namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_ADM_WorkIngInstructions_Equiment_System_SubSystem_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_OapAssetDataManagements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OapChecklistGroupId = c.Int(nullable: false),
                        OapSystemId = c.Int(nullable: false),
                        OapSubSystemId = c.Int(),
                        Description = c.String(nullable: false, maxLength: 1092),
                        Order = c.Int(nullable: false),
                        SafetyCritical = c.Boolean(nullable: false),
                        OperationalCritical = c.Boolean(nullable: false),
                        ClientCritical = c.Boolean(nullable: false),
                        EnvironmentalCritical = c.Boolean(nullable: false),
                        NonCritical = c.Boolean(nullable: false),
                        ACritical = c.Boolean(nullable: false),
                        ReferenceId = c.String(nullable: false, maxLength: 128),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapChecklistGroups", t => t.OapChecklistGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Oap_OapSubSystems", t => t.OapSubSystemId)
                .ForeignKey("dbo.Oap_OapSystems", t => t.OapSystemId, cascadeDelete: true)
                .Index(t => t.OapChecklistGroupId)
                .Index(t => t.OapSystemId)
                .Index(t => t.OapSubSystemId);
            
            CreateTable(
                "dbo.Oap_OapSubSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false, maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 1092),
                        OapSystemId = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapSystems", t => t.OapSystemId, cascadeDelete: true)
                .Index(t => t.OapSystemId);
            
            CreateTable(
                "dbo.Oap_OapSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false, maxLength: 32),
                        Description = c.String(nullable: false, maxLength: 1092),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oap_OapChecklistEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RigId = c.Int(nullable: false),
                        OapChecklistId = c.Int(nullable: false),
                        OapEquipmentId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1092),
                        Order = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapChecklists", t => t.OapChecklistId, cascadeDelete: true)
                .ForeignKey("dbo.Oap_OapEquipments", t => t.OapEquipmentId, cascadeDelete: true)
                .Index(t => t.OapChecklistId)
                .Index(t => t.OapEquipmentId);
            
            CreateTable(
                "dbo.Oap_OapEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 1092),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oap_OapChecklistWorkInstructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RigId = c.Int(nullable: false),
                        OapChecklistId = c.Int(nullable: false),
                        OapWorkInstructionId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1092),
                        Order = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapChecklists", t => t.OapChecklistId, cascadeDelete: true)
                .ForeignKey("dbo.Oap_OapWorkInstructions", t => t.OapWorkInstructionId, cascadeDelete: true)
                .Index(t => t.OapChecklistId)
                .Index(t => t.OapWorkInstructionId);
            
            CreateTable(
                "dbo.Oap_OapWorkInstructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        InstructionNumber = c.String(nullable: false, maxLength: 128),
                        ReferenceId = c.String(nullable: false, maxLength: 128),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_OapChecklistWorkInstructions", "OapWorkInstructionId", "dbo.Oap_OapWorkInstructions");
            DropForeignKey("dbo.Oap_OapChecklistWorkInstructions", "OapChecklistId", "dbo.Oap_OapChecklists");
            DropForeignKey("dbo.Oap_OapChecklistEquipments", "OapEquipmentId", "dbo.Oap_OapEquipments");
            DropForeignKey("dbo.Oap_OapChecklistEquipments", "OapChecklistId", "dbo.Oap_OapChecklists");
            DropForeignKey("dbo.Oap_OapAssetDataManagements", "OapSystemId", "dbo.Oap_OapSystems");
            DropForeignKey("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", "dbo.Oap_OapSubSystems");
            DropForeignKey("dbo.Oap_OapSubSystems", "OapSystemId", "dbo.Oap_OapSystems");
            DropForeignKey("dbo.Oap_OapAssetDataManagements", "OapChecklistGroupId", "dbo.Oap_OapChecklistGroups");
            DropIndex("dbo.Oap_OapChecklistWorkInstructions", new[] { "OapWorkInstructionId" });
            DropIndex("dbo.Oap_OapChecklistWorkInstructions", new[] { "OapChecklistId" });
            DropIndex("dbo.Oap_OapChecklistEquipments", new[] { "OapEquipmentId" });
            DropIndex("dbo.Oap_OapChecklistEquipments", new[] { "OapChecklistId" });
            DropIndex("dbo.Oap_OapSubSystems", new[] { "OapSystemId" });
            DropIndex("dbo.Oap_OapAssetDataManagements", new[] { "OapSubSystemId" });
            DropIndex("dbo.Oap_OapAssetDataManagements", new[] { "OapSystemId" });
            DropIndex("dbo.Oap_OapAssetDataManagements", new[] { "OapChecklistGroupId" });
            DropTable("dbo.Oap_OapWorkInstructions");
            DropTable("dbo.Oap_OapChecklistWorkInstructions");
            DropTable("dbo.Oap_OapEquipments");
            DropTable("dbo.Oap_OapChecklistEquipments");
            DropTable("dbo.Oap_OapSystems");
            DropTable("dbo.Oap_OapSubSystems");
            DropTable("dbo.Oap_OapAssetDataManagements");
        }
    }
}

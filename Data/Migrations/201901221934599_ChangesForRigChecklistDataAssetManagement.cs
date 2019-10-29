namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesForRigChecklistDataAssetManagement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oap_OapAssetDataManagements", "OapSystemId", "dbo.Oap_OapSystems");
            DropForeignKey("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", "dbo.Oap_OapSubSystems");
            DropIndex("dbo.Oap_OapAssetDataManagements", new[] { "OapSystemId" });
            DropIndex("dbo.Oap_OapAssetDataManagements", new[] { "OapSubSystemId" });
            CreateTable(
                "dbo.Oap_OapSystemGroups",
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
                "dbo.Oap_RigOapChecklistGroupAssets",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RigOapChecklistId = c.Guid(nullable: false),
                        AssetId = c.Int(nullable: false),
                        Value = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_OapAssetDataManagements", t => t.AssetId, cascadeDelete: false)
                .ForeignKey("dbo.Oap_RigOapChecklists", t => t.RigOapChecklistId, cascadeDelete: true)
                .Index(t => t.RigOapChecklistId)
                .Index(t => t.AssetId);
            
            AddColumn("dbo.Oap_OapChecklistSubGroups", "IsPlantMonitoring", c => c.Boolean(nullable: false));
            AddColumn("dbo.Oap_OapChecklistSubGroups", "IsPlantMaintaining", c => c.Boolean(nullable: false));
            AddColumn("dbo.Oap_OapChecklistSubGroups", "IsWorkInstructions", c => c.Boolean(nullable: false));
            AddColumn("dbo.Oap_OapChecklistSubGroups", "IsThirdPartyActivities", c => c.Boolean(nullable: false));
            AddColumn("dbo.Oap_OapSystems", "SystemGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Oap_OapAssetDataManagements", "OapSubSystemId");
            CreateIndex("dbo.Oap_OapSystems", "SystemGroupId");
            AddForeignKey("dbo.Oap_OapSystems", "SystemGroupId", "dbo.Oap_OapSystemGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", "dbo.Oap_OapSubSystems", "Id", cascadeDelete: true);
            DropColumn("dbo.Oap_OapAssetDataManagements", "OapSystemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oap_OapAssetDataManagements", "OapSystemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", "dbo.Oap_OapSubSystems");
            DropForeignKey("dbo.Oap_RigOapChecklistGroupAssets", "RigOapChecklistId", "dbo.Oap_RigOapChecklists");
            DropForeignKey("dbo.Oap_RigOapChecklistGroupAssets", "AssetId", "dbo.Oap_OapAssetDataManagements");
            DropForeignKey("dbo.Oap_OapSystems", "SystemGroupId", "dbo.Oap_OapSystemGroups");
            DropIndex("dbo.Oap_RigOapChecklistGroupAssets", new[] { "AssetId" });
            DropIndex("dbo.Oap_RigOapChecklistGroupAssets", new[] { "RigOapChecklistId" });
            DropIndex("dbo.Oap_OapSystems", new[] { "SystemGroupId" });
            DropIndex("dbo.Oap_OapAssetDataManagements", new[] { "OapSubSystemId" });
            AlterColumn("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", c => c.Int());
            DropColumn("dbo.Oap_OapSystems", "SystemGroupId");
            DropColumn("dbo.Oap_OapChecklistSubGroups", "IsThirdPartyActivities");
            DropColumn("dbo.Oap_OapChecklistSubGroups", "IsWorkInstructions");
            DropColumn("dbo.Oap_OapChecklistSubGroups", "IsPlantMaintaining");
            DropColumn("dbo.Oap_OapChecklistSubGroups", "IsPlantMonitoring");
            DropTable("dbo.Oap_RigOapChecklistGroupAssets");
            DropTable("dbo.Oap_OapSystemGroups");
            CreateIndex("dbo.Oap_OapAssetDataManagements", "OapSubSystemId");
            CreateIndex("dbo.Oap_OapAssetDataManagements", "OapSystemId");
            AddForeignKey("dbo.Oap_OapAssetDataManagements", "OapSubSystemId", "dbo.Oap_OapSubSystems", "Id");
            AddForeignKey("dbo.Oap_OapAssetDataManagements", "OapSystemId", "dbo.Oap_OapSystems", "Id", cascadeDelete: true);
        }
    }
}

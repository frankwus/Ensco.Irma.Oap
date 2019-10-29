namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRigOapChecklistFindingToRigOapChecklistQuestionFinding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistFindings", "FindingSubTypeId", "dbo.Oap_FindingSubTypes");
            DropForeignKey("dbo.Oap_RigOapChecklistFindings", "FindingTypeId", "dbo.Oap_FindingTypes");
            DropForeignKey("dbo.Oap_RigOapChecklistFindings", "OapChecklistQuestionId", "dbo.Oap_OapChecklistQuestions");
            DropForeignKey("dbo.Oap_RigOapChecklistFindings", "RigOapChecklistId", "dbo.Oap_RigOapChecklists");
            DropIndex("dbo.Oap_RigOapChecklistFindings", new[] { "FindingTypeId" });
            DropIndex("dbo.Oap_RigOapChecklistFindings", new[] { "FindingSubTypeId" });
            DropIndex("dbo.Oap_RigOapChecklistFindings", new[] { "OapChecklistQuestionId" });
            DropIndex("dbo.Oap_RigOapChecklistFindings", new[] { "RigOapChecklistId" });
            CreateTable(
                "dbo.Oap_RigOapChecklistQuestionFindings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Reason = c.String(nullable: false),
                        CriticalityId = c.Int(nullable: false),
                        FindingDate = c.DateTime(nullable: false),
                        FindingTypeId = c.Int(nullable: false),
                        FindingSubTypeId = c.Int(nullable: false),
                        CapaId = c.Int(nullable: false),
                        RigOapChecklistQuestionId = c.Guid(nullable: false),
                        Status = c.String(maxLength: 32),
                        IsRepeat = c.Boolean(nullable: false),
                        AssignedUserId = c.Int(nullable: false),
                        File = c.String(),
                        ReviewedByUserId = c.Int(nullable: false),
                        RigChecklistFindingInternalId = c.Int(nullable: false, identity: true),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_FindingSubTypes", t => t.FindingSubTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Oap_FindingTypes", t => t.FindingTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Oap_RigOapChecklistQuestions", t => t.RigOapChecklistQuestionId, cascadeDelete: true)
                .Index(t => t.FindingTypeId)
                .Index(t => t.FindingSubTypeId)
                .Index(t => t.RigOapChecklistQuestionId);
            
            AddColumn("dbo.Oap_RigOapChecklists", "Reason", c => c.String(maxLength: 128));
            DropColumn("dbo.Oap_RigOapChecklists", "TimeSpenOnObservation");
            DropColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleContacted");
            DropColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleObserved");
            DropTable("dbo.Oap_RigOapChecklistFindings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Oap_RigOapChecklistFindings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Reason = c.String(nullable: false),
                        Criticality = c.Int(nullable: false),
                        FindingDate = c.DateTime(nullable: false),
                        FindingTypeId = c.Int(nullable: false),
                        FindingSubTypeId = c.Int(nullable: false),
                        OapChecklistQuestionId = c.Int(nullable: false),
                        CapaId = c.Int(nullable: false),
                        RigOapChecklistId = c.Guid(),
                        Status = c.String(maxLength: 32),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleObserved", c => c.Int());
            AddColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleContacted", c => c.Int());
            AddColumn("dbo.Oap_RigOapChecklists", "TimeSpenOnObservation", c => c.Int());
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionFindings", "RigOapChecklistQuestionId", "dbo.Oap_RigOapChecklistQuestions");
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionFindings", "FindingTypeId", "dbo.Oap_FindingTypes");
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionFindings", "FindingSubTypeId", "dbo.Oap_FindingSubTypes");
            DropIndex("dbo.Oap_RigOapChecklistQuestionFindings", new[] { "RigOapChecklistQuestionId" });
            DropIndex("dbo.Oap_RigOapChecklistQuestionFindings", new[] { "FindingSubTypeId" });
            DropIndex("dbo.Oap_RigOapChecklistQuestionFindings", new[] { "FindingTypeId" });
            DropColumn("dbo.Oap_RigOapChecklists", "Reason");
            DropTable("dbo.Oap_RigOapChecklistQuestionFindings");
            CreateIndex("dbo.Oap_RigOapChecklistFindings", "RigOapChecklistId");
            CreateIndex("dbo.Oap_RigOapChecklistFindings", "OapChecklistQuestionId");
            CreateIndex("dbo.Oap_RigOapChecklistFindings", "FindingSubTypeId");
            CreateIndex("dbo.Oap_RigOapChecklistFindings", "FindingTypeId");
            AddForeignKey("dbo.Oap_RigOapChecklistFindings", "RigOapChecklistId", "dbo.Oap_RigOapChecklists", "Id");
            AddForeignKey("dbo.Oap_RigOapChecklistFindings", "OapChecklistQuestionId", "dbo.Oap_OapChecklistQuestions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Oap_RigOapChecklistFindings", "FindingTypeId", "dbo.Oap_FindingTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Oap_RigOapChecklistFindings", "FindingSubTypeId", "dbo.Oap_FindingSubTypes", "Id", cascadeDelete: true);
        }
    }
}

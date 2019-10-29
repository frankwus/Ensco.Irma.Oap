namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOapChecklistQuestionDataTypeAndFrequency : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_OapChecklistQuestionDataTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Code = c.String(maxLength: 10),
                        Description = c.String(maxLength: 1024),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Oap_OapFrequencys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 1024),
                        NumberOfDays = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Oap_OapChecklistQuestions", "Section", c => c.String(maxLength: 128));
            AddColumn("dbo.Oap_OapChecklistQuestions", "Criticality", c => c.String(maxLength: 128));
            AddColumn("dbo.Oap_OapChecklistQuestions", "BasicCauseClassification", c => c.String(maxLength: 128));
            AddColumn("dbo.Oap_OapChecklistQuestions", "OapFrequencyId", c => c.Int());
            AddColumn("dbo.Oap_OapChecklistQuestions", "OapChecklistQuestionDataTypeId", c => c.Int());
            CreateIndex("dbo.Oap_OapChecklistQuestions", "OapFrequencyId");
            CreateIndex("dbo.Oap_OapChecklistQuestions", "OapChecklistQuestionDataTypeId");
            AddForeignKey("dbo.Oap_OapChecklistQuestions", "OapChecklistQuestionDataTypeId", "dbo.Oap_OapChecklistQuestionDataTypes", "Id");
            AddForeignKey("dbo.Oap_OapChecklistQuestions", "OapFrequencyId", "dbo.Oap_OapFrequencys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_OapChecklistQuestions", "OapFrequencyId", "dbo.Oap_OapFrequencys");
            DropForeignKey("dbo.Oap_OapChecklistQuestions", "OapChecklistQuestionDataTypeId", "dbo.Oap_OapChecklistQuestionDataTypes");
            DropIndex("dbo.Oap_OapChecklistQuestions", new[] { "OapChecklistQuestionDataTypeId" });
            DropIndex("dbo.Oap_OapChecklistQuestions", new[] { "OapFrequencyId" });
            DropColumn("dbo.Oap_OapChecklistQuestions", "OapChecklistQuestionDataTypeId");
            DropColumn("dbo.Oap_OapChecklistQuestions", "OapFrequencyId");
            DropColumn("dbo.Oap_OapChecklistQuestions", "BasicCauseClassification");
            DropColumn("dbo.Oap_OapChecklistQuestions", "Criticality");
            DropColumn("dbo.Oap_OapChecklistQuestions", "Section");
            DropTable("dbo.Oap_OapFrequencys");
            DropTable("dbo.Oap_OapChecklistQuestionDataTypes");
        }
    }
}

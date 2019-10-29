namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRigOapChecklistQuestionNoAnswerComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_RigOapChecklistQuestionNoAnswerComments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RigOapChecklistQuestionId = c.Guid(nullable: false),
                        OapChecklistQuestionCommentId = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, maxLength: 2048),
                        StartCommentBy = c.Int(nullable: false),
                        EndCommentBy = c.Int(nullable: false),
                        Correction = c.String(maxLength: 2048),
                        IsStopWorkAuthorityExercised = c.Boolean(nullable: false),
                        WasAbletoCorrectImmediately = c.Boolean(nullable: false),
                        EvidenceFilePath = c.String(maxLength: 512),
                        StartDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_RigOapChecklistQuestions", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Oap_RigOapChecklistQuestions", "NoAnswerCommentId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", "dbo.Oap_RigOapChecklistQuestions");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", new[] { "Id" });
            DropColumn("dbo.Oap_RigOapChecklistQuestions", "NoAnswerCommentId");
            DropTable("dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
        }
    }
}

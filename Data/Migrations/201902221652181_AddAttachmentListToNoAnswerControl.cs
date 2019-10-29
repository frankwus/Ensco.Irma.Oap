namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttachmentListToNoAnswerControl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                        RigOapChecklistQuestionNoAnswerCommentId = c.Guid(nullable: false),
                        Common_AttachmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", t => t.RigOapChecklistQuestionNoAnswerCommentId, cascadeDelete: true)
                .Index(t => t.RigOapChecklistQuestionNoAnswerCommentId);
            
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "AttachmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "AttachmentId", c => c.Int());
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", new[] { "RigOapChecklistQuestionNoAnswerCommentId" });
            DropTable("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments");
        }
    }
}

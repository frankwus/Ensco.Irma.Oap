namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNoAnswerAttachmentsModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", new[] { "RigOapChecklistQuestionNoAnswerCommentId" });
            DropTable("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", cascadeDelete: true);
        }
    }
}

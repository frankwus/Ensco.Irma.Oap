namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoAnswerKeyChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            DropPrimaryKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            DropPrimaryKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerAttachments", "RigOapChecklistQuestionNoAnswerCommentId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", cascadeDelete: true);
        }
    }
}

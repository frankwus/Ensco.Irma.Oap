namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixKeysNoAnswerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id", "dbo.Oap_OapChecklistQuestions");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", new[] { "OapChecklistQuestion_Id" });
            RenameColumn(table: "dbo.Oap_RigOapChecklistQuestionNoAnswerComments", name: "OapChecklistQuestion_Id", newName: "OapChecklistQuestionId");
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionId");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionId", "dbo.Oap_OapChecklistQuestions", "Id", cascadeDelete: true);
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionCommentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionCommentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionId", "dbo.Oap_OapChecklistQuestions");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", new[] { "OapChecklistQuestionId" });
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestionId", c => c.Int());
            RenameColumn(table: "dbo.Oap_RigOapChecklistQuestionNoAnswerComments", name: "OapChecklistQuestionId", newName: "OapChecklistQuestion_Id");
            CreateIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id", "dbo.Oap_OapChecklistQuestions", "Id");
        }
    }
}

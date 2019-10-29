namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSourceChecklistAndForeignKeysToNoAnswerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "RigOapChecklistQuestion_Id", "dbo.Oap_RigOapChecklistQuestions");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", new[] { "RigOapChecklistQuestion_Id" });
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "SourceRigOapChecklistId", c => c.Guid());
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "ClosureRigOapChecklistId", c => c.Guid());
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id", c => c.Int());
            CreateIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id", "dbo.Oap_OapChecklistQuestions", "Id");
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "RigOapChecklistQuestion_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "RigOapChecklistQuestion_Id", c => c.Guid());
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id", "dbo.Oap_OapChecklistQuestions");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", new[] { "OapChecklistQuestion_Id" });
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistQuestion_Id");
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "ClosureRigOapChecklistId");
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "SourceRigOapChecklistId");
            CreateIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "RigOapChecklistQuestion_Id");
            AddForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "RigOapChecklistQuestion_Id", "dbo.Oap_RigOapChecklistQuestions", "Id");
        }
    }
}

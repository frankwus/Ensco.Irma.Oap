namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAttachmentTypeInChecklistNoAnswerComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "AttachmentId", c => c.Int());
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "FileName", c => c.String(maxLength: 512));
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "AttachmentId");
        }
    }
}

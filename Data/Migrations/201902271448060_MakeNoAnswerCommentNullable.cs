namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNoAnswerCommentNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Comment", c => c.String(maxLength: 2048));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Comment", c => c.String(nullable: false, maxLength: 2048));
        }
    }
}

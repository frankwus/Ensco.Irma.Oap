namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RighChecklistAnswerValue_NotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionAnswers", "Value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionAnswers", "Value", c => c.String(nullable: false));
        }
    }
}

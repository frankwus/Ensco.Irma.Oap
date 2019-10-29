namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSWAFieldNullableOnNoAnswer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "IsStopWorkAuthorityExercised", c => c.Boolean());
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "WasAbletoCorrectImmediately", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "WasAbletoCorrectImmediately", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "IsStopWorkAuthorityExercised", c => c.Boolean(nullable: false));
        }
    }
}

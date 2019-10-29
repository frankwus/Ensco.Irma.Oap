namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOapChecklistIdToNoAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "OapChecklistId");
        }
    }
}

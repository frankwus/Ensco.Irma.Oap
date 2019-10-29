namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNoAnswerKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", c => c.Guid(defaultValueSql: "newsequentialid()", nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "Id", c => c.Guid(nullable: false));
        }
    }
}

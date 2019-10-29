namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNoAnswerEndDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "EndDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "EndDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}

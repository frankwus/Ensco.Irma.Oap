namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedEditNoValueAndYesValueType_OAPChecklistQuestion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_OapChecklistQuestions", "YesValue", c => c.Int(nullable: false, defaultValue: 1));
            AlterColumn("dbo.Oap_OapChecklistQuestions", "EditNoValue", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_OapChecklistQuestions", "EditNoValue", c => c.String(maxLength: 16));
            AlterColumn("dbo.Oap_OapChecklistQuestions", "YesValue", c => c.String(maxLength: 16));
        }
    }
}

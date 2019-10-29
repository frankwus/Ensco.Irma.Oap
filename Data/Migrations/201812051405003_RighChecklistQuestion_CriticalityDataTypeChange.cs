namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RighChecklistQuestion_CriticalityDataTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_OapChecklistQuestions", "Criticality", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_OapChecklistQuestions", "Criticality", c => c.String(maxLength: 128));
        }
    }
}

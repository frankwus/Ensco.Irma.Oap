namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRigIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.String());
            AlterColumn("dbo.Oap_OapChecklistWorkInstructions", "RigId", c => c.String());
            AlterColumn("dbo.Oap_OapChecklistReviewers", "RigId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_OapChecklistReviewers", "RigId", c => c.Int(nullable: false));
            AlterColumn("dbo.Oap_OapChecklistWorkInstructions", "RigId", c => c.Int(nullable: false));
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.Int(nullable: false));
        }
    }
}

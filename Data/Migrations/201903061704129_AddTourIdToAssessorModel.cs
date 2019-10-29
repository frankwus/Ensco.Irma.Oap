namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTourIdToAssessorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_RigOapChecklistAssessors", "TourId", c => c.Int());
            AddColumn("dbo.Oap_RigOapChecklistVerifiers", "TourId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oap_RigOapChecklistVerifiers", "TourId");
            DropColumn("dbo.Oap_RigOapChecklistAssessors", "TourId");
        }
    }
}

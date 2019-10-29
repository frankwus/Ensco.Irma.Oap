namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFSOColumnsToRigOapChecklist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_RigOapChecklists", "TimeSpenOnObservation", c => c.Int());
            AddColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleContacted", c => c.Int());
            AddColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleObserved", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleObserved");
            DropColumn("dbo.Oap_RigOapChecklists", "NumberOfPeopleContacted");
            DropColumn("dbo.Oap_RigOapChecklists", "TimeSpenOnObservation");
        }
    }
}

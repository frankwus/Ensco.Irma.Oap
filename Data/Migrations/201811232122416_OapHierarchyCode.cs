namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OapHierarchyCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_OapHierarchys", "Code", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oap_OapHierarchys", "Code");
        }
    }
}

namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageColumnInGraphics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_OapGraphics", "Image", c => c.Binary());
            DropColumn("dbo.Oap_OapGraphics", "ImageLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oap_OapGraphics", "ImageLocation", c => c.String());
            DropColumn("dbo.Oap_OapGraphics", "Image");
        }
    }
}

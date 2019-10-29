namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommentColumntoRigOapQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oap_RigOapChecklistQuestions", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oap_RigOapChecklistQuestions", "Comment");
        }
    }
}

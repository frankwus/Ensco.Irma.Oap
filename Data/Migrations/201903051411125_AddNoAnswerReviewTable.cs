namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoAnswerReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_RigOapChecklistQuestionNoAnswerReviews",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                        NoAnswerId = c.Guid(nullable: false),
                        ReviewerId = c.Int(nullable: false),
                        ReviewDate = c.DateTime(),
                        Comment = c.String(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", t => t.NoAnswerId, cascadeDelete: true)
                .Index(t => t.NoAnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionNoAnswerReviews", "NoAnswerId", "dbo.Oap_RigOapChecklistQuestionNoAnswerComments");
            DropIndex("dbo.Oap_RigOapChecklistQuestionNoAnswerReviews", new[] { "NoAnswerId" });
            DropTable("dbo.Oap_RigOapChecklistQuestionNoAnswerReviews");
        }
    }
}

namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRighChecklistQuestionComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oap_RigOapChecklistQuestionComments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RigOapChecklistQuestionId = c.Guid(nullable: false),
                        OapChecklistQuestionCommentId = c.Int(nullable: false, identity: true),
                        CommentDate = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 2048),
                        CommentBy = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(maxLength: 128),
                        CreatedBy = c.String(maxLength: 128),
                        SiteId = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oap_RigOapChecklistQuestions", t => t.RigOapChecklistQuestionId, cascadeDelete: true)
                .Index(t => t.RigOapChecklistQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oap_RigOapChecklistQuestionComments", "RigOapChecklistQuestionId", "dbo.Oap_RigOapChecklistQuestions");
            DropIndex("dbo.Oap_RigOapChecklistQuestionComments", new[] { "RigOapChecklistQuestionId" });
            DropTable("dbo.Oap_RigOapChecklistQuestionComments");
        }
    }
}

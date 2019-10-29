namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGetSiteIdFunction : DbMigration
    {
        public override void Up()
        {
            Sql(@"IF OBJECT_ID('dbo.fn_GetSiteId') IS NULL
                                                 BEGIN
                                                    exec sp_executesql N'
                                                        CREATE FUNCTION [dbo].[fn_GetSiteId]()  
                                                        RETURNS  varchar(max)
                                                        AS
                                                        BEGIN
                                                        return (select top 1 value from AdminCustom where Name=''SiteId'')
                                                        END'
                                                END");
        }

        public override void Down()
        {
            Sql(@"exec sp_executesql N'DROP FUNCTION [dbo].[fn_GetSiteId]'");
        }
    }
}

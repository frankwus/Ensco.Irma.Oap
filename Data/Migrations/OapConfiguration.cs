namespace Ensco.Irma.Data.Migrations
{
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Data.SqlGenerators;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Models.Domain.Workflow;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Text;

    internal sealed class OapConfiguration : DbMigrationsConfiguration<IrmaOapDbContext>
    {
        public OapConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(IrmaOapDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var genericLayout = AddLayout(context);

            var workflow = AddWorkflow(context, genericLayout);

            AddOapChecklistQuestionDataTypes(context);

            AddOapFrequencies(context);

            AddAdminCustomView(context);

            AddGetRigIdFunction(context);
            AddGetSiteIdFunction(context);

            AddFindingTypesAndSubTypes(context);
        }        

        private void AddFindingTypesAndSubTypes(IrmaOapDbContext context)
        {
            var f1 = new FindingType()
            {
                Name = "Nonconformity",
                SubTypes = new List<FindingSubType>()
                {
                    new FindingSubType
                    {
                        Name =  "Nonconformity"
                    }
                }
            };
             

            var f2 = new FindingType()
            {
                Name = "Major Nonconformity",
                SubTypes = new List<FindingSubType>()
                {
                    new FindingSubType
                    {
                        Name =  "Major Nonconformity"
                    }
                }
            }; 

            var f3 = new FindingType()
            {
                Name = "Observation",
                SubTypes = new List<FindingSubType>()
                {
                    new FindingSubType
                    {
                        Name =  "Observation"
                    }
                }
            };


            var f4 = new FindingType()
            {
                Name = "Recommendation",
                SubTypes = new List<FindingSubType>()
                {
                    new FindingSubType
                    {
                        Name =  "Recommendation"
                    }
                }
            }; 


            context.FindingTypes.AddOrUpdate(f => f.Name, f1);
            context.FindingTypes.AddOrUpdate(f => f.Name, f2);
            context.FindingTypes.AddOrUpdate(f => f.Name, f3);
            context.FindingTypes.AddOrUpdate(f => f.Name, f4);
        }

        private Workflow AddWorkflow(IrmaOapDbContext context, OapChecklistLayout genericLayout)
        {
            var workflow = new Workflow()
            {
                Name = "Genericlist",
                Major = 1,
                Minor = 0,
                ChecklistLayoutId = genericLayout.Id,
                Active = true,
                Assembly = "Ensco.Irma.Services",
                Type = "Ensco.Irma.Services.Workflow.Designers.Genericlist"
            };

             context.Workflows.AddOrUpdate(o => o.Name, workflow);

            return workflow;
        }

        private void AddOapChecklistQuestionDataTypes(IrmaOapDbContext context)
        {
            context.OapChecklistQuestionDataTypes.AddOrUpdate(o => o.Code, new OapChecklistQuestionDataType()
            {
                Name = "RadioButtonList",
                Code = "RBL"
            }); 
            
            context.OapChecklistQuestionDataTypes.AddOrUpdate(o => o.Code, new OapChecklistQuestionDataType()
            {
                Name = "TextBox",
                Code = "TXT"
            }); 
             
            context.OapChecklistQuestionDataTypes.AddOrUpdate(o => o.Code, new OapChecklistQuestionDataType()
            {
                Name = "DropDownList",
                Code = "DDL"
            }); 
        }

        private void AddOapFrequencies(IrmaOapDbContext context)
        {
            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "Daily",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "Weekly",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "Monthly",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "As Required",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "At All Crew Changes",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "Beginning of hitch",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "Prior to each well",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });

            context.OapFrequencies.AddOrUpdate(o => o.Name, new OapFrequency()
            {
                Name = "Twice per hitch",
                StartDateTime = DateTime.MinValue,
                EndDateTime = DateTime.MaxValue
            });
        }

        private OapChecklistLayout AddLayout(IrmaOapDbContext context)
        {
            var layoutColumns = new List<Models.Domain.Oap.Checklist.OapChecklistLayoutColumn>();
            layoutColumns.Add(new Models.Domain.Oap.Checklist.OapChecklistLayoutColumn()
            {
                Name = "Category",
                DisplayName = "Category",
                Description = "Category",
                IsYesNoNa = false,
                YesNoNaPrefix = "",
                CreatedDateTime = DateTime.UtcNow,
                YesNoNaCount = 0,
                UpdatedDateTime = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedBy = "System"
            });

            layoutColumns.Add(new Models.Domain.Oap.Checklist.OapChecklistLayoutColumn()
            {
                Name = "Verification",
                DisplayName = "Verification",
                Description = "Verification",
                IsYesNoNa = false,
                YesNoNaCount = 0,
                YesNoNaPrefix = "",
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedBy = "System"
            });

            layoutColumns.Add(new Models.Domain.Oap.Checklist.OapChecklistLayoutColumn()
            {
                Name = "YesOrNoNa",
                DisplayName = "YesOrNoNa",
                Description = "YesOrNoNa",
                IsYesNoNa = true,
                YesNoNaCount = 1,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedBy = "System"
            });

            var layoutName = "Generic List";

            var layout = new Models.Domain.Oap.Checklist.OapChecklistLayout()
            {
                Name = layoutName,
                Description = "Generic List Layout",
                Columns = layoutColumns,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedBy = "System"
            };

            context.OapChecklistLayouts.AddOrUpdate((o) => o.Name, layout);

            return layout;
        }

        private void AddAdminCustomView(IrmaOapDbContext context)
        {
            var sb = new StringBuilder();
            sb.AppendLine("If NOT  EXISTS(Select 1 from sys.objects where name = 'vw_AdminCustom' and type = 'V')");
            sb.AppendLine("BEGIN");
            sb.AppendLine("Exec sp_executesql  N'CREATE   view [dbo].[vw_AdminCustom] as select t.Id, a.Name, a.Value from Tbl_Identity t join (select ROW_NUMBER() over (order by name)  as Id, * from AdminCustom) a on a.id=t.id'");
            sb.AppendLine("END");

            context.Database.ExecuteSqlCommand(sb.ToString());
        }

        private void AddGetRigIdFunction(IrmaOapDbContext context)
        {
            context.Database.ExecuteSqlCommand(@"IF OBJECT_ID('dbo.fn_GetRigId') IS NULL
                                                 BEGIN
                                                    exec sp_executesql N'
                                                        CREATE FUNCTION [dbo].[fn_GetRigId]()  
                                                        RETURNS  varchar(max)
                                                        AS
                                                        BEGIN
                                                        return (select top 1 value from AdminCustom where Name=''RigId'')
                                                        END'
                                                END");
        }

        private void AddGetSiteIdFunction(IrmaOapDbContext context)
        {
            context.Database.ExecuteSqlCommand(@"IF OBJECT_ID('dbo.fn_GetSiteId') IS NULL
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

    }
}

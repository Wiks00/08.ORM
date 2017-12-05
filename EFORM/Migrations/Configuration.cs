using System.Net.Mime;

namespace EFORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFORM.Northwind>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EFORM.Northwind";
        }

        protected override void Seed(EFORM.Northwind context)
        {
            context.Categories.AddOrUpdate(category => category.CategoryID, 
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "1",
                    Description = "1"
                }, new Category{
                    CategoryID = 2,
                    CategoryName = "2",
                    Description = "2"
                }, new Category{
                    CategoryID = 3,
                    CategoryName = "3",
                    Description = "3"
                }, new Category{
                    CategoryID = 4,
                    CategoryName = "4",
                    Description = "4"
                }
            );

            context.Regions.AddOrUpdate(region => region.RegionsID, 
                new Regions
                {
                    RegionsID = 1,
                    RegionDescription = "1"
                }, new Regions{
                    RegionsID = 2,
                    RegionDescription = "2"
                }, new Regions{
                    RegionsID = 3,
                    RegionDescription = "3"
                }, new Regions{
                    RegionsID = 4,
                    RegionDescription = "4"
                }
            );

            context.Territories.AddOrUpdate(territory => territory.TerritoryID, 
                new Territory
                {
                    TerritoryID = "01581",
                    TerritoryDescription = "1",
                    RegionID = 1
                }, new Territory
                {
                    TerritoryID = "01730",
                    TerritoryDescription = "2",
                    RegionID = 2
                }, new Territory
                {
                    TerritoryID = "01833",
                    TerritoryDescription = "3",
                    RegionID = 3
                }, new Territory
                {
                    TerritoryID = "02116",
                    TerritoryDescription = "4",
                    RegionID = 4
                }
            );
        }
    }
}

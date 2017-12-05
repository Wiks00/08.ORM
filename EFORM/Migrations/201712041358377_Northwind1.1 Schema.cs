namespace EFORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Northwind11Schema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Northwind.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        ExperationDate = c.DateTime(nullable: false),
                        CardHolder = c.String(nullable: false),
                        Customer_CustomerID = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("Northwind.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Northwind.CreditCards", "Customer_CustomerID", "Northwind.Customers");
            DropIndex("Northwind.CreditCards", new[] { "Customer_CustomerID" });
            DropTable("Northwind.CreditCards");
        }
    }
}

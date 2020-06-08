namespace CurrencyConversionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddCurrencyConversionTableToApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyConversions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Amount = c.Double(nullable: false),
                    ExchangeRate = c.Double(nullable: false),
                    Date = c.DateTime(nullable: false),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }

        public override void Down()
        {
            DropTable("dbo.CurrencyConversions");
        }
    }
}

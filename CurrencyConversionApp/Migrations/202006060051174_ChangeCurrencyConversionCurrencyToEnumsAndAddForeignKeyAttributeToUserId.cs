namespace CurrencyConversionApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCurrencyConversionCurrencyToEnumsAndAddForeignKeyAttributeToUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyConversions", "CurrencyFrom", c => c.Int(nullable: false));
            AddColumn("dbo.CurrencyConversions", "CurrencyTo", c => c.Int(nullable: false));
            AlterColumn("dbo.CurrencyConversions", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CurrencyConversions", "UserId");
            AddForeignKey("dbo.CurrencyConversions", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrencyConversions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CurrencyConversions", new[] { "UserId" });
            AlterColumn("dbo.CurrencyConversions", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.CurrencyConversions", "CurrencyTo");
            DropColumn("dbo.CurrencyConversions", "CurrencyFrom");
        }
    }
}

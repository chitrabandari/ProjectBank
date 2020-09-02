namespace ProjectBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "RetypePassword", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phoneno", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(maxLength: 35));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Phoneno", c => c.String());
            AlterColumn("dbo.Customers", "RetypePassword", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}

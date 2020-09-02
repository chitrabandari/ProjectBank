﻿namespace ProjectBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Phoneno", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Phoneno", c => c.String(nullable: false));
        }
    }
}
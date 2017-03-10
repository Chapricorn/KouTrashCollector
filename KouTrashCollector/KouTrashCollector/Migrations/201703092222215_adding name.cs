namespace KouTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
        }
    }
}

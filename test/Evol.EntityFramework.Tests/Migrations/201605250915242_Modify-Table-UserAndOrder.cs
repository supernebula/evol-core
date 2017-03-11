namespace Evol.EntityFramework.Repository.Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTableUserAndOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FakeUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        RealName = c.String(nullable: false, maxLength: 100),
                        Gender = c.Int(nullable: false),
                        Mobile = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 500),
                        Points = c.Int(nullable: false),
                        PersonHeight = c.Single(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        MarkDelete = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestOrder",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Recipient = c.String(nullable: false, maxLength: 100),
                        Amount = c.Double(nullable: false),
                        Address = c.String(nullable: false, maxLength: 500),
                        Number = c.Int(nullable: false),
                        Remark = c.Int(),
                        MarkDelete = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestOrder");
            DropTable("dbo.FakeUser");
        }
    }
}

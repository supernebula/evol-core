namespace Evol.EntityFramework.Repository.Test.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Price = c.Double(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "商品价格",
                                    new AnnotationValues(oldValue: null, newValue: "value")
                                },
                            }),
                        Picture = c.String(maxLength: 500),
                        SourceUri = c.String(maxLength: 500),
                        Follows = c.Int(nullable: false),
                        SourceSite = c.String(maxLength: 100),
                        Status = c.Int(nullable: false),
                        VisitTotal = c.Int(nullable: false),
                        MarkDelete = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Price",
                        new Dictionary<string, object>
                        {
                            { "商品价格", "value" },
                        }
                    },
                });
        }
    }
}

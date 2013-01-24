namespace OrderProcessingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.OrderDtoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Orders");
        }
    }
}

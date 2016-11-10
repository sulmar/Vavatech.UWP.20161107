namespace AluPlast.ControlLoader.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ItemType = c.Int(nullable: false),
                        IsLoaded = c.Boolean(),
                        Load_LoadId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Loads", t => t.Load_LoadId)
                .Index(t => t.Load_LoadId);
            
            CreateTable(
                "dbo.Loads",
                c => new
                    {
                        LoadId = c.Int(nullable: false, identity: true),
                        LoadDate = c.DateTime(nullable: false),
                        LoadStatus = c.Int(nullable: false),
                        Operator_UserId = c.Int(),
                        Vehicle_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.LoadId)
                .ForeignKey("dbo.Users", t => t.Operator_UserId)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleId)
                .Index(t => t.Operator_UserId)
                .Index(t => t.Vehicle_VehicleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                        Load_LoadId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Loads", t => t.Load_LoadId)
                .Index(t => t.Load_LoadId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loads", "Vehicle_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Photos", "Load_LoadId", "dbo.Loads");
            DropForeignKey("dbo.Loads", "Operator_UserId", "dbo.Users");
            DropForeignKey("dbo.Items", "Load_LoadId", "dbo.Loads");
            DropIndex("dbo.Photos", new[] { "Load_LoadId" });
            DropIndex("dbo.Loads", new[] { "Vehicle_VehicleId" });
            DropIndex("dbo.Loads", new[] { "Operator_UserId" });
            DropIndex("dbo.Items", new[] { "Load_LoadId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Photos");
            DropTable("dbo.Users");
            DropTable("dbo.Loads");
            DropTable("dbo.Items");
        }
    }
}

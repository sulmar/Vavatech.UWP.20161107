namespace AluPlast.ControlLoader.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "Description");
        }
    }
}

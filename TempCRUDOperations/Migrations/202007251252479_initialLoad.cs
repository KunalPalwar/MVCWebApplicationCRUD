namespace TempCRUDOperations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}

namespace FiltersMVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Roles(Name)VALUES('Admin')");
            Sql("INSERT INTO Roles(Name)VALUES('Normal')");
            Sql("INSERT INTO Roles(Name)VALUES('Visiteur')");

            Sql("INSERT INTO Users(UserName,Password,RoleId)VALUES('admin','admin',1)");
            Sql("INSERT INTO Users(UserName,Password,RoleId)VALUES('normal','normal',2)");
            Sql("INSERT INTO Users(UserName,Password,RoleId)VALUES('visiteur','visiteur',3)");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}

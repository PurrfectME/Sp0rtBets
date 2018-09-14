namespace SportBets.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketballTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        WinsCount = c.Int(nullable: false),
                        LossesCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BetItemType = c.Int(nullable: false),
                        Coefficient = c.Double(nullable: false),
                        BetDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FootballTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        WinsCount = c.Int(nullable: false),
                        LossesCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Horses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HorseName = c.String(),
                        Weight = c.Single(nullable: false),
                        Age = c.Int(nullable: false),
                        WinsCount = c.Int(nullable: false),
                        LossesCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "User_Id", "dbo.Users");
            DropIndex("dbo.Bets", new[] { "User_Id" });
            DropTable("dbo.Horses");
            DropTable("dbo.FootballTeams");
            DropTable("dbo.Users");
            DropTable("dbo.Bets");
            DropTable("dbo.BasketballTeams");
        }
    }
}

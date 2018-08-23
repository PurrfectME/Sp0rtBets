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
                "dbo.Betcards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BetDate = c.DateTime(nullable: false),
                        BetId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bets", t => t.BetId_Id)
                .Index(t => t.BetId_Id);
            
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BetItemType = c.Int(nullable: false),
                        Coefficient = c.Double(nullable: false),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
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
            DropForeignKey("dbo.Betcards", "BetId_Id", "dbo.Bets");
            DropForeignKey("dbo.Bets", "UserId_Id", "dbo.Users");
            DropIndex("dbo.Bets", new[] { "UserId_Id" });
            DropIndex("dbo.Betcards", new[] { "BetId_Id" });
            DropTable("dbo.Horses");
            DropTable("dbo.FootballTeams");
            DropTable("dbo.Users");
            DropTable("dbo.Bets");
            DropTable("dbo.Betcards");
            DropTable("dbo.BasketballTeams");
        }
    }
}

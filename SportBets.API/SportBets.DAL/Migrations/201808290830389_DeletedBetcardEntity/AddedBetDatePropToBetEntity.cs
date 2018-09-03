namespace SportBets.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedBetcardEntityAddedBetDatePropToBetEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Betcards", "BetId_Id", "dbo.Bets");
            DropIndex("dbo.Betcards", new[] { "BetId_Id" });
            AddColumn("dbo.Bets", "BetDate", c => c.DateTime(nullable: false));
            DropTable("dbo.Betcards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Betcards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BetDate = c.DateTime(nullable: false),
                        BetId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Bets", "BetDate");
            CreateIndex("dbo.Betcards", "BetId_Id");
            AddForeignKey("dbo.Betcards", "BetId_Id", "dbo.Bets", "Id");
        }
    }
}

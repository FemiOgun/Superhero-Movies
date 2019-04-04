namespace Web.SHC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        Name = c.String(),
                        Bio = c.String(),
                        Abilities = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CharacterID)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID, name: "Index_MovieID");
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MoviesID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PlotSummary = c.String(),
                        Year = c.String(),
                        Image = c.String(),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MoviesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "MovieID", "dbo.Movies");
            DropIndex("dbo.Characters", "Index_MovieID");
            DropTable("dbo.Movies");
            DropTable("dbo.Characters");
        }
    }
}

namespace MVCFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stateid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.States", t => t.Stateid, cascadeDelete: true)
                .Index(t => t.Stateid);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Countryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Countries", t => t.Countryid, cascadeDelete: true)
                .Index(t => t.Countryid);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ragisters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Subscribe = c.Boolean(nullable: false),
                        Cityid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cities", t => t.Cityid, cascadeDelete: true)
                .Index(t => t.Cityid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ragisters", "Cityid", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Stateid", "dbo.States");
            DropForeignKey("dbo.States", "Countryid", "dbo.Countries");
            DropIndex("dbo.Ragisters", new[] { "Cityid" });
            DropIndex("dbo.States", new[] { "Countryid" });
            DropIndex("dbo.Cities", new[] { "Stateid" });
            DropTable("dbo.Ragisters");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}

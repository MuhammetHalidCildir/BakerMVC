namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.altkategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.kategori", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.urun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kampanya = c.Boolean(nullable: false),
                        KampanyaOrani = c.Int(nullable: false),
                        AltKategoriId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.altkategori", t => t.AltKategoriId, cascadeDelete: true)
                .Index(t => t.AltKategoriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.urun", "AltKategoriId", "dbo.altkategori");
            DropForeignKey("dbo.altkategori", "KategoriId", "dbo.kategori");
            DropIndex("dbo.urun", new[] { "AltKategoriId" });
            DropIndex("dbo.altkategori", new[] { "KategoriId" });
            DropTable("dbo.urun");
            DropTable("dbo.kategori");
            DropTable("dbo.altkategori");
        }
    }
}

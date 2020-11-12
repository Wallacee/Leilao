namespace Leilao.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBBegin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.PessoaId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.Int(nullable: false),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lances", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Lances", "PessoaId", "dbo.Pessoas");
            DropIndex("dbo.Lances", new[] { "ProdutoId" });
            DropIndex("dbo.Lances", new[] { "PessoaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Lances");
        }
    }
}

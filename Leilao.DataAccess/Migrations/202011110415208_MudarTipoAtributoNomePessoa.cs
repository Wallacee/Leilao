namespace Leilao.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudarTipoAtributoNomePessoa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "Nome", c => c.Int(nullable: false));
        }
    }
}

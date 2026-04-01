namespace AdMechSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteAtual1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seguidors", "DataIniciacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seguidors", "DataIniciacao", c => c.DateTime());
        }
    }
}

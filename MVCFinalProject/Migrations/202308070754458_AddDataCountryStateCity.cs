namespace MVCFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataCountryStateCity : DbMigration
    {
        public override void Up()
        {
            //country
            Sql("Insert countries values('India')");
            Sql("Insert countries values('USA')");
            Sql("Insert countries values('Uk')");
            //State
            Sql("Insert States values('Punjab',1)");
            Sql("Insert States values('UP',1)");
            Sql("Insert States values('HP',1)");
            Sql("Insert States values('Abc',2)");
            Sql("Insert States values('xyz',2)");
            //city
            Sql("Insert cities values('mohali',1)");
            Sql("Insert cities values('LKO',2)");
            Sql("Insert cities values('ASR',1)");
            Sql("Insert cities values('Shimla',3)");
            Sql("Insert cities values('GKP',2)");
            Sql("Insert cities values('UNA',3)");






        }

        public override void Down()
        {
        }
    }
}

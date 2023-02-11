namespace GymApplication_new.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weekdays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weekdays",
                c => new
                    {
                        WeekdayId = c.Int(nullable: false, identity: true),
                        WeekdayName = c.String(),
                    })
                .PrimaryKey(t => t.WeekdayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weekdays");
        }
    }
}

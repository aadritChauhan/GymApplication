namespace GymApplication_new.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weekdaymuscleGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MuscleGroups", "WeekdayId", c => c.Int(nullable: false));
            CreateIndex("dbo.MuscleGroups", "WeekdayId");
            AddForeignKey("dbo.MuscleGroups", "WeekdayId", "dbo.Weekdays", "WeekdayId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MuscleGroups", "WeekdayId", "dbo.Weekdays");
            DropIndex("dbo.MuscleGroups", new[] { "WeekdayId" });
            DropColumn("dbo.MuscleGroups", "WeekdayId");
        }
    }
}

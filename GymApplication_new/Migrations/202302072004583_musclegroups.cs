namespace GymApplication_new.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class musclegroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MuscleGroups",
                c => new
                    {
                        MuscleGroupId = c.Int(nullable: false, identity: true),
                        MuscleGroupName = c.String(),
                        Exercises = c.String(),
                    })
                .PrimaryKey(t => t.MuscleGroupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MuscleGroups");
        }
    }
}

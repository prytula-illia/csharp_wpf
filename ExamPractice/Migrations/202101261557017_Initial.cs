namespace ExamPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PassNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.PassNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "PassNumber" });
            DropTable("dbo.Students");
        }
    }
}

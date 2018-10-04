namespace EntityFrameworkSchema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schemachangedtolibrary : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Authors", newSchema: "library");
            MoveTable(name: "dbo.Books", newSchema: "library");

            // Dont forget the triggers
            // Sql($"ALTER TRIGGER [library].[TR_dbo_Authors_InsertUpdateDelete] ON [library].[Authors] AFTER INSERT, UPDATE, DELETE AS BEGIN UPDATE [library].[Authors] SET [library].[Authors].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME()) FROM INSERTED WHERE inserted.[Id] = [library].[Authors].[Id] END");
        }
        
        public override void Down()
        {
            MoveTable(name: "library.Books", newSchema: "dbo");
            MoveTable(name: "library.Authors", newSchema: "dbo");

            // Dont forget the triggers
            // Sql($"ALTER TRIGGER [dbo].[TR_dbo_Authors_InsertUpdateDelete] ON [dbo].[Authors] AFTER INSERT, UPDATE, DELETE AS BEGIN UPDATE [dbo].[Authors] SET [dbo].[Authors].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME()) FROM INSERTED WHERE inserted.[Id] = [dbo].[Authors].[Id] END");
        }
    }
}

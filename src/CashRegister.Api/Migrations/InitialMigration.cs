using FluentMigrator;

namespace CashRegister.Api.Migrations;

[Migration(1)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .InSchema("dbo")
            .WithColumn("username").AsString(50).PrimaryKey()
            .WithColumn("key_path").AsString(100).NotNullable();

        Create.Table("documents")
            .InSchema("dbo")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("created_at").AsDateTime().NotNullable()
            .WithColumn("document_type").AsInt16().NotNullable()
            .WithColumn("local_number").AsInt64().NotNullable()
            .WithColumn("fiscal_number").AsString(32)
            .WithColumn("cash_register_id").AsInt64().NotNullable()
            .WithColumn("xml").AsString()
            .WithColumn("ticket").AsString(1000);

        Execute.Sql(SqlHelper.LoadSqlStatement("create_document_procedures.sql"));
    }

    public override void Down()
    {
        Delete.Table("users").InSchema("dbo");
    }
}
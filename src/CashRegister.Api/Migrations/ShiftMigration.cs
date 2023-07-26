using FluentMigrator;

namespace CashRegister.Api.Migrations;

[Migration(2)]
public class CreateShiftsMigration : Migration
{
    public override void Up()
    {
        Create.Table("cash_register_state")
            .InSchema("dbo")
            .WithColumn("cash_register_fiscal_number").AsInt64().PrimaryKey()
            .WithColumn("shift_id").AsInt64()
            .WithColumn("open_shift_fiscal_number").AsString(256)
            .WithColumn("is_z_report_present").AsBoolean()
            .WithColumn("name").AsString(128)
            .WithColumn("subject_key_id").AsString(128)
            .WithColumn("fist_local_number").AsInt64()
            .WithColumn("next_local_number").AsInt64()
            .WithColumn("last_fiscal_number").AsString(64)
            .WithColumn("is_offline_supported").AsBoolean()
            .WithColumn("is_chief_cashier").AsBoolean()
            .WithColumn("date_time").AsDateTime2()
            .WithColumn("next_local_number_for_send").AsInt64()
            .WithColumn("offline_session_id").AsInt64()
            .WithColumn("offline_seed").AsInt64()
            .WithColumn("offline_next_local_number").AsInt64()
            .WithColumn("shift_state").AsByte()
            .WithColumn("is_testing").AsBoolean();

        Create.Table("offline_documents")
            .InSchema("dbo")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("created_at").AsDateTime().NotNullable()
            .WithColumn("document_type").AsInt16().NotNullable()
            .WithColumn("local_number").AsInt64().NotNullable()
            .WithColumn("offline_document_number").AsInt64().NotNullable()
            .WithColumn("fiscal_number").AsString(32)
            .WithColumn("cash_register_fiscal_number").AsInt64().NotNullable()
            .WithColumn("xml").AsString(2000)
            .WithColumn("hash").AsString(500);

        Execute.Sql(SqlHelper.LoadSqlStatement("cash_register_state_procedures.sql"));
    }

    public override void Down()
    {
        Delete.Table("cash_register_state")
            .InSchema("dbo");
    }
}
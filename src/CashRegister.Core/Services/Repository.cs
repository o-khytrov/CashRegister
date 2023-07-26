using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CashRegister.Models.DbModels;
using CashRegister.Models.Options;
using Dapper;
using Microsoft.Extensions.Options;

namespace CashRegister.Models.Services;

public class Repository
{
    private readonly string? _connectionString;

    public Repository(IOptions<ConnectionStrings> options)
    {
        _connectionString = options.Value.CashRegisterDb;
        SetupDapper();
    }

    public async Task UpdateCheckXml(long documentFiscalNumber, string checkXml)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@fiscal_number", documentFiscalNumber, DbType.Int64);
        @params.Add("@xml", checkXml, DbType.String);

        await connection.ExecuteAsync("dbo.sp_document_update",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    public async Task InsertOfflineDocument(OfflineDocument document)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@local_number", (long) document.LocalNumber, DbType.Int64);
        @params.Add("@fiscal_number", document.FiscalNumber, DbType.String);
        @params.Add("@cash_register_fiscal_number", (long) document.CashRegisterFiscalNumber, DbType.Int64);
        @params.Add("@offline_document_number", (long) document.OfflineSessionDocumentNumber, DbType.Int64);
        @params.Add("@document_type", document.Type, DbType.Int64);
        @params.Add("@xml", document.Xml, DbType.String);
        @params.Add("@hash", document.Hash, DbType.String);
        await connection.ExecuteAsync("dbo.sp_offline_document_insert",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    public async Task InsertDocument(Document document)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@local_number", (long) document.LocalNumber, DbType.Int64);
        @params.Add("@document_type", (long) document.DocumentType, DbType.Int64);
        @params.Add("@fiscal_number", document.FiscalNumber, DbType.String);
        @params.Add("@cash_register_id", (long) document.CashRegisterId, DbType.Int64);
        @params.Add("@xml", document.Xml, DbType.String);
        @params.Add("@ticket", document.Ticket, DbType.String);
        await connection.ExecuteAsync("dbo.sp_document_insert",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<ulong> GetLasGetLocalNumber(ulong cashRegisterId)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@cash_register_id", (long) cashRegisterId, DbType.Int64);
        return await connection.ExecuteScalarAsync<ulong>("dbo.sp_get_last_local_number",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<OfflineDocument?> GetLastOfflineDocument(ulong cashRegisterId)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@cash_register_fiscal_number", (long) cashRegisterId, DbType.Int64);
        return await connection.QueryFirstOrDefaultAsync<OfflineDocument>("dbo.sp_offline_document_get_last",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    public async Task CashRegisterStateWrite(CashRegisterStateDbModel cashRegisterStateDbModel)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@cash_register_id", (long) cashRegisterStateDbModel.CashRegisterFiscalNumber, DbType.Int64);
        await connection.ExecuteAsync("dbo.sp_cash_register_state_write",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<CashRegisterStateDbModel> CashRegisterStateRead(ulong cashRegisterFiscalNumber)
    {
        await using var connection = new SqlConnection(_connectionString);
        var @params = new DynamicParameters();
        @params.Add("@cash_register_fiscal_number", (long) cashRegisterFiscalNumber, DbType.Int64);
        return await connection.QueryFirstOrDefaultAsync<CashRegisterStateDbModel>("dbo.sp_cash_register_state_read",
            @params,
            commandType: CommandType.StoredProcedure);
    }

    private static string? GetColumnNameFromAttribute(MemberInfo member)
    {
        if (member == null)
        {
            return null;
        }

        var attrib = (ColumnAttribute) Attribute.GetCustomAttribute(member, typeof(ColumnAttribute), false);
        return (attrib?.Name ?? member.Name).ToLower();
    }

    private static void SetupDapper()
    {
        foreach (var type in typeof(Repository).Assembly.GetTypes())
        {
            var map = new CustomPropertyTypeMap(type, (type, columnName)
                => type.GetProperties()
                    .FirstOrDefault(prop => GetColumnNameFromAttribute(prop) == columnName.ToLower()));
            SqlMapper.SetTypeMap(type, map);
        }
    }
}
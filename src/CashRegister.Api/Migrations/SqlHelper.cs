using System.Reflection;

namespace CashRegister.Api.Migrations;

public static class SqlHelper
{
    public static string LoadSqlStatement(string statementName)
    {
        var sqlStatement = string.Empty;

        var resourceName = $"{Assembly.GetExecutingAssembly().GetName().Name}.Migrations.Scripts.{statementName}";

        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        if (stream != null) sqlStatement = new StreamReader(stream).ReadToEnd();

        return sqlStatement;
    }
}
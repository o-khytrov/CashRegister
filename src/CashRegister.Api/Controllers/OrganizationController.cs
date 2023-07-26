using CashRegister.Api.Models.Dfs.Responses.Entities;
using CashRegister.Api.Models.Responses;
using CashRegister.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Api.Controllers;

/// <summary>
///     Методы программного РРО.
/// </summary>
[ApiController]
[Route("/api/organization")]
[Authorize]
public class OrganizationController : ControllerBase
{
    private readonly DfsService _dfsService;

    public OrganizationController(DfsService dfsService)
    {
        _dfsService = dfsService;
    }

    /// <summary>
    ///     Отримання переліку господарських одинициь.
    /// </summary>
    [HttpGet("business_units")]
    public async Task<IEnumerable<BusinessUnitModel>> GetBusinessUnits()
    {
        var keyInfo = this.GetKeyInfo();
        var businessUnits = await _dfsService.GetBusinessUnits(keyInfo);

        return businessUnits.Select(CreateBusinessUnitModel).ToArray();
    }

    /// <summary>
    ///     Запит переліку операторів (касирів) для суб’єкта господарювання.
    /// </summary>
    [HttpGet("operators")]
    public async Task<IEnumerable<OperatorModel>> GetOperators()
    {
        var keyInfo = this.GetKeyInfo();
        var operators = await _dfsService.GetOperators(keyInfo);

        return operators.Select(CreateOperatorModel).ToArray();
    }

    private OperatorModel CreateOperatorModel(Operator @operator) => new()
    {
        SubjectKeyId = @operator.SubjectKeyId,
        RegNum = @operator.RegNum,
        ChiefCashier = @operator.ChiefCashier
    };

    private BusinessUnitModel CreateBusinessUnitModel(BusinessUnit businessUnit) => new()
    {
        Address = businessUnit.Address,
        Entity = businessUnit.Entity,
        OrgName = businessUnit.OrgName,
        Name = businessUnit.Name,
        Tin = businessUnit.Tin,
        Ipn = businessUnit.Ipn,
        TransactionsRegistrars = businessUnit.TransactionsRegistrars
            .Select(BuildRegistrarModel)
            .ToArray()
    };

    private TransactionsRegistrarModel BuildRegistrarModel(TransactionsRegistrarItem transactionsRegistrarItem) => new()
    {
        NumFiscal = transactionsRegistrarItem.NumFiscal,
        NumLocal = transactionsRegistrarItem.NumLocal,
        Name = transactionsRegistrarItem.Name,
        Closed = transactionsRegistrarItem.Closed
    };
}
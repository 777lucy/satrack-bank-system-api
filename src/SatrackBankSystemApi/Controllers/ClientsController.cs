using MediatR;
using Microsoft.AspNetCore.Mvc;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Api.Application.Queries;
using SatrackBankSystem.Infrastructure.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Crear nuevo cliente
    /// </summary>
    /// <param name="command">Datos para la creación del cliente</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    /// <summary>
    /// Consultar saldo promedio de tipos de clientes
    /// </summary>
    /// <returns></returns>
    [HttpGet("AverageBalance")]
    public async Task<IActionResult> GetAverageBalance()
    {
        GetAverageBalanceQuery query = new();
        AverageBalanceDto averageBalance = await _mediator.Send(query);
        return Ok(averageBalance);
    }

    /// <summary>
    /// Consultar clientes con mayor saldo según tipo cliente
    /// </summary>
    /// <returns></returns>
    [HttpGet("TopClients")]
    public async Task<IActionResult> GetTopClients()
    {
        GetTopClientsQuery query = new();
        IEnumerable<GroupedTopClientsBalanceDto> groupedTopClients = await _mediator.Send(query);
        return Ok(groupedTopClients);
    }
}

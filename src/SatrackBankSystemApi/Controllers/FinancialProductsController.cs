using MediatR;
using Microsoft.AspNetCore.Mvc;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Api.Application.Queries;
using SatrackBankSystem.Infrastructure.Dtos;

namespace SatrackBankSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crear cuenta de ahorros 
        /// </summary>
        /// <param name="command">Identificación del cliente</param>
        /// <returns></returns>
        [HttpPost("Savings")]
        public async Task<IActionResult> CreateSavingsAccount([FromBody] CreateSavingsAccountCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Crear cuenta CDT
        /// </summary>
        /// <param name="command">Valores para la creación</param>
        /// <returns></returns>
        [HttpPost("CDT")]
        public async Task<IActionResult> CreateCDTAccount([FromBody] CreateCDTAccountCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Crear cuenta corriente
        /// </summary>
        /// <param name="command">Valores para la creación</param>
        /// <returns></returns>
        [HttpPost("Current")]
        public async Task<IActionResult> CreateCurrentAccount([FromBody] CreateCurrentAccountCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Permite aplicar una transacción a la cuenta corriente
        /// </summary>
        /// <param name="accountId">Número de cuenta</param>
        /// <param name="command">Monto para aplicar la transacción</param>
        /// <returns></returns>
        [HttpPatch("Current/{accountId}/ApplyTransaction")]
        public async Task<IActionResult> ApplyTransactionCurrent([FromRoute] Guid accountId, [FromBody] ApplyTransactionCurrentCommand command)
        {
            command.SetAccountId(accountId);

            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        /// <summary>
        /// Permite aplicar una transacción a la cuenta de ahorros  
        /// </summary>
        /// <param name="accountId">Número de cuenta</param>
        /// <param name="command">Monto para aplicar la transacción</param>
        /// <returns></returns>
        [HttpPatch("Savings/{accountId}/ApplyTransaction")]
        public async Task<IActionResult> ApplyTransactionSavings([FromRoute] Guid accountId, [FromBody] ApplyTransactionSavingsCommand command)
        {
            command.SetAccountId(accountId);

            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        /// <summary>
        /// Permite cancelar la cuenta CDT
        /// </summary>
        /// <param name="accountId">Número de la cuenta CDT</param>
        /// <returns></returns>
        [HttpDelete("CDT/{accountId}")]
        public async Task<IActionResult> CancelCDT([FromRoute] Guid accountId)
        {
            CancelCDTCommand command = new()
            {
                AccountId = accountId
            };

            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        /// <summary>
        /// Consultar proyección del saldo de una cuenta en el tiempo
        /// </summary>
        /// <param name="accountId">Número de cuenta</param>
        /// <param name="months">Meses para calcular la proyección</param>
        /// <returns></returns>
        [HttpGet("InterestProjection/{accountId}")]
        public async Task<IActionResult> GetInterestProjection([FromRoute] Guid accountId, [FromQuery] int months)
        {
            GetInterestProjectionQuery query = new()
            {
                AccountId = accountId,
                ProjectionMonths = months
            };

            InterestProjectionDto projection = await _mediator.Send(query);
            return Ok(projection);
        }
    }
}

using System.Net.Mime;
using System.Transactions;
using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehiCover.Api.Controllers.ResponseTypes;
using VehiCover.Application.Common.Validation;
using VehiCover.Application.Interfaces;
using VehiCover.Application.Quotes;
using VehiCover.Domain.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace VehiCover.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesService _appService;
        private readonly IValidationService _validationService;
        private readonly IUnitOfWork _unitOfWork;

        public QuotesController(IQuotesService appService, IValidationService validationService, IUnitOfWork unitOfWork)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateQuote(
            [FromBody] QuoteCreateDto dto,
            CancellationToken cancellationToken = default)
        {
            await _validationService.Handle(dto, cancellationToken);
            var result = Guid.Empty;

            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await _appService.CreateQuote(dto, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Complete();
            }
            return CreatedAtAction(nameof(FindQuoteById), new { id = result }, new JsonResponse<Guid>(result));
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified QuoteDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">No QuoteDto could be found with the provided parameters.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuoteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuoteDto>> FindQuoteById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = default(QuoteDto);
            result = await _appService.FindQuoteById(id, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;QuoteDto&gt;.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<QuoteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<QuoteDto>>> FindQuotes(CancellationToken cancellationToken = default)
        {
            var result = default(List<QuoteDto>);
            result = await _appService.FindQuotes(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">One or more entities could not be found with the provided parameters.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateQuote(
            [FromRoute] Guid id,
            [FromBody] QuoteUpdateDto dto,
            CancellationToken cancellationToken = default)
        {
            await _validationService.Handle(dto, cancellationToken);

            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
            {
                await _appService.UpdateQuote(id, dto, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Complete();
            }
            return NoContent();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">One or more entities could not be found with the provided parameters.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteQuote([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
            {
                await _appService.DeleteQuote(id, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Complete();
            }
            return Ok();
        }
    }
}
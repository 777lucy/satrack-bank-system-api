using MediatR;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Api.Application.Mappers;
using SatrackBankSystem.Infrastructure.Interfaces;

namespace SatrackBankSystem.Api.Application.Handlers.Commands
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Unit>
    {
        private readonly IClientFactory _clientFactory;
        private readonly IClientRepositoryFactory _clientRepositoryFactory;
        private readonly IValidationService _validationService;

        public CreateClientHandler(IClientRepositoryFactory clientRepositoryFactory, IClientFactory clientFactory, IValidationService validationService)
        {
            _clientRepositoryFactory = clientRepositoryFactory ?? throw new ArgumentNullException(nameof(clientRepositoryFactory));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService)); ;
        }

        public async Task<Unit> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            bool clientExist = await _validationService.ClientExist(command.Identification);

            if (clientExist)
            {
                throw new ArgumentException($"El cliente con identificación {command.Identification} ya existe en el sistema");
            }

            Client client = _clientFactory.BuildClient(command.ToDto());

            IClientRepositoryBase repository = _clientRepositoryFactory.GetRepository(client.ClientType);

            await repository.CreateClient(client);

            return Unit.Value;
        }
    }
}

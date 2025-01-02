﻿using MediatR;

namespace SatrackBankSystem.Api.Application.Commands
{
    public class CreateCurrentAccountCommand : IRequest<Unit>
    {
        public string Identification { get; set; } = string.Empty;
    }
}
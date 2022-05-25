using MediatR;
using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid ConfirmationId { get; set; }
    }

}

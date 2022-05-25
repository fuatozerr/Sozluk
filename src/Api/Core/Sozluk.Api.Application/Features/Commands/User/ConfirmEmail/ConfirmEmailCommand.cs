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
    public class ConfirmEmailCommandHandler2 : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailConfirmationRepository emailConfirmationRepository;

        public ConfirmEmailCommandHandler2(IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository)
        {
            this.userRepository = userRepository;
            this.emailConfirmationRepository = emailConfirmationRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmation = await emailConfirmationRepository.GetByIdAsync(request.ConfirmationId);

            if (confirmation is null)
                throw new DatabaseValidationException("Confirmation not found!");

            var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == confirmation.NewEmailAddress);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found with this email!");

            if (dbUser.EmailConfirmed)
                throw new DatabaseValidationException("Email address is already confirmed!");

            dbUser.EmailConfirmed = true;
            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }

}

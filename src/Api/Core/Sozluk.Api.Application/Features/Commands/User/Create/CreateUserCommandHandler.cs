using AutoMapper;
using MediatR;
using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Common;
using Sozluk.Common.Events.User;
using Sozluk.Common.Exceptions;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Api.Application.Features.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }


        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var exitsUser =await userRepository.GetSingleAsync(x => x.EmailAddress == request.EMailAddress);
            if (exitsUser is not null)
                throw new DatabaseValidationException("User already exits!");

            var dbUser = mapper.Map<Sozluk.Api.Domain.Models.User>(request);
            var rows = await userRepository.AddAsync(dbUser);

            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };

                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName, 
                                                    exchangeType: SozlukConstants.DefaultExchangeType, 
                                                    queueName: SozlukConstants.UserEmailChangedQueueName, obj: @event);
            }

            return dbUser.Id;
        }
    }
}

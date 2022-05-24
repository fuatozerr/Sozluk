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

namespace Sozluk.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var dbEmailAddress = dbUser.EmailAddress;
            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EMailAddress) != 0;
            mapper.Map(request, dbUser); //requestin içindekilerini dbusera aktarıyor.
            var rows = await userRepository.UpdateAsync(dbUser);

            if (emailChanged && rows > 0)
            {
                var @event = new UserEmailChangedEvent() 
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };

                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                                    exchangeType: SozlukConstants.DefaultExchangeType,
                                                    queueName: SozlukConstants.UserEmailChangedQueueName, obj: @event);

                dbUser.EmailConfirmed = false;
                await userRepository.UpdateAsync(dbUser);

            }
            //check if email changed
            throw new NotImplementedException();
        }
    }
}

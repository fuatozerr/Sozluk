using MediatR;
using Sozluk.Common;
using Sozluk.Common.Events.Entry;
using Sozluk.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
    {
        public Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName, SozlukConstants.DefaultExchangeType, SozlukConstants.CreateEntryFavQueueName, obj: new CreateEntryFavEvent()
            {
                EntryId = request.EntryId.Value,
                UserId=request.UserId.Value
            });

            return Task.FromResult(true);
        }
    }
}

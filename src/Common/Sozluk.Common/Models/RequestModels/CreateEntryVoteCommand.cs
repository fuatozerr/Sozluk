using MediatR;
using Sozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Common.Models.RequestModels
{
    public class CreateEntryVoteCommand:IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public Guid CreatedBy { get; set; }
        public VoteType VoteType{ get; set; }

        public CreateEntryVoteCommand(Guid entryId, VoteType voteType, Guid createdBy)
        {
            EntryId = entryId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }
    }
}

using MediatR;
using Sozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Common.Models
{
    public class CreateEntryCommentVoteCommand:IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }

        public VoteType VoteType { get; set; }

        public Guid CreatedBy { get; set; }

        public CreateEntryCommentVoteCommand()
        {

        }

        public CreateEntryCommentVoteCommand(Guid entryCommentId, VoteType voteType, Guid createdBy)
        {
            EntryCommentId = entryCommentId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Infrastructure.Persistence.Context.EntityConfigurations.EntryComment
{
    internal class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);
            builder.ToTable("entrycommentvote", SozlukContext.DEFAULT_SCHEMA);
            builder.HasOne(i => i.EntryComment).WithMany(i => i.EntryCommentVotes).HasForeignKey(i => i.EntryCommentId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Infrastructure.Persistence.Context.EntityConfigurations.Entry
{
    public class EntryVoteEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryvote", SozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryVotes)
                .HasForeignKey(i => i.EntryId);

        }
    }
}

using Sozluk.Common.ViewModels;
using Sozluk.WebApp.Infrastructure.Service.Interfaces;

namespace Sozluk.WebApp.Infrastructure.Service
{
    public class VoteService : IVoteService
    {
        private readonly HttpClient client;

        public VoteService(HttpClient client)
        {
            this.client = client;
        }

        public async Task DeleteEntryVote(Guid entryId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryVote error");

        }
        public async Task DeleteEntryCommentVote(Guid entryId)
        {
            var response = await client.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryId}", null);
            if (!response.IsSuccessStatusCode)
                throw new Exception("DeleteEntryVote error");
        }

        public async Task CreateEntryUpVote(Guid entryId)
        {
            await CreateEntryVote(entryId, VoteType.UpVote);
        }

        public async Task CreateEntryDownVote(Guid entryId)
        {
            await CreateEntryVote(entryId, VoteType.DownVote);

        }
        private async Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            var result = await client.PostAsync($"/api/vote/entry/{entryId}?voteType={voteType}", null);
            return result;
        }
        public async Task CreateEntryCommentUpVote(Guid entryCommentId)
        {
            await CreateEntryCommentVote(entryCommentId, VoteType.UpVote);
        }

        public async Task CreateEntryCommentDownVote(Guid entryCommentId)
        {
            await CreateEntryCommentVote(entryCommentId, VoteType.DownVote);

        }

        private async Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            var result = await client.PostAsync($"/api/vote/entrycomment/{entryId}?voteType={voteType}", null);
            return result;
        }
    }
}

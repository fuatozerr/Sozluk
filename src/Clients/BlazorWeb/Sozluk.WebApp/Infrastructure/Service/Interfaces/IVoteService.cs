namespace Sozluk.WebApp.Infrastructure.Service.Interfaces
{
    public interface IVoteService
    {
        Task CreateEntryCommentDownVote(Guid entryCommentId);
        Task CreateEntryCommentUpVote(Guid entryCommentId);
        Task CreateEntryDownVote(Guid entryId);
        Task CreateEntryUpVote(Guid entryId);
        Task DeleteEntryCommentVote(Guid entryId);
        Task DeleteEntryVote(Guid entryId);
    }
}
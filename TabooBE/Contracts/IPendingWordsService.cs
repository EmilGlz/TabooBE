using TabooBE.Models.DBModels;
using TabooBE.Models.DTOs.Requests;

namespace TabooBE.Contracts
{
    public interface IPendingWordsService
    {
        PendingWordDBModel AddPendingWord(PendingWordDBModel wordDBModel);
        void RemovePendingWord(string Id);
        PendingWordDBModel GetById(string id);
    }
}

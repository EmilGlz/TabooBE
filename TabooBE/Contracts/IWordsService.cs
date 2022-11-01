using TabooBE.Models.DBModels;

namespace TabooBE.Contracts
{
    public interface IWordsService
    {
        WordDBModel GetWordByHeadText(string headText);
        WordDBModel AddWord(WordDBModel model);
        WordDBModel GetRandomModel();
    }
}

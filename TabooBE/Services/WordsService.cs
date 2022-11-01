using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TabooBE.Contracts;
using TabooBE.Models.DBModels;

namespace TabooBE.Services
{
    public class WordsService : IWordsService
    {
        private IMongoCollection<WordDBModel> _collection;
        public WordsService(IMongoClient client)
        {
            var database = client.GetDatabase("Words");
            _collection = database.GetCollection<WordDBModel>("WordsCollection");
        }
        public WordDBModel AddWord(WordDBModel model)
        {
            _collection.InsertOne(model);
            return model;
        }

        public WordDBModel GetRandomModel()
        {
            var allModels = _collection.Find(_ => true).ToList();
            Random rnd = new Random();
            var randomIndex = rnd.Next(0, allModels.Count);
            var res = allModels[randomIndex];
            return res;
        }

        public WordDBModel GetWordByHeadText(string headText)
        {
            var res = _collection.Find(w => w.MainWord == headText).ToList();
            if (res.Count > 0)
            {
                return res[0];
            }
            return null;
        }
    }
}

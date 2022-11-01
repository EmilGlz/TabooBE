using MongoDB.Driver;
using TabooBE.Contracts;
using TabooBE.Models.DBModels;
using TabooBE.Models.DTOs.Requests;

namespace TabooBE.Services
{
    public class PendingWordsService : IPendingWordsService
    {
        private IMongoCollection<PendingWordDBModel> _collection;
        public PendingWordsService(IMongoClient client)
        {
            var database = client.GetDatabase("PendingWords");
            _collection = database.GetCollection<PendingWordDBModel>("PendingWordsCollection");
        }

        public PendingWordDBModel AddPendingWord(PendingWordDBModel wordDBModel)
        {
            _collection.InsertOne(wordDBModel);
            return wordDBModel;
        }

        public PendingWordDBModel GetById(string id)
        {
            var res = _collection.Find(pw => pw.Id == id).ToList();
            if (res.Count > 0)
                return res[0];
            return null;
        }

        public void RemovePendingWord(string Id)
        {
            _collection.DeleteOne(pw => pw.Id == Id);
        }
    }
}

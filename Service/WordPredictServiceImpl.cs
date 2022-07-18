using CSharpRocks.Repositories;

namespace CSharpRocks.Service
{
    public class WordPredictServiceImpl : iWordPredictService
    {
        private readonly iWordPredictRepository _wordPredictRepository;

        public WordPredictServiceImpl(iWordPredictRepository wordPredictRepository)
        {
            _wordPredictRepository = wordPredictRepository;
        }

        public List<string> GetWordsFromDictionary(string text)
        {
           return _wordPredictRepository.GetWordsFromDictionary(text);   
        }

        public async Task<Task<List<string>>> GetWordsFromServiceAsync(string text, string token, string locale)
        {


            return _wordPredictRepository.GetWordsFromServiceAsync( text,  token,  locale);
        }
    }
}

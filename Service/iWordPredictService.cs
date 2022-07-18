namespace CSharpRocks.Service
{
    public interface iWordPredictService
    {
        List<string> GetWordsFromDictionary(string text);

        Task<Task<List<string>>> GetWordsFromServiceAsync(string text, string token, string locale);
    }
}

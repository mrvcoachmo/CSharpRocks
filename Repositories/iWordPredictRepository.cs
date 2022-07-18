namespace CSharpRocks.Repositories
{
    public interface iWordPredictRepository
    {
        List<string> GetWordsFromDictionary(string text);

        Task<List<string>> GetWordsFromServiceAsync(string text, string token, string locale);
    }
}

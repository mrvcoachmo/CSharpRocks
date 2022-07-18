using CSharpRocks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using Flurl;
using Flurl.Http;

namespace CSharpRocks.Repositories
{
    public class WordPredictRepositoryImpl : iWordPredictRepository
    {
        const string SELECT_WORDS_BY_CHARS = "SELECT * FROM Words WHERE  VALUE LIKE'{0}%'";

        const string API_BASE_ADDRESS = "https://services.lingapps.dk/misc/";

        const string dbfile = "URI=file:Dictionary.db";

        public async Task<List<string>> GetWordsFromServiceAsync(string text, string token, string locale)
        {

            var words = await API_BASE_ADDRESS
                                   .AppendPathSegment("getPredictions")
                   .WithOAuthBearerToken(token)
                   .SetQueryParams(new { locale, text})
                   .AllowAnyHttpStatus()
                   .GetJsonAsync<IEnumerable<string>>();

            return words.ToList();
        }

        List<string> iWordPredictRepository.GetWordsFromDictionary(string text)
        {
            var words = new List<String>();
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(InsertValue(SELECT_WORDS_BY_CHARS, text) , connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //words.Add(new Word(reader["Id"], reader["Value"]));
                    words.Add((string)reader["Value"]);
                }
                connection.Close();
            }
           
            return words;
            }



        private string InsertValue(string sql, string chars)
        {
            return String.Format(sql, chars);
        }
    }
}

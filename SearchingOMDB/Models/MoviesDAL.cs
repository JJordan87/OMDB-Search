using Newtonsoft.Json;
using System.Net;

namespace SearchingOMDB.Models
{
    public class MoviesDAL
    {
        public MoviesModel GetMovies(string Title)
        {
            string url = $"http://www.omdbapi.com/?apikey={Secret.movieAPIKey}&t={Title}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            MoviesModel result = JsonConvert.DeserializeObject<MoviesModel>(JSON);
            return result;
        }
    }
}

using System.Net.Http;
using System.Net.Http.Json;
using plataformacomentarios.Models.External;

namespace plataformacomentarios.Services
{
    public class JsonPlaceholderService
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"https://jsonplaceholder.typicode.com/users/{id}");
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _httpClient.GetFromJsonAsync<List<Comment>>($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
        }
    }
}

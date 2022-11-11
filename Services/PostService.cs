using BlazorApp.Models;
using BlazorApp.Models.Account;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IPostService
    {
        Post Post { get; }
        Task Initialize();

        Task Add(AddPost model);

        Task<IList<Post>> GetAllPosts();
        Task<Post> GetById(string id);
        
        Task Delete(string id);
        
        Task Update(string id, EditPost model);
    }


    public class PostService : IPostService

    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _postKey = "post";

        public Post Post { get; private set; }


        public PostService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            Post = await _localStorageService.GetItem<Post>(_postKey);
        }



        public async Task Add(AddPost model)
        {
            await _httpService.Post("/posts/add", model);
        }


        public async Task<IList<Post>> GetAllPosts()
        {
            return await _httpService.Get<IList<Post>>("/posts");
        }

        public async Task<Post> GetById(string id)
        {
            return await _httpService.Get<Post>($"/posts/{id}");
        }
        
        public async Task Update(string id, EditPost model)
        {
            await _httpService.Put($"/posts/{id}", model);

            // update stored user if the logged in user updated their own record
            if (id == Post.postId) 
            {
                // update local storage
                Post.title = model.Title;
                Post.content = model.Content;
                await _localStorageService.SetItem(_postKey, Post);
            }
        }


        public async Task Delete(string id)
        {
            await _httpService.Delete($"/posts/{id}");
        }
    }
}
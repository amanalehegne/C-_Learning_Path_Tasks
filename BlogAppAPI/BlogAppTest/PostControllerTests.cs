using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using BlogAppAPI.Controllers;
using BlogAppAPI.Data;
using BlogAppAPI.Models;
using BlogAppAPI.Requests;

namespace BlogAppTest
{
    public class PostControllerTests
    {
        [Fact]
        public async Task TestGetPosts()
        {
            var posts = new List<Post>
            {
                new Post { Id = 1, Title = "Post 1", Content = "Content 1" },
                new Post { Id = 2, Title = "Post 2", Content = "Content 2" }
            };
            var dbContext = DbContext.CreateDbContextMock(posts);

            var controller = new PostsController(dbContext.Object);

            var result = await controller.Get() as OkObjectResult;
            var returnedPosts = result.Value as List<Post>;

            Assert.NotNull(returnedPosts);
            Assert.Equal(2, returnedPosts.Count);
        }

        [Fact]
        public async Task TestGetPostById()
        {
            var post = new Post { Id = 1, Title = "Test Post", Content = "Test Content" };
            var dbContext = DbContext.CreateDbContextMock(new List<Post> { post });
            var controller = new PostsController(dbContext.Object);

            var result = await controller.Get(post.Id) as OkObjectResult;
            var returnedPost = result.Value as Post;

            Assert.NotNull(returnedPost);
            Assert.Equal(post.Id, returnedPost.Id);
            Assert.Equal(post.Title, returnedPost.Title);
        }

        private DbSet<T> MockDbSet<T>(IQueryable<T> data) where T : class
        {
            return DbContext.MockDbSet(data);
        }
    }
}

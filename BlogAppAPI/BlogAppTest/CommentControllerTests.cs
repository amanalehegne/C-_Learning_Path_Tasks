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
    public class CommentControllerTests
    {
        [Fact]
        public async Task TestGet()
        {
            var comments = new List<Comment>
            {
                new Comment { Id = 1, Text = "Comment 1", PostId = 1 },
                new Comment { Id = 2, Text = "Comment 2", PostId = 1 }
            };

            var dbContext = DbContext.CreateDbContextMock(comments);
            var controller = new CommentsController(dbContext.Object);
            var result = await controller.Get() as OkObjectResult;
            var returnedComments = result.Value as List<Comment>;

            Assert.NotNull(returnedComments);
            Assert.Equal(2, returnedComments.Count);
        }

        [Fact]
        public async Task TestGetById()
        {
            var comment = new Comment { Id = 1, Text = "Test Comment", PostId = 1 };
            var dbContext = DbContext.CreateDbContextMock(new List<Comment> { comment });
            var controller = new CommentsController(dbContext.Object);
            var result = await controller.Get(comment.Id) as OkObjectResult;
            var returnedComment = result.Value as Comment;

            Assert.NotNull(returnedComment);
            Assert.Equal(comment.Id, returnedComment.Id);
            Assert.Equal(comment.Text, returnedComment.Text);
        }

        [Fact]
        public async Task TestGetByNotFound()
        {
            var dbContext = DbContext.CreateDbContextMock(new List<Comment>());
            var controller = new CommentsController(dbContext.Object);
            var result = await controller.Get(1) as NotFoundObjectResult;

            Assert.NotNull(result);
            Assert.Equal("No Such Comment", result.Value);
        }
    }
}

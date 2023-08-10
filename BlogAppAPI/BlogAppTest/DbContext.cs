using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppAPI.Data;
using BlogAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BlogAppTest
{
    public static class DbContext
    {
        public static Mock<AppDbContext> CreateDbContextMock(List<Post> posts)
        {
            var dbContextMock = new Mock<AppDbContext>();
            var postsQueryable = posts.AsQueryable();

            dbContextMock.Setup(db => db.Posts).Returns(MockDbSet(postsQueryable));
            dbContextMock.Setup(db => db.Posts.FindAsync(It.IsAny<int>()))
                        .Returns<int>(id => Task.FromResult(posts.FirstOrDefault(p => p.Id == id)));

            return dbContextMock;
        }

        public static DbSet<T> MockDbSet<T>(IQueryable<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }
    }
}

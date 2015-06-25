using Microsoft.Data.Entity;
using Moq;
using Sample1Data;
using Xunit;

namespace Sample1DataTests
{
    public class PlayerServiceTest
    {
        [Fact]
        public void TestAddPlayer()
        {
            var mockSet = new Mock<DbSet<Player>>();
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Players).Returns(mockSet.Object);

            var service = new PlayerService(mockContext.Object);
            service.AddPlayer(new Player { Name = "Player1" });

            mockSet.Verify(m => m.Add(It.IsAny<Player>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}

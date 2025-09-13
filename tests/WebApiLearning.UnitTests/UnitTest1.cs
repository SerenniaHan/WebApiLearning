using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Moq;
using Shouldly;
using WebApiLearning.Core.Entities;
using Xunit.Abstractions;

namespace WebApiLearning.UnitTests;

public class UnitTest1(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task Test1()
    {
        var gameItems = new List<GameItem>
        {
            new( Guid.NewGuid(), "Game 1", 19.99 ),
            new( Guid.NewGuid(), "Game 2", 29.99 ),
            new( Guid.NewGuid(), "Game 3", 39.99 )
        };
        var moqCollection = new Mock<IMongoCollection<GameItem>>();

        var mockCursor = new Mock<IAsyncCursor<GameItem>>();
        mockCursor.Setup(_ => _.Current).Returns(gameItems);
        mockCursor.SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(true)
            .ReturnsAsync(false);

        /* moqCollection.Setup(c => c.FindAsync(
         It.IsAny<FilterDefinition<GameItem>>(),
         It.IsAny<FindOptions<GameItem, GameItem>>(),
         CancellationToken.None
        )).ReturnsAsync(mockCursor.Object); */


        moqCollection.Setup(c => c.FindAsync(
         It.IsAny<FilterDefinition<GameItem>>(),
         It.IsAny<FindOptions<GameItem, GameItem>>(),
         It.IsAny<CancellationToken>()
       )).ReturnsAsync((FilterDefinition<GameItem> filter, FindOptions<GameItem, GameItem> options, CancellationToken cancellationToken) =>
        {
            
            var registry = BsonSerializer.SerializerRegistry;
            var serializer = registry.GetSerializer<GameItem>();
            var doc = filter.Render(new RenderArgs<GameItem>(serializer, registry));
            
            var filtered = ApplyFilter(gameItems, filter);
            var mockCursor2 = new Mock<IAsyncCursor<GameItem>>();
            mockCursor2.Setup(cursor => cursor.Current).Returns(filtered);
            mockCursor2.SetupSequence(cursor => cursor.MoveNextAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(true)
                .ReturnsAsync(false);
            return mockCursor2.Object;
        });

        var filter = Builders<GameItem>.Filter;
        // var actual = await (await moqCollection.Object.FindAsync(x => x.Price == 19.99)).ToListAsync();
        var actual = await (await moqCollection.Object.FindAsync(filter.Eq(i => i.Price, 19.99))).ToListAsync();
        
        foreach (var item in actual)
        {
            testOutputHelper.WriteLine(item.Name);
        }

        actual.Count.ShouldBeEquivalentTo(1);
        actual.First().Name.ShouldBe("Game 1");

    }

    static IEnumerable<GameItem> ApplyFilter(IEnumerable<GameItem> src, FilterDefinition<GameItem> filter)
    {
        // 扩展方法 collection.Find(x=> …) 最终会传进来 ExpressionFilterDefinition<T>
        if (filter is ExpressionFilterDefinition<GameItem> exprDef)
        {
            // 注意：ExpressionFilterDefinition<T>.Expression 在 MongoDB.Driver 里是 public
            var expr = exprDef.Expression;
            var pred = expr.Compile();
            return src.Where(pred);
        }

        // 最简兜底：不认识的过滤器就全量返回（必要时你可以扩展对 Eq/Gt/Lt 的支持）
        return src;
    }

}

using ArticleWeb.DataAccess.ArticleDAO;
using ArticleWeb.Services.Test.AericleService;

using Moq;

using NUnit.Framework;

namespace ArticleWeb.Services.Test
{
    internal class ArticleServiceTest
    {
        [Test]
        public void GetProductCategories_EmptyCollection_Test()
        {
            var context = new Mock<IArticleContext>();
            context.Setup(c => c.Articles).Returns(new FakeMongoCollection<Article>());
            var service = new FakeArticleService(context.Object);
            var articles = service.GetArticlesAsync().Result;
            Assert.AreEqual(0, articles.Count);
        }

        [Test]
        public void GetAmount_SetWithTwoElements_TwoReturned()
        {
            var context = new Mock<IArticleContext>();
            context.Setup(c => c.Articles).Returns(new FakeMongoCollection<Article>(new Article(), new Article()));
            var service = new FakeArticleService(context.Object);

            var amount = service.GetArticlesAsync().Result.Count;

            Assert.AreEqual(2, amount);
        }

        [Test]
        public void GetInfo_SetWithTwoElements_TwoElementsListReturned()
        {
            var firstArticle = new Article
            {
                ArticleId = new MongoDB.Bson.ObjectId("5e5c1572cbb45b429ccb9daf")
            };
            var secondArticle = new Article
            {
                ArticleId = new MongoDB.Bson.ObjectId("5e3c1572cbb45b429ccb9daf")
            };

            var context = new Mock<IArticleContext>();
            context.Setup(c => c.Articles).Returns(new FakeMongoCollection<Article>(firstArticle, secondArticle));
            var service = new FakeArticleService(context.Object);

            var list = service.GetArticlesAsync().Result;

            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(list.Exists(x => x.ArticleId == "5e5c1572cbb45b429ccb9daf"));
            Assert.IsTrue(list.Exists(x => x.ArticleId == "5e3c1572cbb45b429ccb9daf"));
        }
    }
}
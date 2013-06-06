namespace CatalogOfFreeContent.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CatalogOfFreeContent.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatalogTests
    {
        #region Add method tests
        [TestMethod]
        public void EmptyCatalogTest()
        {
            Catalog catalog = new Catalog();

            int expectedContentItems = 0;
            Assert.AreEqual(expectedContentItems, catalog.ContentItemsCount, "Catalog is not empty!");
        }

        [TestMethod]
        public void AddSingleItemTest()
        {
            Catalog catalog = new Catalog();
            string[] contentItemParams =
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent contentItem = new ContentItem(ContentType.Application, contentItemParams);

            catalog.Add(contentItem);

            int expectedContentItems = 1;
            Assert.AreEqual(expectedContentItems, catalog.ContentItemsCount, "Invalid content items count!");
        }

        [TestMethod]
        public void AddDuplicateItemTest()
        {
            Catalog catalog = new Catalog();
            string[] contentItemParams =
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" };
            IContent contentItem = new ContentItem(ContentType.Application, contentItemParams);

            catalog.Add(contentItem);
            catalog.Add(contentItem);

            int expectedContentItems = 2;
            Assert.AreEqual(expectedContentItems, catalog.ContentItemsCount, "Invalid content items count!");
        }

        [TestMethod]
        public void AddSingleAndDuplicateItemsTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };
            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);

            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            int expectedContentItems = 7;
            Assert.AreEqual(expectedContentItems, catalog.ContentItemsCount, "Invalid content items count!");
        }
        #endregion

        #region GetListContent method tests
        private static string[] GetTextRepresentationsOfMatchedItems(IEnumerable<IContent> matchedItems)
        {
            string[] textRepresentations = new string[matchedItems.Count()];
            int index = 0;
            foreach (IContent contentItem in matchedItems)
            {
                textRepresentations[index] = contentItem.TextRepresentation;
                index++;
            }

            return textRepresentations;
        }

        [TestMethod]
        public void NoMatchedItemsTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };
            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);
            
            IEnumerable<IContent> matchedItems = catalog.GetListContent("Missing", 1);
            string[] actualTextRepresentations = GetTextRepresentationsOfMatchedItems(matchedItems);
            string[] expectedTextRepresentations = new string[] { };
            
            CollectionAssert.AreEqual(expectedTextRepresentations, actualTextRepresentations);
            Assert.AreEqual(0, matchedItems.Count());
        }

        [TestMethod]
        public void OneMatchedItemTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };
            
            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            IEnumerable<IContent> matchedItems = catalog.GetListContent("Firefox v.11.0", 1);
            string[] actualTextRepresentations = GetTextRepresentationsOfMatchedItems(matchedItems);
            string[] expectedTextRepresentations = new string[] 
            {
                "Application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org"
            };

            CollectionAssert.AreEqual(expectedTextRepresentations, actualTextRepresentations);
            Assert.AreEqual(1, matchedItems.Count());
        }

        [TestMethod]
        public void DuplicateMatchedItemsTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };

            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            IEnumerable<IContent> matchedItems = catalog.GetListContent("Firefox v.11.0", 2);

            string[] actualTextRepresentations = GetTextRepresentationsOfMatchedItems(matchedItems);
            string[] expectedTextRepresentations = new string[] 
            {
                "Application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org",
                "Application: Firefox v.11.0; Mozilla; 16148072; http://www.mozilla.org"
            };

            CollectionAssert.AreEqual(expectedTextRepresentations, actualTextRepresentations);
            Assert.AreEqual(2, matchedItems.Count());
        }

        [TestMethod]
        public void LessThanRequiredMatchedItemsTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };

            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            IEnumerable<IContent> matchedItems = catalog.GetListContent("The Secret", 5);

            string[] actualTextRepresentations = GetTextRepresentationsOfMatchedItems(matchedItems);
            string[] expectedTextRepresentations = new string[]
            {
                "Movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d",
                "Movie: The Secret; Drew Heriot, Sean Byrne & others (2006); 832763834; http://t.co/dNV4d"
            };

            CollectionAssert.AreEqual(expectedTextRepresentations, actualTextRepresentations);
            Assert.AreEqual(2, matchedItems.Count());
        }

        [TestMethod]
        public void MoreThanRequiredMatchedItemsTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };

            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            IEnumerable<IContent> matchedItems = catalog.GetListContent("Intro C#", 2);

            string[] actualTextRepresentations = GetTextRepresentationsOfMatchedItems(matchedItems);
            string[] expectedTextRepresentations = new string[] 
            {
                "Book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info",
                "Book: Intro C#; S.Nakov; 12763892; http://www.introprogramming.info"
            };

            CollectionAssert.AreEqual(expectedTextRepresentations, actualTextRepresentations);
            Assert.AreEqual(2, matchedItems.Count());
        }

        [TestMethod]
        public void MatchedItemsSortTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "One", "Unknown group", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "One", "Metallica", "124124241", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };

            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song1 = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent song2 = new ContentItem(ContentType.Song, contentItemParams[2]);
            IContent song3 = new ContentItem(ContentType.Song, contentItemParams[3]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[4]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[5]);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(song1);
            catalog.Add(song2);
            catalog.Add(song3);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            IEnumerable<IContent> matchedItems = catalog.GetListContent("One", 3);

            string[] actualTextRepresentations = GetTextRepresentationsOfMatchedItems(matchedItems);
            string[] expectedTextRepresentations = new string[] 
            {
                "Song: One; Metallica; 124124241; http://goo.gl/dIkth7gs",
                "Song: One; Metallica; 8771120; http://goo.gl/dIkth7gs",
                "Song: One; Unknown group; 8771120; http://goo.gl/dIkth7gs"
            };

            CollectionAssert.AreEqual(expectedTextRepresentations, actualTextRepresentations);
            Assert.AreEqual(3, matchedItems.Count());
        }
        #endregion

        #region UpdateContent method tests
        public void UpdateNonExistingItemTest()
        {
            Catalog catalog = new Catalog();
            string[] bookParams = 
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" };
            string[] songParams =
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" };
            IContent book = new ContentItem(ContentType.Book, bookParams);
            IContent song = new ContentItem(ContentType.Song, songParams);
            catalog.Add(book);
            catalog.Add(song);

            int updatedItemsCount = catalog.UpdateContent("http://oldurl.org", "http://newurl.org");

            Assert.AreEqual(0, updatedItemsCount);
        }

        [TestMethod]
        public void UpdateSingleItemTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };

            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            int updatedItemsCount = catalog.UpdateContent("http://www.introprogramming.info", "http://newUrl.org");

            Assert.AreEqual(1, updatedItemsCount);
        }

        [TestMethod]
        public void UpdateUpdatedElementTest()
        {
            Catalog catalog = new Catalog();
            List<string[]> contentItemParams = new List<string[]>() 
            {
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" },
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" },
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" },
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" }
            };

            IContent application = new ContentItem(ContentType.Application, contentItemParams[0]);
            IContent song = new ContentItem(ContentType.Song, contentItemParams[1]);
            IContent book = new ContentItem(ContentType.Book, contentItemParams[2]);
            IContent movie = new ContentItem(ContentType.Movie, contentItemParams[3]);
            catalog.Add(application);
            catalog.Add(application);
            catalog.Add(song);
            catalog.Add(book);
            catalog.Add(book);
            catalog.Add(movie);
            catalog.Add(movie);

            int updatedItemsCount = catalog.UpdateContent("http://www.introprogramming.info", "http://newUrl.org");
            Assert.AreEqual(2, updatedItemsCount);

            updatedItemsCount = catalog.UpdateContent("http://newUrl.org", "http://www.introprogramming.info");
            Assert.AreEqual(2, updatedItemsCount);
        }
        #endregion
    }
}

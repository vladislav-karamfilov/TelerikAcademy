namespace BloggingSystem.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Transactions;
    using BloggingSystem.DataTransferObjects;
    using BloggingSystem.Services.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UsersControllerIntegrationTests
    {
        private static TransactionScope transactionScope;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInitialize()
        {
            // Needed to load the assemlies of Services project
            UsersController usersController = new UsersController();

            transactionScope = new TransactionScope();

            var routes = new List<Route>()
            {
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new { controller = "users" })
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void Register_WhenValidUser_ShouldSaveToDatabase()
        {
            var testUser = new UserRegisterModel()
            {
                DisplayName = "Pesho Peshov",
                Username = "Peshov",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var httpResponse = this.httpServer.Post("api/users/register", testUser);
            var loggedUserModel = httpResponse.Content.ReadAsAsync<UserLoggedModel>().Result;

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(loggedUserModel);
            Assert.AreEqual(testUser.DisplayName, loggedUserModel.DisplayName);
            Assert.AreEqual(50, loggedUserModel.SessionKey.Length);
        }

        [TestMethod]
        public void Register_WhenNullUser_ShouldReturnErrorResponse()
        {
            var httpResponse = this.httpServer.Post("api/users/register", null);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserExists_ShouldReturnErrorResponse()
        {
            var testUser1 = new UserRegisterModel()
            {
                DisplayName = "Pesho Peshov",
                Username = "Peshov",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            this.httpServer.Post("api/users/register", testUser1);

            // Existing user
            var testUser2 = new UserRegisterModel()
            {
                DisplayName = "Pesho Peshov",
                Username = "Peshov",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var httpResponse = this.httpServer.Post("api/users/register", testUser2);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Register_WhenInvalidUsername_ShouldReturnErrorResponse()
        {
            var testUser = new UserRegisterModel()
            {
                DisplayName = "Pesho Peshov",
                Username = "Pesho+",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var httpResponse = this.httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenIncorrectSessionKey_ShouldReturnErrorResponse()
        {
            var sessionKey = new string('-', 20);
            IDictionary<string, string> sessionKeyHeader = new Dictionary<string, string>();
            sessionKeyHeader["X-sessionKey"] = sessionKey;

            var httpResponse = this.httpServer.Put("api/users/logout", null, sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenNoUserExistsWithSessionKey_ShouldReturnErrorReponse()
        {
            var sessionKey = new string('A', 50);
            IDictionary<string, string> sessionKeyHeader = new Dictionary<string, string>();
            sessionKeyHeader["X-sessionKey"] = sessionKey;

            var httpResponse = this.httpServer.Put("api/users/logout", null, sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenLoggedUser_ShouldReturnSuccessResponse()
        {
            // First registers a new user and then logins
            var testUser = new UserRegisterModel()
            {
                DisplayName = "Pesho Peshov",
                Username = "Peshov",
                AuthCode = "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e"
            };

            var httpResponse = this.httpServer.Post("api/users/register", testUser);
            var loggedUserModel = httpResponse.Content.ReadAsAsync<UserLoggedModel>().Result;

            // Logout
            IDictionary<string, string> sessionKeyHeader = new Dictionary<string, string>();
            sessionKeyHeader["X-sessionKey"] = loggedUserModel.SessionKey;
            var httpLogoutResponse = this.httpServer.Put("api/users/logout", null, sessionKeyHeader);

            Assert.AreEqual(HttpStatusCode.OK, httpLogoutResponse.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenNoSessionKeyProvided_ShouldReturnErrorResponse()
        {
            var httpResponse = this.httpServer.Put("api/users/logout");

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}

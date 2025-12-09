using AutomationFramework.API.Clients;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Diagnostics;
using System.Net;


namespace AutomationFramework.API.Tests
{
    public  class UserApiTest
    {
        private ApiClient _client;
        private IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _client = new ApiClient(_config);
        }

        [Test]
        public void test()
        {
            RestResponse response = _client.Get("/test");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));  
        }

        [Test]
        public void LoginUser()
        {
            var body = new { username = "emilys", password = "emilyspass" };
            RestResponse response = _client.Post("/auth/login", body);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void InvalidData()
        {
            var body = new { };
            RestResponse response = _client.Post("/auth/login", body);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void InvalidEndpoint()
        {
            var body = new { };
            RestResponse response = _client.Get("/nonexistentendpoint");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void ValidateResponseBody()
        {
            var body = new { username = "emilys", password = "emilyspass" };
            RestResponse response = _client.Post("/auth/login", body);
            var content_json = JObject.Parse(response.Content);
            Assert.That(content_json["firstName"].ToString(), Is.EqualTo("Emily"));
        }

        [Test]
        public void ValidateResponseHeader()
        {
            var body = new { username = "emilys", password = "emilyspass" };
            RestResponse response = _client.Post("/auth/login", body);
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        [Test]
        public void ResoponseTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            RestResponse response = _client.Get("/products");
            stopwatch.Stop();
            var responseTime = stopwatch.Elapsed.Milliseconds;
            Assert.That(responseTime, Is.LessThan(400));
        }

        [Test]
        public void Auth_CorrectToken()
        {
            var body = new { username = "emilys", password = "emilyspass" };
            RestResponse response = _client.Post("/auth/login", body);
            string token = JObject.Parse(response.Content)["accessToken"].ToString();

            RestResponse response2 = _client.Get("/user/me", token); 
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Auth_WrongToken()
        {
            // added letter "w" at the begening
            string token = "weyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwidXNlcm5hbWUiOiJlbWlseXMiLCJlbWFpbCI6ImVtaWx5LmpvaG5z" +
                "b25AeC5kdW1teWpzb24uY29tIiwiZmlyc3ROYW1lIjoiRW1pbHkiLCJsYXN0TmFtZSI6IkpvaG5zb24iLCJnZW5kZXIiOiJmZW1hbGUiLCJpbWFn" +
                "ZSI6Imh0dHBzOi8vZHVtbXlqc29uLmNvbS9pY29uL2VtaWx5cy8xMjgiLCJpYXQiOjE3NjUzMDU1OTAsImV4cCI6MTc2NTMwOTE5MH0.hYFk3lDA" +
                "uFLu3eg65MuLycyFuikN2lqGVsh89GSxACE";

            RestResponse response2 = _client.Get("/user/me", token);
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError)); //wrong token returns InternalServerError, not Unauthorized
        }

        [TestCase("firstname1", "lastname1", 32)]
        [TestCase("firstname2", "lastname2", 65)]
        [TestCase("firstname4", "lastname3", 90)]
        public void AddUser(string firstname, string lastName, int age)
        {
            var body = new { firstName = firstname, lastName = lastName, age= age };
            RestResponse response = _client.Post("/users/add", body);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void MultiRequests()
        {
            for(int i=0; i<50; i++)
            {
                RestResponse response = _client.Get("/products");
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }
    }
}

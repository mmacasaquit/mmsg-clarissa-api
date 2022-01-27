using MMSG_CaseStudy.Config;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MMSG_CaseStudy.StepDefinitions
{
    [Binding]
    public class PostStepDefinitions
    {
        private Settings _settings;
        public PostStepDefinitions(Settings settings) => _settings = settings;

        [Given("I set a POST request for {string}")]
        public void GivenISetAPOSTRequestFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.POST);
        }

        [When("I send a POST request for create user")]
        public void WhenISendAPOSTRequestForCreateUser(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request.AddJsonBody(new { name = data.name.ToString(), job = data.job.ToString() });
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [When("I send a POST request with credentials")]
        public void WhenISendAPOSTRequestWithCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request.AddJsonBody(new { email = data.email.ToString(), password = data.password.ToString() });
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [Then("POST response code should be {int}")]
        public void ThenPostResponseCodeIs(int statusCode)
        {
            Assert.That((int)_settings.Response.StatusCode, Is.EqualTo(statusCode));
            Console.WriteLine(_settings.Response.Content.ToString());
        }

        [Then("Create user response body should contain {string} as name and {string} as job")]
        public void ThenCreateUserResponseBodyShouldContainAsNameAndAsJob(string name, string job)
        {
            JObject obj = JObject.Parse(_settings.Response.Content);
            Assert.That(obj["name"].ToString(), Is.EqualTo(name));
            Assert.That(obj["job"].ToString(), Is.EqualTo(job));
        }

        [Then("POST response body contains error with {string} message")]
        public void ThenPOSTResponseBodyContainsErrorWithMessage(string msg)
        {
            JObject obj = JObject.Parse(_settings.Response.Content);
            Assert.That(obj["error"].ToString(), Is.EqualTo(msg));
        }

        [Then("POST reponse body contains auth token {string}")]
        public void ThenPOSTReponseBodyContainsAuthToken(string token)
        {
            JObject obj = JObject.Parse(_settings.Response.Content);
            Assert.That(obj["token"].ToString(), Is.EqualTo(token));
        }



    }
}

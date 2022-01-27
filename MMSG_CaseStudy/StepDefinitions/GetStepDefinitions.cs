using MMSG_CaseStudy.Config;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MMSG_CaseStudy.StepDefinitions
{
    [Binding]
    public class GetStepDefinitions
    {
        private Settings _settings;
        public GetStepDefinitions (Settings settings) => _settings = settings;

        [When("I send a GET request for user page {string}")]
        public void WhenISendAGETRequestForUserPage(string page)
        {
            _settings.Request.AddQueryParameter("page", page);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [When("I send a GET request for user {string}")]
        public void WhenISendAGETRequestForUser(string userid)
        {
            _settings.Request.AddUrlSegment("userid", userid);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [Then("I should see the data {string} value as {string}")]
        public void ThenIShouldSeeTheDataValueAs(string key, string value)
        {
            Console.WriteLine(_settings.Response.Content.ToString());
            JObject obj = JObject.Parse(_settings.Response.Content);
            Assert.That(obj["data"][key].ToString(), Is.EqualTo(value));
        }

    }

}

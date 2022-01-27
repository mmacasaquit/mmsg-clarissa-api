using MMSG_CaseStudy.Config;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MMSG_CaseStudy.StepDefinitions
{
    [Binding]
    public class DeleteStepDefinitions
    {
        private Settings _settings;
        public DeleteStepDefinitions(Settings settings) => _settings = settings;

        [Given("I set a DELETE request for {string}")]
        public void GivenISetADELETERequestFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.DELETE);
        }

        [When("I send a DELETE request for user {string}")]
        public void WhenISendADELETERequestForUser(string userid)
        {
            _settings.Request.AddUrlSegment("userid", userid);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [Then("DELETE response code should be {int}")]
        public void ThenDELETEResponseCodeShouldBe(int statusCode)
        {
            Assert.That((int)_settings.Response.StatusCode, Is.EqualTo(statusCode));
        }

    }
}

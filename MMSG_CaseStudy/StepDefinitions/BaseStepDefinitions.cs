using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using MMSG_CaseStudy.Config;
using RestSharp;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json.Linq;

namespace MMSG_CaseStudy.StepDefinitions
{
    [Binding]
    public class BaseStepDefinitions
    {

        private Settings _settings;
        public BaseStepDefinitions(Settings settings) => _settings = settings;

        [Given("A {string} for endpoint {string}")]
        public void GivenISetARequestFor(string method, string url)
        {
            if (method == "GET")
            {
                _settings.Request = new RestRequest(url, Method.GET); ;
            }
            else if (method == "POST")
            {
                _settings.Request = new RestRequest(url, Method.POST);
            }
            else if (method == "DELETE")
            {
                _settings.Request = new RestRequest(url, Method.DELETE);
            }
            else
            {
                throw new Exception("Method not supported!");
            }
           
        }

        [Then("Response code should be {int}")]
        public void ThenResponseCodeShouldBe(int statusCode)
        {
            Assert.That((int)_settings.Response.StatusCode, Is.EqualTo(statusCode));
        }

        [Then("Response body should contain correct values")]
        public void ThenResponseBodyShouldContainCorrectValues(Table table)
        {
            IEnumerable<dynamic> data = table.CreateDynamicSet();

            Console.WriteLine(_settings.Response.Content.ToString());
            foreach (var row in data)
            {
                JObject obj = JObject.Parse(_settings.Response.Content);
                Assert.That(obj[row.key.ToString()].ToString(), Is.EqualTo(row.value.ToString()));
            }
        }
    }
}

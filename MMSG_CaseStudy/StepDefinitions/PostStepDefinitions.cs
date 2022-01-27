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

    }
}

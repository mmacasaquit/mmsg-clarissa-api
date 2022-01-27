using MMSG_CaseStudy.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG_CaseStudy.Hooks
{
    [Binding]
    public class Init
    {
        private Settings _settings;
        public Init (Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void ApiSetup()
        {
            _settings.BaseUrl = new Uri("https://reqres.in/api/");
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }

    }
}

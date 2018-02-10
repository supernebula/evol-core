using Evol.TMovie.Manage.Apis;
using Evol.TMovie.Domain.Commands.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;
using System.Diagnostics;
using Evol.Configuration;

namespace Evol.TMovie.Manage.Tests.Controllers
{
    public class CnemaApiControllerTest : IDisposable
    {
        private ITestOutputHelper output;

        private CinemaApiController _apiController;

        public CnemaApiControllerTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
            //`Startup.Init();
            _apiController = AppConfig.Current.IoCManager.GetService<CinemaApiController>();

        }

        [Fact]
        public void CreateTest()
        {
            var dto = new CinemaCreateDto()
            {
                Name = "UME Cinema_" + DateTime.Now.Minute + DateTime.Now.Second,
                Address = "WenYiXiLu #552-" +DateTime.Now.Second
            };

            TestUtil.AssertSync(() => _apiController.Post(dto), output);

        }

        public void Dispose()
        {
            //`Startup.Clear();
          
        }
    }
}

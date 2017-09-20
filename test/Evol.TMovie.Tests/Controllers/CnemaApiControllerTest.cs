using Evol.Domain;
using Evol.TMovie.Manage.Apis;
using Evol.TMovie.Domain.Commands.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Evol.TMovie.Manage.Tests.Controllers
{
    public class CnemaApiControllerTest : IDisposable
    {
        private ITestOutputHelper output;

        private CinemaApiController _apiController;

        public CnemaApiControllerTest(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
            Startup.Init();
            _apiController = AppConfig.Current.IoCManager.GetService<CinemaApiController>();

        }

        [Fact]
        public void CreateTest()
        {
            var dto = new CinemaCreateDto()
            {
                Name = "UME Cinema",
                Address = "WenYiXiLu #552"
            };

            TestUtil.AssertSync(() => _apiController.Post(dto), output);

            //_apiController.Post(dto)
            //    .ContinueWith(t =>
            //    {
            //        if (t.IsFaulted)
            //        {

            //            Trace.WriteLine(t.Exception.Message + "\r\n" + t.Exception.StackTrace);
            //        }
            //        Assert.True(t.IsCompletedSuccessfully);
            //    }).GetAwaiter().GetResult();

        }

        public void Dispose()
        {
            Startup.Clear();
          
        }
    }
}

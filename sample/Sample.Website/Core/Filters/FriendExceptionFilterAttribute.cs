using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Website.Core.Filters
{
    public class FriendExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public FriendExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var result = context.Result;

            return Task.FromResult(1);

            //if (!_hostingEnvironment.IsDevelopment())
            //{
            //    // do nothing
            //    return;
            //}
            //var result = new ViewResult { ViewName = "CustomError" };
            //result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            //result.ViewData.Add("Exception", context.Exception);
            //// TODO: Pass additional detailed data via ViewData
            //context.Result = result;
        }
    }
}

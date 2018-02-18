using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Domain.Messaging;
using Evol.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Commands.Dto;
using Sample.Domain.Dto;
using Sample.Domain.QueryEntries;
using Sample.Domain.QueryEntries.Parameters;
using Sample.Website.Models.PostViewModels;
using Sample.Domain.Commands;

namespace Sample.Website.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsApiController : Controller
    {
        public IPostQueryEntry PostQuery { get; private set; }

        public ICommentQueryEntry CommentQuery { get; private set; }

        public ICommandBus CommandBus { get; private set; }

        public PostsApiController(IPostQueryEntry postQuery, ICommentQueryEntry commentQuery, ICommandBus commandBus)
        {
            PostQuery = postQuery;
            CommentQuery = commentQuery;
            CommandBus = commandBus;
        }

        #region Post 操作

        //// GET: api/PostApi
        //[HttpGet]
        //[Route("List")]
        //public async Task<IEnumerable<PostViewModel>> List(PostQueryParameter param)
        //{
        //    var items = await PostQuery.SelectAsync(param);
        //    var result = items.MapList<PostViewModel>();
        //    return result;
        //}

        // GET: api/PostApi/5
        [HttpGet("{id}")]
        [Route("Item")]
        public async Task<PostViewModel> Get(Guid id)
        {
            var item = await PostQuery.FindAsync(id);
            var result = item.Map<PostViewModel>();
            return result;
        }

        // POST: api/PostApi
        [HttpPost]
        public async Task Post(PostCreateDto dto)
        {
            //if (ModelState.IsValid())
            //    throw new InputError();
            var command = new PostCreateCommand() { Input = dto };
            await CommandBus.SendAsync(command);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(ItemDeleteDto dto)
        {
            var command = new PostDeleteCommand() { Input = dto };
            await CommandBus.SendAsync(command);
        }

        #endregion

        //#region Comment 操作

        //// GET: api/PostApi
        //[HttpGet]
        //[Route("CommentList")]
        //public async Task<IEnumerable<CommentViewModel>> List(CommentQueryParameter param)
        //{
        //    var items = await CommentQuery.SelectAsync(param);
        //    var result = items.MapList<CommentViewModel>();
        //    return result;
        //}

        //// GET: api/PostApi/5
        //[HttpGet("{id}")]
        //[Route("Comment")]
        //public async Task<CommentViewModel> Comment(Guid id)
        //{
        //    var item = await CommentQuery.FindAsync(id);
        //    var result = item.Map<CommentViewModel>();
        //    return result;
        //}

        //// POST: api/PostApi
        //[HttpPost()]
        //[Route("Comment")]
        //public async Task Post(CommentCreateDto dto)
        //{
        //    //if (ModelState.IsValid())
        //    //    throw new InputError();
        //    var command = new CommentCreateCommand() { Input = dto };
        //    await CommandBus.SendAsync(command);
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //[Route("Comment")]
        //public async Task Comment(ItemDeleteDto dto)
        //{
        //    var command = new CommentDeleteCommand() { Input = dto };
        //    await CommandBus.SendAsync(command);
        //}

        //#endregion
    }
}

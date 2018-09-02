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
using Evol.Common;
using Evol.Common.Exceptions;

namespace Sample.Website.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsApiController : BaseApiController
    {
        protected IPostQueryEntry PostQuery { get; private set; }

        protected ICommentQueryEntry CommentQuery { get; private set; }

        protected ICommandBus CommandBus { get; private set; }

        /// <summary>
        /// 帖子控制器
        /// </summary>
        /// <param name="postQuery"></param>
        /// <param name="commentQuery"></param>
        /// <param name="commandBus"></param>
        public PostsApiController(IPostQueryEntry postQuery, ICommentQueryEntry commentQuery, ICommandBus commandBus)
        {
            PostQuery = postQuery;
            CommentQuery = commentQuery;
            CommandBus = commandBus;
        }

        /// <summary>
        /// 分页获取帖子列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IPaged<PostViewModel>> Paged(int pageIndex = 1, int pageSize = 10, PostQueryParameter param = null)
        {
            var result = await PostQuery.PagedAsync(pageIndex, pageSize, param);
            var paged = result.MapPaged<PostViewModel>();
            return paged;
        }

        /// <summary>
        /// 获取帖子列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<PostViewModel>> List(PostQueryParameter param)
        {
            var items = await PostQuery.SelectAsync(param);
            var result = items.MapList<PostViewModel>();
            return result;
        }

        /// <summary>
        /// 获取单条帖子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<PostViewModel> Get(Guid id)
        {
            var item = await PostQuery.FindAsync(id);
            var result = item.Map<PostViewModel>();
            return result;
        }

        /// <summary>
        /// 创建帖子
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(PostCreateDtoParam param)
        {
            ValidateModelOrThrow();
            //PostQuery.SelectAsync(title)
                throw new InputError("title 不能重复！");
            var command = new PostCreateCommand() { Input = new PostCreateDto(param) };
            await CommandBus.SendAsync(command);
        }

        /// <summary>
        /// 删除单条帖子
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(ItemDeleteDto dto)
        {
            var command = new PostDeleteCommand() { Input = dto };
            await CommandBus.SendAsync(command);
        }

        #region Comment 操作

        /// <summary>
        /// 分页获取评论列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Comment/[action]")]
        public async Task<IPaged<CommentViewModel>> Paged(int pageIndex = 1, int pageSize = 10, CommentQueryParameter param = null)
        {
            var result = await CommentQuery.PagedAsync(pageIndex, pageSize, param);
            var paged = result.MapPaged<CommentViewModel>();
            return paged;
        }


        /// <summary>
        /// 查询帖子评论列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Comment/List")]
        public async Task<IEnumerable<CommentViewModel>> CommentList(CommentQueryParameter param)
        {
            var items = await CommentQuery.SelectAsync(param);
            var result = items.MapList<CommentViewModel>();
            return result;
        }

        /// <summary>
        /// 获取单条评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Comment/{id}")]
        public async Task<CommentViewModel> CommentGet(Guid id)
        {
            var item = await CommentQuery.FindAsync(id);
            var result = item.Map<CommentViewModel>();
            return result;
        }

        /// <summary>
        /// 创建评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Comment")]
        public async Task CommentPost(CommentCreateDto dto)
        {
            ValidateModelOrThrow();
            var command = new CommentCreateCommand() { Input = dto };
            await CommandBus.SendAsync(command);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Comment/{id}")]
        public async Task CommentDelete(Guid id)
        {
            var dto = new ItemDeleteDto() { Id = id };
            var command = new CommentDeleteCommand() { Input = dto };
            await CommandBus.SendAsync(command);
        }

        #endregion
    }
}

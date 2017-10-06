using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Domain.Messaging;
using Evol.TMovie.Manage.Models;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Manage.Apis
{
    /// <summary>
    /// 电影管理 API
    /// </summary>
    [Route("api/movie")]
    public class MovieApiController : ApiBaseController
    {
        public IMovieQueryEntry MovieQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public MovieApiController(IMovieQueryEntry movieQueryEntry, ICommandBus commandBus)
        {
            MovieQueryEntry = movieQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/movie
        /// <summary>
        /// 查询电影列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<MovieViewModel>> GetList([FromQuery]MovieQueryParameter param = null)
        {
            var list = await MovieQueryEntry.SelectAsync(param);
            var result = list.Map<List<MovieViewModel>>();
            return result;
        }

        // GET: api/Movie/Paged
        /// <summary>
        /// 分页查询电影列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Paged")]
        public async Task<IPaged<MovieViewModel>> Get([FromQuery]MovieQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await MovieQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<MovieViewModel>();
            return result;
        }

        // GET: api/Movie/5
        /// <summary>
        /// 获取指定电影
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MovieViewModel> Get(Guid id)
        {
            var item = await MovieQueryEntry.FindAsync(id);
            var result = item.Map<MovieViewModel>();
            return result;
        }

        // POST: api/Movie
        /// <summary>
        /// 创建电影
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(MovieCreateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new MovieCreateCommand { Input = value });
        }

        // PUT: api/Movie/5
        /// <summary>
        /// 更新电影
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task Put(Guid id, MovieUpdateDto value)
        {
            ThrowIfNotModelIsValid();
            await CommandBus.SendAsync(new MovieUpdateCommand { Input = value });
        }

        // DELETE: api/Movie/5
        /// <summary>
        /// 删除电影
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await CommandBus.SendAsync(new MovieDeleteCommand { Input = new ItemDeleteDto { Id = id } });
        }
    }
}

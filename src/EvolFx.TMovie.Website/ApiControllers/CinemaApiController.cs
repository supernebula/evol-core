using System;
using System.Collections.Generic;
using System.Web.Http;
using Evol.Domain.Dto;
using Evol.Common;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System.Threading.Tasks;
using EvolFx.TMovie.Website.Models.CinemaViewModels;

namespace EvolFx.TMovie.Website.ApiControllers
{
    [Route("api/Cinema")]
    public class CinemaApiController : ApiController
    {

        public ICinemaQueryEntry CinemaQuery { get; private set; }

        public IScheduleQueryEntry ScheduleQuery { get; private set; }

        public CinemaApiController(ICinemaQueryEntry cinemaQueryEntry, IScheduleQueryEntry screeningQuery)
        {
            CinemaQuery = cinemaQueryEntry;
            ScheduleQuery = screeningQuery;
        }

        /// <summary>
        /// 分页获取影院信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Cinema/Paged")]
        public async Task<IPaged<CinemaViewModel>> Paged(int pageIndex = 1, int pageSize = 10, CinemaQueryParameter param = null)
        {
            var result = await CinemaQuery.PagedAsync(param, pageIndex, pageSize);
            var paged = result.MapPaged<CinemaViewModel>();
            return paged;
        }

        /// <summary>
        /// 获取影院信息
        /// </summary>
        /// <param name="id">cinemaId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<CinemaViewModel> GetById(Guid id)
        {
            var item = await CinemaQuery.FindAsync(id);
            var value = item.Map<CinemaViewModel>();
            return value;
        }

        /// <summary>
        /// 获取上映电影
        /// </summary>
        /// <param name="id">cinemaId</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Cinema/Show/{id}")]
        public async Task<ShowMovieViewModel> Screening(Guid id)
        {
            var items = await CinemaQuery.SelectShowingMoiveAsync(id);
            var value = items.Map<ShowMovieViewModel>();
            return value;
        }

        /// <summary>
        /// 获取排片计划
        /// </summary>
        /// <param name="id">cinemaId</param>
        /// <param name="movieId">movieId</param>
        /// <returns></returns>
        [Route("api/Cinema/Sched/{id}")]
        public async Task<List<ScheduleViewModel>> Schedule(Guid id, Guid movieId)
        {
            var item = await ScheduleQuery.SelectAsync(new ScheduleQueryParameter { CinemaId = id });
            var values = item.MapList<ScheduleViewModel>();
            return values;
        }
    }
}

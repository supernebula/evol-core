using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Evol.Common;
using Evol.TMovie.Website.Models.CinemaViewModels;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;

namespace Evol.TMovie.Website.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Cinema")]
    public class CinemaController : Controller
    {
        public ICinemaQueryEntry _cinemaQuery { get; set; }
        public CinemaController(ICinemaQueryEntry cinemaQueryEntry)
        {
            _cinemaQuery = cinemaQueryEntry;
        }


        public async Task<IPaged<CinemaViewModel>> Paged(int pageIndex = 1, int pageSize = 10, CinemaQueryParameter param = null)
        {
            var result = await _cinemaQuery.PagedAsync(param, pageIndex, pageSize);
            var paged = result.MapPaged<CinemaViewModel>();
            return paged;
        }
    }
}
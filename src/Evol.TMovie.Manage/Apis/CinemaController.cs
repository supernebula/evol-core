using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Domain.Messaging;
using Evol.TMovie.Manage.Models;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evol.TMovie.Manage.Apis
{
    [Route("api/[controller]")]
    public class CinemaController : Controller
    {
        public ICinemaQueryEntry CinemaQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public CinemaController(ICinemaQueryEntry cinemaQueryEntry, ICommandBus commandBus)
        {
            CinemaQueryEntry = cinemaQueryEntry;
            CommandBus = commandBus;
        }

        // GET: api/Cinema
        [HttpGet]
        public async Task<IEnumerable<CinemaViewModel>> Get(CinemaQueryParameter param = null)
        {
            var list = await CinemaQueryEntry.RetrieveAsync(param);
            var result = list.Map<List<CinemaViewModel>>();
            return result;
        }

        // GET: api/Cinema/Paged
        [Route("Paged")]
        public async Task<IPaged<CinemaViewModel>> Get(CinemaQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await CinemaQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<CinemaViewModel>();
            return result;
        }

        // GET: api/Cinema/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<CinemaViewModel> Get(Guid id)
        {
            var item = await CinemaQueryEntry.FindAsync(id);
            var result = item.Map<CinemaViewModel>();
            return result;
        }

        // POST: api/Cinema
        [HttpPost]
        public Task Post(CinemaCreateDto value)
        {
            if (TryValidateModel(value))
            {
                return Task.FromResult(1);
                //return ModelState;
            }
            return Task.FromResult(1);
        }

        // PUT: api/Cinema/5
        [HttpPut("{id}")]
        public void Put(int id, CinemaUpdateDto value)
        {
        }

        // DELETE: api/Cinema/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

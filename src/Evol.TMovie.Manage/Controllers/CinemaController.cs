using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Manage.Models;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Dto;

namespace Evol.TMovie.Manage.Controllers
{
    public class CinemaController : Controller
    {
        public ICinemaQueryEntry CinemaQueryEntry { get; set; }

        public ICommandBus CommandBus { get; set; }

        public CinemaController(ICinemaQueryEntry cinemaQueryEntry, ICommandBus commandBus)
        {
            CinemaQueryEntry = cinemaQueryEntry;
            CommandBus = commandBus;
        }

        // GET: Cinema
        public async Task<IActionResult> Index(CinemaQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await CinemaQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<CinemaViewModel>();
            return View(result);
        }

        // GET: Cinema/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var item = await CinemaQueryEntry.FindAsync(id);
            return View(item);
        }

        // GET: Cinema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinema/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CinemaCreateDto dto, string vertyCode)
        {
            if (! await TryUpdateModelAsync(dto))
            {
                return View(dto);
            }

            await CommandBus.SendAsync(new CinemaCreateCommand() { Input = dto });

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 查找影院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await CinemaQueryEntry.FindAsync(id);
            return View(item);
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaUpdateDto dto)
        {
            if (!await TryUpdateModelAsync(dto))
            {
                return View(dto);
            }
            await CommandBus.SendAsync(new CinemaUpdateCommand() { Input = dto });
            this.ModelState.AddModelError(string.Empty, "Success!");
            return View(dto);
        }

        /// <summary>
        /// 删除影院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            await CommandBus.SendAsync(new CinemaDeleteCommand() { Input = new ItemDeleteDto() { Id = id } });
            return true;
        }

    }
}
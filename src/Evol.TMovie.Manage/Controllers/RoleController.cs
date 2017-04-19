using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Manage.Models;

namespace Evol.TMovie.Manage.Controllers
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        private IRoleQueryEntry _roleQueryEntry { get; set; }

        private ICommandBus _commandBus { get; set; }

        public RoleController(IRoleQueryEntry roleQueryEntry, ICommandBus commandBus)
        {
            _roleQueryEntry = roleQueryEntry;
            _commandBus = commandBus;
        }
        // GET: Cinema
        public async Task<IActionResult> Index(RoleQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await _roleQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<RoleViewModel>();
            return View(result);
        }

        // GET: Cinema/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var item = await _roleQueryEntry.FindAsync(id);
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
        public async Task<IActionResult> Create(CinemaCreateOrUpdateDto dto)
        {
            if (!await TryUpdateModelAsync(dto))
            {
                return View(dto);
            }

            await CommandBus.SendAsync(new CinemaCreateCommand() { Input = dto });

            return RedirectToAction("Index");
        }

        // GET: Cinema/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await CinemaQueryEntry.FindAsync(id);
            return View(item);
        }

        // POST: Cinema/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CinemaCreateOrUpdateDto dto)
        {
            if (!await TryUpdateModelAsync(dto))
            {
                return View(dto);
            }
            await CommandBus.SendAsync(new CinemaUpdateCommand() { Input = dto });
            this.ModelState.AddModelError(string.Empty, "Success!");
            return View(dto);
        }

        // GET: Cinema/Delete/5
        public async Task<bool> Delete(Guid id)
        {
            await CommandBus.SendAsync(new CinemaDeleteCommand() { Input = new CinemaDeleteDto() { Id = id } });
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Domain.Messaging;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Commands.Dto;
using Evol.TMovie.Domain.Commands;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Manage.Models;

namespace Evol.TMovie.Manage.Controllers
{
    [Produces("application/json")]
    [Route("api/Permission")]
    public class PermissionController : Controller
    {
        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private ICommandBus _commandBus { get; set; }

        public PermissionController(IPermissionQueryEntry permissionQueryEntry, ICommandBus commandBus)
        {
            _permissionQueryEntry = permissionQueryEntry;
            _commandBus = commandBus;
        }
        // GET: Cinema
        public async Task<IActionResult> Index(PermissionQueryParameter param = null, int pageIndex = 1, int pageSize = 10)
        {
            var paged = await _permissionQueryEntry.PagedAsync(param, pageIndex, pageSize);
            var result = paged.MapPaged<PermissonViewModel>();
            return View(result);
        }

        // GET: Cinema/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var item = await _permissionQueryEntry.FindAsync(id);
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
        public async Task<IActionResult> Create(PermissionCreateOrUpdateDto dto)
        {
            if (!await TryUpdateModelAsync(dto))
            {
                return View(dto);
            }

            await _commandBus.SendAsync(new PermissionCreateCommand() { Input = dto });

            return RedirectToAction("Index");
        }

        // GET: Cinema/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _permissionQueryEntry.FindAsync(id);
            return View(item);
        }

        // POST: Cinema/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PermissionCreateOrUpdateDto dto)
        {
            if (!await TryUpdateModelAsync(dto))
            {
                return View(dto);
            }
            await _commandBus.SendAsync(new PermissionUpdateCommand() { Input = dto });
            this.ModelState.AddModelError(string.Empty, "Success!");
            return View(dto);
        }

        // GET: Cinema/Delete/5
        public async Task<bool> Delete(Guid id)
        {
            await _commandBus.SendAsync(new PermissionDeleteCommand() { Input = new ItemDeleteDto() { Id = id } });
            return true;
        }
    }
}

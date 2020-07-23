using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_Management_System.Contracts;
using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class CatalogTypeController : Controller
    {
        private readonly ICatalogTypeRepository _repo;
        private readonly IMapper _mapper;

        public CatalogTypeController(ICatalogTypeRepository repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }

        // GET: CatalogTypeController
        public ActionResult Index()
        {
            var CatalogTypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<CatalogType>, List<CatalogTypeVM>>(CatalogTypes);
            return View(model);
        }

        // GET: CatalogTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var CatalogType = _repo.FindById(id);
            var model = _mapper.Map<CatalogTypeVM>(CatalogType);
            return View(model);
        }

        // GET: CatalogTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatalogTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                var CatalogType = _mapper.Map<CatalogType>(model);
                var isSucess = _repo.Create(CatalogType);

                if (!isSucess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }




                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: CatalogTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var Catalog = _repo.FindById(id);
            var model = _mapper.Map<CatalogVM>(Catalog);
            return View(model);
        }

        // POST: CatalogTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatalogTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var CatalogType = _mapper.Map<CatalogType>(model);
                var isSucess = _repo.Update(CatalogType);
                if (!isSucess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: CatalogTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var CatalogType = _repo.FindById(id);
            if (CatalogType == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(CatalogType);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CatalogTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CatalogTypeVM model)
        {
            try
            {
                var CatalogType = _repo.FindById(id);
                if (CatalogType == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(CatalogType);
                if (!isSucess)
                {

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }

        }
    }
}

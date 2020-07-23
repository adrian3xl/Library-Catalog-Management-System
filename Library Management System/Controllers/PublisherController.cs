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
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _repo;
        private readonly IMapper _mapper;


        public PublisherController(IPublisherRepository repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }
        // GET: PublisherController
        public ActionResult Index()
        {
            var publisher = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Publisher>, List<PublisherVM>>(publisher);
            return View(model);
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var publisher = _repo.FindById(id);
            var model = _mapper.Map<PublisherVM>(publisher);
            return View(model);
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherVM model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var publisher = _mapper.Map<Publisher>(model);
                var isSucess = _repo.Create(publisher);

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

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var publisher = _repo.FindById(id);
            var model = _mapper.Map<PublisherVM>(publisher);
            return View(model);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublisherVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var publisher = _mapper.Map<Publisher>(model);
                var isSucess = _repo.Update(publisher);
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

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            var publisher = _repo.FindById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(publisher);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: PublisherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PublisherVM model)
        {
            try
            {
                var publisher = _repo.FindById(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(publisher);
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
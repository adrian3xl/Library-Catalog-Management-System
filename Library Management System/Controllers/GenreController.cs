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
    public class GenreController : Controller
    {
        private readonly IGenreRepository _repo;
        private readonly IMapper _mapper;
       
        public GenreController(IGenreRepository repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
         }

        
        // GET: Genre

        public ActionResult Index()
        {
            var Genres = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Genre>, List<GenreVM>>(Genres);
            return View(model);
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var genre = _repo.FindById(id);
            var model = _mapper.Map<GenreVM>(genre);
            return View(model);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }



                var Genre = _mapper.Map<Genre>(model);
                var isSucess = _repo.Create(Genre);

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

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var Genre = _repo.FindById(id);
            var model = _mapper.Map<GenreVM>(Genre);
            return View(model);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GenreVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var author = _mapper.Map<Genre>(model);
                var isSucess = _repo.Update(author);
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

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            var Genre = _repo.FindById(id);
            if (Genre == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(Genre);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Genre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, GenreVM model)
        {
            try
            {
                var Genre = _repo.FindById(id);
                if (Genre == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(Genre);
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
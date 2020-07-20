using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_Management_System.Contracts;
using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _repo;
        private readonly IMapper _mapper;


        public AuthorController(IAuthorRepository repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            var Authors = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Author>, List<AuthorVM>>(Authors);
            return View(model);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var author = _repo.FindById(id);
            var model = _mapper.Map<AuthorVM>(author);
            return View(model);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorVM model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //  var Employer = _empManager.GetUserAsync(User).Result;

                // model.EmployerId = Employer.Id;

                var author = _mapper.Map<Author>(model);
                var isSucess = _repo.Create(author);

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

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var author = _repo.FindById(id);
            var model = _mapper.Map<AuthorVM>(author);
            return View(model);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var author = _mapper.Map<Author>(model);
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

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = _repo.FindById(id);
            if (author == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(author);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }


        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuthorVM model)
        {
            try
            {
                var author = _repo.FindById(id);
                if (author == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(author);
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
    


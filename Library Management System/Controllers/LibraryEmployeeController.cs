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
    public class LibraryEmployeeController : Controller
    {
        private readonly ILibraryEmployeeRepository _repo;
        private readonly IMapper _mapper;


        public LibraryEmployeeController(ILibraryEmployeeRepository repo, IMapper mapper )
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LibraryEmployeeController
        public ActionResult Index()
        {
            var libraryEmployee = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LibraryEmployee>, List<LibraryEmployeeVM>>(libraryEmployee);
            return View(model);
        }

        // GET: LibraryEmployeeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var libraryEmployee = _repo.FindById(id);
            var model = _mapper.Map<LibraryEmployeeVM>(libraryEmployee);
            return View(model);
        }

        // GET: LibraryEmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibraryEmployeeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var libraryEmployee = _mapper.Map<LibraryEmployee>(model);
                var isSucess = _repo.Create(libraryEmployee);

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

        // GET: LibraryEmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var libraryEmployee = _repo.FindById(id);
            var model = _mapper.Map<LibraryEmployeeVM>(libraryEmployee);
            return View(model);
        }

        // POST: LibraryEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LibraryEmployeeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var libraryEmployee = _mapper.Map<LibraryEmployee>(model);
                var isSucess = _repo.Update(libraryEmployee);
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

        // GET: LibraryEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var libraryEmployee = _repo.FindById(id);
            if (libraryEmployee == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(libraryEmployee);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LibraryEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LibraryEmployeeVM model)
        {
            try
            {
                var libraryEmployee = _repo.FindById(id);
                if (libraryEmployee == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(libraryEmployee);
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
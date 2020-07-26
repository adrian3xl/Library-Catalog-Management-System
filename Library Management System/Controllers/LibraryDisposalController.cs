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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class LibraryDisposalController : Controller
    {
        private readonly ILibraryDisposalRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<LibraryEmployee> _userManager;
        public LibraryDisposalController(ILibraryDisposalRepository repo, IMapper mapper, UserManager<LibraryEmployee> userManager)
        {

            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: LibraryDisposalController
        public ActionResult Index()
        {
            var LibraryDisposals = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LibraryDisposal>, List<LibraryDisposalVM>>(LibraryDisposals);
            return View(model);
        }

        // GET: LibraryDisposalController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var LibraryDisposals = _repo.FindById(id);
            var model = _mapper.Map<LibraryDisposalVM>(LibraryDisposals);
            return View(model);
        }

        // GET: LibraryDisposalController/Create
        public ActionResult Create()
        {

            var libraryEmployee = _userManager.GetUserAsync(User).Result;

            var model = new LibraryDisposalVM
            {
                LibraryEmployeeId = libraryEmployee.Id

            };

            return View(model);
        }

        // POST: LibraryDisposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibraryDisposalVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                var LibraryDisposals = _mapper.Map<LibraryDisposal>(model);
                var isSucess = _repo.Create(LibraryDisposals);

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

        // GET: LibraryDisposalController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var LibraryDisposal = _repo.FindById(id);
            var model = _mapper.Map<LibraryDisposalVM>(LibraryDisposal);

            var libraryEmployee = _userManager.GetUserAsync(User).Result;

            model.LibraryEmployeeId = libraryEmployee.Id;

            return View(model);
        }

        // POST: LibraryDisposalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LibraryDisposalVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var LibraryDisposal = _mapper.Map<LibraryDisposal>(model);
                var isSucess = _repo.Update(LibraryDisposal);
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

        // GET: LibraryDisposalController/Delete/5
        public ActionResult Delete(int id)
        {
            var LibraryDisposal = _repo.FindById(id);
            if (LibraryDisposal == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(LibraryDisposal);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
            
        }

        // POST: LibraryDisposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LibraryDisposalVM model)
        {
            try
            {
                var LibraryDisposal = _repo.FindById(id);
                if (LibraryDisposal == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(LibraryDisposal);
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
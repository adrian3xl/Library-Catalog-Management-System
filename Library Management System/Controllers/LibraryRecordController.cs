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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class LibraryRecordController : Controller
    {

        private readonly ILibraryRecordRepository _repo;
        private readonly ILibraryEmployeeRepository _libraryEmployeeRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IPublisherRepository _publisherRepo;
        private readonly ICatalogRepository _catalogRepo;
        private readonly UserManager<LibraryEmployee> _userManager;

        private readonly IMapper _mapper;


        public LibraryRecordController(ILibraryRecordRepository repo, ILibraryEmployeeRepository libraryEmployeeRepo, IPublisherRepository publisherRepo,IAuthorRepository authorRepo
            , ICatalogRepository catalogRepo, IMapper mapper, UserManager<LibraryEmployee> userManager)
        {
            _userManager = userManager;
            _repo = repo;
            _catalogRepo = catalogRepo;
            _libraryEmployeeRepo = libraryEmployeeRepo;
            _authorRepo = authorRepo;
            _publisherRepo = publisherRepo;
            _mapper = mapper;
        }



        // GET: LibraryRecordController
        public ActionResult Index()
        {
            var libraryRecord = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LibraryRecord>, List<LibraryRecordVM>>(libraryRecord);
            return View(model);
        }

        // GET: LibraryRecordController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var libraryRecord = _repo.FindById(id);
            var model = _mapper.Map<LibraryRecordVM>(libraryRecord);
            return View(model);
        }

        // GET: LibraryRecordController/Create
        public ActionResult Create()
        {
            var catalog = _catalogRepo.FindAll();

            var catalogTypeItems = catalog.Select(q => new SelectListItem
            {
                Text = $"{q.Title}",

                Value = q.Id.ToString()
            });


            var model = new LibraryRecordVM
            {
                
                Catalogs= catalogTypeItems
            };
            return View(model);

        }

        // POST: LibraryRecordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibraryRecordVM model)
        {


            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var libraryEmployee = _userManager.GetUserAsync(User).Result;
                model.LibraryEmployeeId = libraryEmployee.Id;

                var libraryRecord = _mapper.Map<LibraryRecord>(model);
                var isSucess = _repo.Create(libraryRecord);

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

        // GET: LibraryRecordController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }

            var libraryRecord = _repo.FindById(id);
            var model = _mapper.Map<LibraryRecordVM>(libraryRecord);
            var catalog = _catalogRepo.FindAll();

            var catalogTypeItems = catalog.Select(q => new SelectListItem
            {
                Text = $"{q.Title}",

                Value = q.Id.ToString()
            });


            model.Catalogs = catalogTypeItems;
            return View(model);
        }

        // POST: LibraryRecordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LibraryRecordVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var libraryRecord = _mapper.Map<LibraryRecord>(model);
                var isSucess = _repo.Update(libraryRecord);
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

        // GET: LibraryRecordController/Delete/5
        public ActionResult Delete(int id)
        {
            var libraryRecord = _repo.FindById(id);
            if (libraryRecord == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(libraryRecord);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LibraryRecordController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LibraryRecordVM model)
        {
            try
            {
                var libraryRecord = _repo.FindById(id);
                if (libraryRecord == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(libraryRecord);
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
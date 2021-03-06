﻿using System;
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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ILibraryRecordRepository _libraryRecordRepo;
        private readonly ILibraryEmployeeRepository _libraryEmployeeRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IPublisherRepository _publisherRepo;
        private readonly IMapper _mapper;
        private readonly ICatalogRepository _repo;
        private readonly ICatalogTypeRepository _CatalogTyperepo;
        private readonly IGenreRepository _Genrerepo;
        private readonly ILibraryDisposalRepository _LibraryDisposalrepo;



        public CatalogController(ILibraryRecordRepository libraryRecordRepo,
            ILibraryEmployeeRepository libraryEmployeeRepo,
            IAuthorRepository authorRepo,
            IPublisherRepository publisherRepo, 
            ICatalogRepository repo,
            ILibraryDisposalRepository LibraryDisposalrepo,
            IGenreRepository Genrerepo,
            ICatalogTypeRepository CatalogTyperepo,
            IMapper mapper)
      
        {
             _repo = repo;
            _libraryRecordRepo = libraryRecordRepo;
            _libraryEmployeeRepo = libraryEmployeeRepo;
            _authorRepo = authorRepo;
            _publisherRepo = publisherRepo;
            _LibraryDisposalrepo = LibraryDisposalrepo;
            _Genrerepo = Genrerepo;
            _CatalogTyperepo = CatalogTyperepo;
            _mapper = mapper;

        } 



        // GET: CatalogController
        public ActionResult Index()
        {
            var catalog = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Catalog>, List<CatalogVM>>(catalog);
            return View(model);
        }

        // GET: CatalogController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var catalog = _repo.FindById(id);
            var model = _mapper.Map<CatalogVM>(catalog);
            return View(model);
        }

        // GET: CatalogController/Create
        public ActionResult Create()
        {
            var publisher = _publisherRepo.FindAll();
            var author = _authorRepo.FindAll();
            var genre = _Genrerepo.FindAll();
            var catalogtype = _CatalogTyperepo.FindAll();

            var authorTypeItems = author.Select(q => new SelectListItem
            {
                Text = $"{q.Firstname} {q.Lastname}",
                Value = q.Id.ToString()
            });

            var publisherTypeItems = publisher.Select(q => new SelectListItem
            {
                Text =$"{q.Firstname} {q.Lastname}",
             
                Value = q.Id.ToString()
            });

            var GenreTypeItems= genre.Select(q => new SelectListItem
            {
                Text = $"{q.Name}",

                Value = q.Id.ToString()
            });

            var catalogtypeTypeItems = catalogtype.Select(q => new SelectListItem
            {
                Text = $"{q.Name}",

                Value = q.Id.ToString()
            });


            var model = new CatalogVM
            {
                Publishers = publisherTypeItems,
                Authors = authorTypeItems,
                Genres= GenreTypeItems,
                CatalogTypes= catalogtypeTypeItems
            };
            return View(model);
        }

        // POST: CatalogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatalogVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var catalog = _mapper.Map<Catalog>(model);
                var isSucess = _repo.Create(catalog);

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

        // GET: CatalogController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }

            var catalog= _repo.FindById(id);
            var model = _mapper.Map<CatalogVM>(catalog);


            var publisher = _publisherRepo.FindAll();
            var author = _authorRepo.FindAll();
            var genre = _Genrerepo.FindAll();
            var catalogtype = _CatalogTyperepo.FindAll();

            var authorTypeItems = author.Select(q => new SelectListItem
            {
                Text = $"{q.Firstname} {q.Lastname}",
                Value = q.Id.ToString()
            });

            var publisherTypeItems = publisher.Select(q => new SelectListItem
            {
                Text = $"{q.Firstname} {q.Lastname}",

                Value = q.Id.ToString()
            });

            var GenreTypeItems = genre.Select(q => new SelectListItem
            {
                Text = $"{q.Name}",

                Value = q.Id.ToString()
            });

            var catalogtypeTypeItems = catalogtype.Select(q => new SelectListItem
            {
                Text = $"{q.Name}",

                Value = q.Id.ToString()
            });



            model.Publishers = publisherTypeItems;
            model.Authors = authorTypeItems;
            model.Genres = GenreTypeItems;
            model.CatalogTypes = catalogtypeTypeItems;
            

            return View(model);
        }

        // POST: CatalogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatalogVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var catalog = _mapper.Map<Catalog>(model);
                var isSucess = _repo.Update(catalog);
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

        // GET: CatalogController/Delete/5
        public ActionResult Delete(int id)
        {
            var catalog = _repo.FindById(id);
            if (catalog == null)
            {
                return NotFound();
            }
            var isSucess = _repo.Delete(catalog);
            if (!isSucess)
            {

                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CatalogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CatalogVM model)
        {
            try
            {
                var catalog = _repo.FindById(id);
                if (catalog == null)
                {
                    return NotFound();
                }
                var isSucess = _repo.Delete(catalog);
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
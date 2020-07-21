using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_Management_System.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class LibraryDisposalController : Controller
    {
        private readonly ILibraryDisposalRepository _repo;
        private readonly IMapper _mapper;

        public LibraryDisposalController(ILibraryDisposalRepository repo, IMapper mapper)
        {

            _repo = repo;
            _mapper = mapper;
        }

        // GET: LibraryDisposalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LibraryDisposalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibraryDisposalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryDisposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibraryDisposalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibraryDisposalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibraryDisposalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibraryDisposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

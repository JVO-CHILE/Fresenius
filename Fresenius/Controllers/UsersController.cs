using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fresenius.Models;
using Fresenius.DAL;

namespace Fresenius.Controllers
{
    public class UsersController : Controller
    {
        private readonly UnitOfWork unit = new UnitOfWork();

        // GET: /Users/
        public ActionResult Index()
        {
            return View(unit.UsersRepository.Queryable().ToList());
        }

        // GET: /Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await unit.UsersRepository.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="UserID,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                unit.UsersRepository.Create(user);
                await unit.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await unit.UsersRepository.FindAsync(id); 
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="UserID,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                unit.UsersRepository.Update(user);
                await unit.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await unit.UsersRepository.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await unit.UsersRepository.FindAsync(id);
            unit.UsersRepository.Delete(user);
            await unit.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentalManagement.Models;
using RentalManagement.ViewModel;

namespace RentalManagement.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.OccupancyRecords).Include(c => c.HomeAddress)
                          .Include(c => c.WorkAddress);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var clients = db.Clients.Include(c => c.OccupancyRecords).Include(c => c.HomeAddress).Include(c => c.WorkAddress).SingleOrDefault(c => c.Id == id);
            if(clients == null) {
                return HttpNotFound();
            }

            return View(clients);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var viewModel = new ClientViewModel {
                Assets = db.Assets.ToList(),
            };
            return View("Create", viewModel);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client, Asset asset)
        {
            client.OccupancyRecords = new List<OccupancyHistoryRecord>();

            if (ModelState.IsValid)
            {
                client.OccupancyRecords.Add(new OccupancyHistoryRecord { ClientId = client.Id, AssetId = asset.Id });
                db.People.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        [HttpPost]
        public ActionResult Save(Client client, Asset asset) {
            if(client.Id == 0) {
                db.Clients.Add(client);
            }else {
                var clientsInDB = db.Clients.Single(c => c.Id == client.Id);
                clientsInDB.Name = client.Name;
                clientsInDB.HomeAddress = client.HomeAddress;
                clientsInDB.WorkAddress = client.WorkAddress;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            var clients = db.Clients.Include(c => c.HomeAddress).Include(c => c.WorkAddress).SingleOrDefault(c => c.Id == id);
            if(clients == null) {
                return HttpNotFound();
            }

            var viewModel = new ClientViewModel {
                Client = clients,
                Assets = db.Assets.ToList()
            };
        
            return View("ClientForm", viewModel);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.People.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

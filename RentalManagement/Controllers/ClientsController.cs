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

namespace RentalManagement.Controllers {
    public class ClientsController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        [Authorize(Roles = "Employee,Supervisor,Client")]
        public ActionResult Index() {
            List<AssetClientViewModel> viewModel = new List<AssetClientViewModel>();
            var clients = (from o in db.OccupancyRecords
                           join c in db.Clients on o.ClientId equals c.Id
                           join a in db.Assets on o.AssetId equals a.Id
                           select new {
                               ClientId = c.Id,
                               AssetId = a.Id,
                               Name = c.Name,
                               AssetType = a.Type,
                               AssetAddress = a.Address,
                               StartDate = o.StartDate
                           }).ToList();

            var temps = clients.GroupBy(x => x.ClientId).Select(g => g.LastOrDefault()).ToList();

            foreach (var client in temps) {
                viewModel.Add(new AssetClientViewModel() {
                    ClientId = client.ClientId,
                    ClientName = client.Name,
                    AssetAddress = client.AssetAddress,
                    AssetType = client.AssetType
                });
            }
            return View(viewModel);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id) {
            //List<AssetClientViewModel> viewModel = new List<AssetClientViewModel>();
            var clients = (from o in db.OccupancyRecords
                           join c in db.Clients on o.ClientId equals c.Id
                           join a in db.Assets on o.AssetId equals a.Id
                           select new {
                               ClientId = id,
                               Name = c.Name,
                               AssetType = a.Type,
                               ClientHomeAddress = c.HomeAddress,
                               ClientWorkAddress = c.WorkAddress
                           }).Distinct().FirstOrDefault(c => c.ClientId == id);

            var viewModel = new AssetClientViewModel {
                ClientId = clients.ClientId,
                ClientName = clients.Name,
                AssetType = clients.AssetType,
                ClientHomeAddress = clients.ClientHomeAddress,
                ClientWorkAddress = clients.ClientWorkAddress
            };

            return View(viewModel);
        }

        // GET: Clients/Create
        public ActionResult Create() {
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
        public ActionResult Create(Client Client, Asset Asset) {
            Client.OccupancyRecords = new List<OccupancyHistoryRecord>();
            Client.RentRecords = new List<RentHistoryRecord>();

            if (ModelState.IsValid) {
                Client.OccupancyRecords.Add(new OccupancyHistoryRecord {
                    ClientId = Client.Id,
                    AssetId = Asset.Id });
                Client.RentRecords.Add(new RentHistoryRecord {
                    ClientId = Client.Id,
                    AssetId = Asset.Id, });
                db.People.Add(Client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id) {
            var clients = db.Clients.Include(c => c.HomeAddress)
                .Include(c => c.WorkAddress)
                .Include(c => c.OccupancyRecords)
                .Include(c => c.RentRecords).SingleOrDefault(c => c.Id == id);
            if (clients == null) {
                return HttpNotFound();
            }

            var viewModel = new ClientViewModel {
                Client = clients,
                Assets = db.Assets.ToList()
            };

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Client Client, Asset Asset) {
            if (Client.Id == 0) {
              db.Clients.Add(Client);
            }
            else {
                var clientsInDB = db.Clients.Single(c => c.Id == Client.Id);
                var assetsInDB = db.Assets.Single(a => a.Id == Asset.Id);

                clientsInDB.OccupancyRecords = new List<OccupancyHistoryRecord>();
                clientsInDB.RentRecords = new List<RentHistoryRecord>();

                clientsInDB.OccupancyRecords.Add(new OccupancyHistoryRecord {
                    ClientId = clientsInDB.Id,
                    AssetId = Asset.Id,
                    });
                clientsInDB.RentRecords.Add(new RentHistoryRecord {
                    ClientId = Client.Id,
                    AssetId = Asset.Id,});

                clientsInDB.Name = Client.Name;             
                clientsInDB.HomeAddress = Client.HomeAddress;
                clientsInDB.WorkAddress = Client.WorkAddress;
           }
            db.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }


        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
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
        }*/

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null) {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Client client = db.Clients.Find(id);
            db.People.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

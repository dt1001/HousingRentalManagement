using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using RentalManagement.Models;
using RentalManagement.ViewModel;

namespace RentalManagement.Controllers {
    public class ApprovementController : Controller {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index() {
            List<AssetClientViewModel> viewModel = new List<AssetClientViewModel>();
            var clients = (from o in db.OccupancyRecords
                           join c in db.Clients on o.ClientId equals c.Id
                           join a in db.Assets on o.AssetId equals a.Id
                           select new {
                               ClientId = c.Id,
                               Name = c.Name,
                               AssetType = a.Type,
                               AssetAddress = a.Address
                           }).Distinct().ToList();

            foreach (var client in clients) {
                viewModel.Add(new AssetClientViewModel() {
                    ClientId = client.ClientId,
                    ClientName = client.Name,
                    AssetAddress = client.AssetAddress,
                    AssetType = client.AssetType
                });
            }
            return View(viewModel);
        }


        public ActionResult Approve(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            foreach(var occ in db.OccupancyRecords) {
                if(occ.ClientId == id) {
                    occ.StartDate = DateTime.Today;
                    occ.EndDate = DateTime.Today.AddYears(1);
                    db.OccupancyRecords.Add(occ);
                }                               
            }

            foreach(var rent in db.RentRecords) {
                if(rent.ClientId == id) {
                    rent.AskingRent = 10;
                    rent.NegotiatedOn = DateTime.Today;
                    rent.NegotiatedRate = 10;
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Approvement");

        }

        public ActionResult Deny(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);

            if (client == null) {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult Details(int id) {
            var clients = db.Clients.Include(c => c.OccupancyRecords).Include(c => c.HomeAddress).Include(c => c.WorkAddress).SingleOrDefault(c => c.Id == id);
            if (clients == null) {
                return HttpNotFound();
            }

            return View(clients);
        }
    }
}

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
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //override default JSON result settings
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var viewModel = (from tick in db.Tickets
                             from emp in tick.employees
                             from cont in tick.contractors
                             select new TicketWrapper()
                             {
                                 id = tick.id,
                                 issueDate = tick.issueDate,
                                 asset = tick.asset,
                                 assetAddress = tick.asset.Address,
                                 priority = tick.priority,
                                 empId = emp.empId,
                                 name = emp.name,
                                 companyName = cont.companyName
                             });
            return View("Index", viewModel);
        }

        //gets all tickets from database in JSON format
        public JsonResult GetTickets()
        {
            var query = (from tick in db.Tickets
                         from emp in tick.employees
                         select new
                         {
                             tick.id,
                             tick.issueDate,
                             tick.priority,
                             emp.empId,
                             emp.name
                         }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = (from tick in db.Tickets
                         where tick.id == id
                         from emp in tick.employees
                         from cont in tick.contractors
                         select new TicketWrapper()
                         {
                             id = tick.id,
                             issueDate = tick.issueDate,
                             asset = tick.asset,
                             priority = tick.priority,
                             empId = emp.empId,
                             name = emp.name,
                             description = tick.description,
                             companyName = cont.companyName
                         }).ToList();
            var viewModel = query[0];
            return View("Details", viewModel);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            TicketViewModel viewModel = new TicketViewModel
            {
                Employees = db.Employees.ToList(),
                Contractors = db.Contractors.ToList(),
                Assets = db.Assets.ToList()
            };
            return View("Create", viewModel);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket, Employee employee, Contractor contractor, Asset asset)
        {
            if (ModelState.IsValid)
            {
                if (employee != null && employee.empId > 0)
                {
                    Employee emp = db.Employees.Find(employee.empId);
                    ticket.employees.Add(emp);
                    emp.tickets.Add(ticket);
                    db.Entry(emp).State = EntityState.Modified;
                }
                if (contractor != null && contractor.contId > 0)
                {
                    Contractor cont = db.Contractors.Find(contractor.contId);
                    ticket.contractors.Add(cont);
                    cont.tickets.Add(ticket);
                    db.Entry(cont).State = EntityState.Modified;
                }
                if (asset != null && asset.Id > 0)
                {
                    Asset assets = db.Assets.Find(asset.Id);
                    ticket.asset = assets;
                    assets.tickets.Add(ticket);
                    db.Entry(assets).State = EntityState.Modified;
                }
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketViewModel viewModel = new TicketViewModel
            {
                Employees = db.Employees.ToList(),
                Contractors = db.Contractors.ToList(),
                Assets = db.Assets.ToList(),
                ticket = db.Tickets.Find(id)
            };
            if (viewModel.ticket == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,issueDate,priority")] Ticket ticket, Employee employee, Contractor contractor, RentalUnit rentalUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.Entry(db.Employees.Find(employee.empId)).State = EntityState.Modified;
                db.Entry(db.Contractors.Find(contractor.contId)).State = EntityState.Modified;
                db.Entry(db.RentalUnits.Find(rentalUnit.unitId)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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

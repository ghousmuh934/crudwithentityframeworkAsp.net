using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using CrudDBWithEntityFramework.Models;

namespace CrudDBWithEntityFramework.Controllers
{
    public class ProductController : Controller
    {
        MvcCrudDbEntities db = new MvcCrudDbEntities();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> productList = db.Products.ToList();
            return View(productList);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                Response.Write("<script>alert('Record Save Successfully')</script>");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }  

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (prod.Count > 0)
            {
                return View(prod);
            }
            else
                return RedirectToAction("Index");

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var prod = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                db.Products.Remove(prod);
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteProdut = db.Products.Where(x =>x.ProductId == id).FirstOrDefault();
            if (deleteProdut.Count > 0)
            {
                db.Products.Remove(deleteProdut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}

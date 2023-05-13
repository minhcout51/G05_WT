using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WT.Models;

namespace WT.Controllers
{
    public class AdminController : Controller
    {
        public MongoDBContext dbcontext;
        public IMongoCollection<Product> productCollection;
        // GET: Admin
        public AdminController()
        {
            dbcontext = new MongoDBContext();
        productCollection = dbcontext.database.GetCollection<Product>("ThongTinSanPham"); //we are getting collection //product is collection name
        }
    public ActionResult Index()
        {
            List<Product> products = productCollection.AsQueryable<Product>().ToList();
            return View(products);
           
        }
     
        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            var productId = new ObjectId(id);

            var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                productCollection.InsertOne(product);      //we are inserting
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Product>.Update.Set("Ten", product.Name).Set("LoaiSanPham", product.Category).Set("ThuongHieu", product.Brand).Set("Gia", product.Price).Set("DoTuoi", product.Age).Set("HinhAnh", product.Image);
                var result = productCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productCollection.DeleteOne(Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

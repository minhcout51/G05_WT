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
    public class HomeController : Controller
    {
        public MongoDBContext productlistContext;
        public IMongoCollection<Product> productlistCollection; 
        public MongoDBContext billContext;
        public IMongoCollection<Bill> billCollection;
        public HomeController(){
            productlistContext = new MongoDBContext();
            productlistCollection = productlistContext.database.GetCollection<Product>("ThongTinSanPham");
            billContext = new MongoDBContext();
            billCollection = billContext.database.GetCollection<Bill>("ThongTinDonHang");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    
        public ActionResult Products()
        {
            List<Product> products = productlistCollection.AsQueryable<Product>().ToList();
            return View(products);
        }
        public ActionResult ProductDetail(string id)
        {
            var productId = new ObjectId(id);
            var product = productlistCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }
        public ActionResult Cart(string id)
        {
            var billId = new ObjectId(id);
            var bill = billCollection.AsQueryable<Bill>().SingleOrDefault(x => x.Id == billId);
            return View(bill);
        }
        [HttpPost]
        public ActionResult Cart(string id, Bill bill)
        {
            
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
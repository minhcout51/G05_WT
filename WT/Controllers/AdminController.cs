using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WT.Models;
using System.IO;
using System.Configuration;

namespace WT.Controllers
{
    public class AdminController : Controller
    {
        public MongoDBContext dbcontext;
        public IMongoCollection<Product> productCollection;
        public MongoDBContext billContext;
        public IMongoCollection<Bill> billCollection;
        public MongoDBContext employeeContext;
        public IMongoCollection<Employee> employeeCollection; 
        public MongoDBContext customerContext;
        public IMongoCollection<Customer> customerCollection;
        // GET: Admin
        public AdminController()
        {
            dbcontext = new MongoDBContext();
            productCollection = dbcontext.database.GetCollection<Product>("ThongTinSanPham"); //we are getting collection //product is collection name
            billContext = new MongoDBContext();
            billCollection = billContext.database.GetCollection<Bill>("ThongTinDonHang");
            employeeContext = new MongoDBContext();
            employeeCollection = employeeContext.database.GetCollection<Employee>("NhanVien");
            customerContext = new MongoDBContext();
            customerCollection = customerContext.database.GetCollection<Customer>("KhachHang");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            
            List<Product> products = productCollection.AsQueryable<Product>().ToList();
            return View(products);
           
        }
    
        // GET: Admin/Details/5
        public ActionResult ProductDetails(string id)
        {
            var productId = new ObjectId(id);

            var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        
        }

        // GET: Admin/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            
            try
            {
                // TODO: Add insert logic here
                productCollection.InsertOne(product);      //we are inserting
                return RedirectToAction("Product");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult EditProduct(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditProduct(string id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Product>.Update.Set("Ten", product.Name).Set("LoaiSanPham", product.Category).Set("ThuongHieu", product.Brand).Set("Gia", product.Price).Set("DoTuoi", product.Age).Set("HinhAnh", product.Image);
                var result = productCollection.UpdateOne(filter, update);
                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteProduct(string id)
        {
            var productId = new ObjectId(id);
            var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteProduct(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productCollection.DeleteOne(Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Bill()
        {
            List<Bill> bills = billCollection.AsQueryable<Bill>().ToList();
            return View(bills);

        }
        // GET: Admin/Details/5
        public ActionResult BillDetails(string id)
        {
            var billId = new ObjectId(id);

            var bill = billCollection.AsQueryable<Bill>().SingleOrDefault(x => x.Id == billId);
            return View(bill);

        }
        // GET: Admin/Create
        public ActionResult CreateBill()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBill(Bill bill)
        {
            try
            {
                // TODO: Add insert logic here
                billCollection.InsertOne(bill);      //we are inserting
                return RedirectToAction("Bill");

            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Edit/5
        public ActionResult EditBill(string id)
        {
            var billId = new ObjectId(id);
            var bill = billCollection.AsQueryable<Bill>().SingleOrDefault(x => x.Id == billId);
            return View(bill);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditBill(string id, Bill bill)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<Bill>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Bill>.Update.Set("TenSanPham", bill.Name).Set("LoaiSanPham", bill.Category).Set("SoLuong",bill.Quantity).Set("DonGia", bill.UnitPrice).Set("ThanhTien", bill.TotalCost).Set("NguoiMua", bill.Customer).Set("TinhTrang", bill.Status);
                var result = billCollection.UpdateOne(filter, update);
                return RedirectToAction("Bill");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Delete/5
        public ActionResult DeleteBill(string id)
        {
            var billId = new ObjectId(id);
            var bill = billCollection.AsQueryable<Bill>().SingleOrDefault(x => x.Id == billId);
            return View(bill);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteBill(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                billCollection.DeleteOne(Builders<Bill>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Bill");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Employee()
        {
        
            List<Employee> employees = employeeCollection.AsQueryable<Employee>().ToList();
            return View(employees);
        }
        // GET: Admin/Details/5
        public ActionResult EmployeeDetails(string id)
        {
            var empId = new ObjectId(id);

            var emp = employeeCollection.AsQueryable<Employee>().SingleOrDefault(x => x.Id == empId);
            return View(emp);

        }
        // GET: Admin/Create
        public ActionResult CreateEmployee()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                employeeCollection.InsertOne(employee);      //we are inserting
                return RedirectToAction("Employee");

            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Edit/5
        public ActionResult EditEmployee(string id)
        {
            var empId = new ObjectId(id);
            var employee = employeeCollection.AsQueryable<Employee>().SingleOrDefault(x => x.Id == empId);
            return View(employee);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditEmployee(string id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<Employee>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Employee>.Update.Set("HoTen", employee.FullName).Set("SDT", employee.PhoneNumber).Set("CongViec", employee.Job).Set("NgaySinh", employee.DateOfBirth);
                var result = employeeCollection.UpdateOne(filter, update);
                return RedirectToAction("Employee");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Delete/5
        public ActionResult DeleteEmployee(string id)
        {
            var empId = new ObjectId(id);
            var employee = employeeCollection.AsQueryable<Employee>().SingleOrDefault(x => x.Id == empId);
            return View(employee);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteEmployee(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                employeeCollection.DeleteOne(Builders<Employee>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Employee");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Customer()
        {
            List<Customer> customers = customerCollection.AsQueryable<Customer>().ToList();
            return View(customers);
        }
        // GET: Admin/Details/5
        public ActionResult CustomerDetails(string id)
        {
            var customerId = new ObjectId(id);

            var customer = customerCollection.AsQueryable<Customer>().SingleOrDefault(x => x.Id == customerId);
            return View(customer);

        }
        // GET: Admin/Create
        public ActionResult CreateCustomer()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                customerCollection.InsertOne(customer);      //we are inserting
                return RedirectToAction("Customer");

            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Edit/5
        public ActionResult EditCustomer(string id)
        {
            var customerId = new ObjectId(id);

            var customer = customerCollection.AsQueryable<Customer>().SingleOrDefault(x => x.Id == customerId);
            return View(customer);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditCustomer(string id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Customer>.Update.Set("HoTen", customer.FullName).Set("SDT", customer.PhoneNumber).Set("DiaChi", customer.Address).Set("Username", customer.Username).Set("MatKhau",customer.Password);
                var result = customerCollection.UpdateOne(filter, update);
                return RedirectToAction("Customer");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Delete/5
        public ActionResult DeleteCustomer(string id)
        {
            var customerId = new ObjectId(id);

            var customer = customerCollection.AsQueryable<Customer>().SingleOrDefault(x => x.Id == customerId);
            return View(customer);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteCustomer(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                customerCollection.DeleteOne(Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Customer");
            }
            catch
            {
                return View();
            }
        }
    }
}

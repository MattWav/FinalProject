using DECommerce.Interfaces;
using DECommerce.Models;
using DECommers.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Repository
{
    public class DECommerceRepository : IDECommerceRepository
    {

        private IConfiguration _configuration;
        private DECommerceDb _model;

        public DECommerceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _model = new DECommerceDb(_configuration.GetSection("ConnectionStrings:DynamicECommerce").Value);

        }
         // get user
        List<Users> IDECommerceRepository.GetUsers()
        {
            List<Users> users = new List<Users>();

            users = _model.Users.ToList();
            return users;
        }
        // post user
        bool IDECommerceRepository.CreateUsers(Users users)
        {
            bool results = false;

            _model.Users.Add(users);
            results = _model.SaveChanges() > 0;
            return results;
        }
        //get user by id
        Users IDECommerceRepository.GetUserById(int UserID)
        {
            Users user = _model.Users.FirstOrDefault(x => x.UserID == UserID);
            return user;
        }

 
        //delete user
        bool IDECommerceRepository.DeleteUsers(int UserID)
        {
            bool result = false;

            Users user = _model.Users.FirstOrDefault(x => x.UserID == UserID);
            _model.Remove(user);
            result = _model.SaveChanges() > 0;
            return result;
        }
        //GET  user roles
        public List<UserRole> GetUserRoles()
        {
            List<UserRole> UserRole = new List<UserRole>();

            UserRole = _model.UserRole.ToList();
            return UserRole;
        }
       // post User roles
        public bool CreateUserRole(UserRole userRole)
        {
            bool results = false;

            _model.UserRole.Add(userRole);
            results = _model.SaveChanges() > 0;
            return results;
        }
        //GET roles
        public List<Roles> GetRoles()
        {
            List<Roles> Roles = new List<Roles>();

            Roles = _model.Roles.ToList();
            return Roles;
        }
        //get role by id
        public Roles GetRoleById(int roleId)
        {
            Roles role = _model.Roles.FirstOrDefault(u => u.RoleID == roleId);
            return role;
        }
        // post user role
      public bool AddUserRole(UserRole userRole)
        {
            bool result = false;

            _model.UserRole.Add(userRole);
            result = _model.SaveChanges() > 0;
            return result;
        }
        // get Products
        public List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();
            //.Skip(10*2).Take(10) per la paginazione
            products = _model.Products.ToList();
            return products;
        }
        // get products by id
        public Products GetProductsbyId(int ProductID)
        {
            Products products = _model.Products.FirstOrDefault(x => x.ProductID == ProductID);
            return products;
        }
        // delete products
        public bool DeleteProducts(int ProductID)
        {
            bool result = false;

            Products products = _model.Products.FirstOrDefault(x => x.ProductID == ProductID);
            _model.Remove(products);
            result = _model.SaveChanges() > 0;
            return result;
        }
        //Get Products by id
        public List<Products> GetProductsbyCategoriesId(int ProductCategoriesID)
        {
            List<Products> products = new List<Products>();

            products = _model.Products.ToList();
            return products;
        }
        // Post Products
        public bool CreateProduct(Products products)
        {
            bool results = false;

            _model.Products.Add(products);
            results = _model.SaveChanges() > 0;
            return results;
        }
        // get Product categories
        public List<ProductCategories> GetProductCategories()
        {

            List<ProductCategories> productCategories = new List<ProductCategories>();

            productCategories = _model.ProductCategories.ToList();
            return productCategories;
        }

        // Post product categories
        public bool CreateProductCategories(ProductCategories productCategories)
        {
            bool results = false;

            _model.ProductCategories.Add(productCategories);
            results = _model.SaveChanges() > 0;
            return results;
        }
        //Delete product categories
        public bool DeleteProductCategories(int ProductCategoriesID)
        {
            bool result = false;

            ProductCategories productCategories = _model.ProductCategories.FirstOrDefault(x => x.ProductCategoriesID == ProductCategoriesID);
            _model.Remove(productCategories);
            result = _model.SaveChanges() > 0;
            return result;
        }
        // get productCategoriesid
        public ProductCategories GetProductsCategoriesbyId(int ProductsCategoriesID)
        {
            ProductCategories productCategories = _model.ProductCategories.FirstOrDefault(x => x.ProductCategoriesID == ProductsCategoriesID);
            return productCategories;
        }

        //GET order
        public List<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>();

            orders = _model.Orders.ToList();
            return orders;
        }

        //GET order by user id
        public List<Orders> GetOrdersbyUserId()
        {
            List<Orders> orders = new List<Orders>();

            orders = _model.Orders.ToList();
            return orders;
        }
        //GET order by id
        public Orders GetOrdersbyId(int OrderID)
        {
            Orders orders = _model.Orders.FirstOrDefault(x => x.OrderID == OrderID);
            return orders;
        }
        //DELETE order
        public bool DeleteOrders(int OrderID)
        {
            bool result = false;

            Orders orders = _model.Orders.FirstOrDefault(x => x.OrderID == OrderID);
            _model.Remove(orders);
            result = _model.SaveChanges() > 0;
            return result;
        }
        //POST order
        public bool CreateOrders(Orders orders)
        {
            bool results = false;

            _model.Orders.Add(orders);
            results = _model.SaveChanges() > 0;
            return results;
        }
        //GET ORDER DETAILS
        public List<OrderDetails> GetOrderDetails()
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            orderDetails = _model.OrderDetails.ToList();
            return orderDetails;
        }
        //GET ORDER DETAILS BY ID
        public OrderDetails GetOrderDetailsByID(int OrderDetailsID)
        {
            OrderDetails orderDetails = _model.OrderDetails.FirstOrDefault(x => x.OrderDetailsID == OrderDetailsID);
            return orderDetails;
        }
        //GET ORDER DETAILS BY ORDER ID
        public List<OrderDetails> GetOrderDetailsByOrderID(int OrderID)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            orderDetails = _model.OrderDetails.Where(x => x.OrderID == OrderID).ToList();
            return orderDetails;
        }
        public Users GetUserByUsername(string username)
        {
            Users user = _model.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }
     

        UserRole IDECommerceRepository.GetUserRoleByUserId(int UserID)
        {
            UserRole userRole = _model.UserRole.FirstOrDefault(x => x.UserID == UserID);
            return userRole;
        }
    }
}

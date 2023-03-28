using DECommerce.Models;
using DECommers.Models;

namespace DECommerce.Interfaces
{
    public interface IDECommerceRepository
    {   // USER INTERFACES
        List<Users> GetUsers();
        Users GetUserById(int UserID);
        bool CreateUsers(Users users);
        bool DeleteUsers(int ID);
        Users GetUserByUsername(string Username);


        // USER ROLE
        List<UserRole> GetUserRoles();
        bool CreateUserRole(UserRole userRoles);
        UserRole GetUserRoleByUserId(int UserID);
        // ROLE
        List<Roles> GetRoles();
        Roles GetRoleById(int roleId);
        bool AddUserRole(UserRole userRole);
        // PRODUCTS
        List<Products> GetProducts();
        Products GetProductsbyId(int ProductID);
        List<Products> GetProductsbyCategoriesId(int ProductCategoriesID);  
        bool DeleteProducts(int ProductID);
        bool CreateProduct(Products products);

        // PRODUCTS Categories
        List<ProductCategories> GetProductCategories();
        ProductCategories GetProductsCategoriesbyId(int ProductCategoriesID);
        bool CreateProductCategories(ProductCategories productCategories);
        bool DeleteProductCategories(int ProductCategoriesID);

        //ORDERS
        List<Orders> GetOrders();
        List<Orders> GetOrdersbyUserId();
        Orders GetOrdersbyId(int OrderID);
        bool DeleteOrders(int OrderID);
        bool CreateOrders(Orders orders);

        //ORDER DETAILS
        List<OrderDetails> GetOrderDetails();
        List<OrderDetails> GetOrderDetailsByOrderID(int OrderID);
        OrderDetails GetOrderDetailsByID(int OrderDetailsID);
    }
}
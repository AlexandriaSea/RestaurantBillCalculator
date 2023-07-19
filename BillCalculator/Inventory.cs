using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillCalculator
{
    public class Inventory
    {
        // Initialize the sample data
        public static IEnumerable<Product> GetAll()
        {
            yield return new Product(1, "Soda", "Beverage", 1.95);
            yield return new Product(2, "Tea", "Beverage", 1.50);
            yield return new Product(3, "Coffe", "Beverage", 1.25);
            yield return new Product(4, "Mineral Water", "Beverage", 2.95);
            yield return new Product(5, "Juice", "Beverage", 2.50);
            yield return new Product(6, "Milk", "Beverage", 1.50);

            yield return new Product(7, "Buffalo Wings", "Appetizer", 5.95);
            yield return new Product(8, "Buffalo Fingers", "Appetizer", 6.95);
            yield return new Product(9, "Potato Skins", "Appetizer", 8.95);
            yield return new Product(10, "Nachos", "Appetizer", 8.95);
            yield return new Product(11, "Mushroom Caps", "Appetizer", 10.95);
            yield return new Product(12, "Shrimp Cocktail", "Appetizer", 12.95);
            yield return new Product(13, "Chips and Salsa", "Appetizer", 6.95);

            yield return new Product(14, "Seafood Alfredo", "Main Course", 15.95);
            yield return new Product(15, "Chicken Alfredo", "Main Course", 13.95);
            yield return new Product(16, "Chicken Picatta", "Main Course", 13.95);
            yield return new Product(17, "Turkey Club", "Main Course", 11.95);
            yield return new Product(18, "Lobster Pie", "Main Course", 19.95);
            yield return new Product(19, "Prime Rib", "Main Course", 20.95);
            yield return new Product(20, "Shrimp Scampi", "Main Course", 18.95);
            yield return new Product(21, "Turkey Dinner", "Main Course", 13.95);
            yield return new Product(22, "Stuffed Chicken", "Main Course", 14.95);

            yield return new Product(23, "Apple Pie", "Dessert", 5.95);
            yield return new Product(24, "Sundae", "Dessert", 3.95);
            yield return new Product(25, "Carrot Cake", "Dessert", 5.95);
            yield return new Product(26, "Mud Pie", "Dessert", 4.95);
            yield return new Product(27, "Apple Crisp", "Dessert", 5.95);
        }

        public static Product? GetProduct(int id)
        {
            return GetAll().FirstOrDefault<Product>(p => p.Id == id);
        }

        public static IEnumerable<Product> GetItemsByCategory(string cat)
        {
            return GetAll().Where<Product>(p => p.Category == cat);
        }
    }
}

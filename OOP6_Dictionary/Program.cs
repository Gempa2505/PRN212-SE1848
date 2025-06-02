using System.Text;
using OOP6_Dictionary;

Console.OutputEncoding = Encoding.UTF8;

Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nuoc ngot";

Product p1 = new Product();
p1.Id = 1;
p1.Name = "Pepsi";
p1.Quantity = 10;
p1.Price = 30;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "Coca";
p2.Quantity = 20;
p2.Price = 45;
c1.AddProduct(p2);

Product p3 = new Product();
p3.Id = 3;
p3.Name = "Sting";
p3.Quantity = 30;
p3.Price = 35;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "Revi";
p4.Quantity = 15;
p4.Price = 40;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "Xa Xi";
p5.Quantity = 45;
p5.Price = 35;
c1.AddProduct(p5);

Console.WriteLine("===Thong tin danh muc===");
Console.WriteLine("===Thong tin san pham===");
c1.PrintAllProducts();

double min_price = 10;
double max_price = 35;
Dictionary<int, Product> products_by_price = c1.FilterProductsByPrice(min_price, max_price);
Console.WriteLine($"Danh sach san pham cos gia tu {min_price} toi {max_price}: ");
foreach (KeyValuePair<int, Product> kvp in products_by_price)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_products = c1.SortProductByPrice();
Console.WriteLine("===Danh sach san pham sau khi sap xep gia tang dan===");
foreach (KeyValuePair<int, Product> kvp in sorted_products)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sorted_complex = c1.SortComplex();
Console.WriteLine("===Danh sach san pham sau khi sap xep complex==");
foreach (KeyValuePair<int, Product> kvp in sorted_complex)
{
    Product p = kvp.Value;
    Console.WriteLine(p);
}

p5.Name = "Fanta";
p5.Price = 80;
p5.Quantity = 17;
bool ret = c1.updateProduct(p5);
Console.WriteLine("===san pham sau khi chinh sua===");
c1.PrintAllProducts();

int id = 5;
ret = c1.RemoveProduct(id);
if (ret == false)
    Console.WriteLine($"Khong tim thay ma {id} de xoa");
else
{
    Console.WriteLine($"Da xoa thanh cong san pham co ma {id}");
    Console.WriteLine("===San pham sau khi xoa===");
    c1.PrintAllProducts();
}

LinkedList<Category> categories = new LinkedList<Category>();
categories.AddLast(c1);

Category c2 = new Category();
c2.Id = 2;
c2.Name = "Bia cac loai";

c2.AddProduct(new Product() {Id = 6, Name="Tiger", Quantity = 10, Price = 35});
c2.AddProduct(new Product() { Id = 7, Name = "333", Quantity = 15, Price = 40 });
c2.AddProduct(new Product() { Id = 8, Name = "Ken", Quantity = 20, Price = 45 });

categories.AddFirst(c2);
Console.WriteLine("===Danh sach san pham theo danh muc===");
foreach (Category c in categories)
{
    Console.WriteLine(c);
    Console.WriteLine("----------------------");
    c.PrintAllProducts();
    Console.WriteLine("----------------------");
}
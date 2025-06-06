using System.Text;
using DemoLINQ2SQL;

Console.OutputEncoding = Encoding.UTF8;

//Khai báo chuỗi kết nối tới CSDL:
string connectionString = @"server = GEMPA\SQLEXPRESS; database = MyStore; uid = sa; pwd = 12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);

//Câu 1: Truy vấn toàn bộ danh mục
var dsdm = context.Categories.ToList();
Console.WriteLine("---Danh sach danh muc---");
foreach (var d in dsdm)
    Console.WriteLine(d.CategoryID + "\t" + d.CategoryName);

//Câu 2: Lấy thông tin chi tiết danh mục khi biết mã
int madm = 7;
Category cate = context.Categories.FirstOrDefault(c => c.CategoryID == madm);
if (cate == null)
{
    Console.WriteLine("Khong tim thay danh muc co ma = " + madm);
}
else
{
    Console.WriteLine("Tim thay danh muc co ma = " + madm);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}

//Câu 3: Dùng Query Syntax để truy vấn toàn bộ sản phẩm
var dssp = from p in context.Products
           select p;
Console.WriteLine("Danh sach san pham");
foreach (var p in dssp)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

//Câu 4: Dùng Query Syntax và Anonymous type để lọc ra các sản phẩm nhưng chỉ lấy mã sản phẩm và đơn giá
// đồng thời sắp xếp giảm dần
var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new { p.ProductID, p.UnitPrice };
Console.WriteLine("---Danh sach san pham theo cau 4---");
foreach (var p in dssp4)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}

//Câu 5: Sửa câu 4 theo extension method (Method Syntax)
var dssp5 = context.Products.OrderByDescending(p => p.UnitPrice).Select(p => new { p.ProductID, p.UnitPrice });
Console.WriteLine("---Danh sach san pham theo cau 5---");
foreach (var p in dssp5)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}

//Câu 6: Lọc ra TOP 3 sản phẩm có giá trị lớn nhất hệ thống (Method Syntax)
var dssp6 = context.Products.OrderByDescending(p => p.UnitPrice)
                            .Take(3);
Console.WriteLine("---TOP 3 san pham co gia lon nhat---");
foreach (var p in dssp6)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

//Câu 7: Sửa tên danh mục khi biết mã
int madm_edit = 5;
Category cate_edit = context.Categories
                    .FirstOrDefault(c => c.CategoryID == madm_edit);
if (cate_edit != null)
{
    cate_edit.CategoryName = "Hàng chợ";
    context.SubmitChanges(); //Xác nhận lưu thay đổi
}

//Câu 8: Xóa danh mục khi biết mã
int madm_xoa = 4;
Category cate_remove = context.Categories
                   .FirstOrDefault(c => c.CategoryID == madm_xoa);
if (cate_remove != null)
{
    context.Categories.DeleteOnSubmit(cate_remove);
    context.SubmitChanges();
}

//Câu 9: Xóa các danh mục nếu không có bất kì sản phẩm nào
//Lưu ý: là xóa cùng lúc nhiều danh mục, mà các danh mục này không có chứa bất kì 1 sản phẩm nào
var dsdm_trong = context.Categories
                .Where(c => c.Products.Count == 0).ToList();
context.Categories.DeleteAllOnSubmit(dsdm_trong);
context.SubmitChanges();

//Câu 10: Thêm mới danh mục
Category c_new = new Category();
c_new.CategoryName = "Hàng lậu từ Trung Quốc";
context.Categories.InsertOnSubmit(c_new);
context.SubmitChanges();

//Câu 11: Thêm mới nhiều danh mục
List<Category> list = new List<Category>();
list.Add(new Category() { CategoryName = "Hàng điện tử" });
list.Add(new Category() { CategoryName = "Hàng gia dụng" });
list.Add(new Category() { CategoryName = "Hàng Phụ kiện" });
context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges();
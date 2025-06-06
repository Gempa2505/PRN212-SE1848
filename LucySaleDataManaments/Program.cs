using System.Text;
using LucySaleDataManagements;

Console.OutputEncoding = Encoding.UTF8;
//Khai báo chuỗi kết nối tới CSDL
string connectionString = @"server = GEMPA\SQLEXPRESS; database = MyStore; uid = sa; pwd = 12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);

//Câu 1: Lọc thông tin toàn bộ khách hàng
var dskh = context.Customers.ToList();
Console.WriteLine("---danh sach khach hang---");
foreach (var d in dskh)
{
    Console.WriteLine(d.CustomerID + "\t" + d.ContactName);
}

//Câu 2: Lấy ra khách hàng theo mã
int mkh = 10;
Customer cust = context.Customers.FirstOrDefault(c => c.CustomerID == mkh);
if (cust != null)
{
    Console.WriteLine("---Chi tiet thong tin khach hang ma = " + mkh);
    Console.WriteLine(cust.CustomerID + "\t" + cust.ContactName);
}

//Câu 3: Từ kết quả của câu 2, Lọc ra danh sách các hóa đơn của khách hàng
//  các cột dữ liệu bao gồm: Mã hóa đơn + Ngày hóa đơn
if (cust != null)
{
    var dshd = cust.Orders.Select(od => new { od.OrderID, od.OrderDate });
    var dshd2 = from od in cust.Orders
                select new { od.OrderID, od.OrderDate };
    Console.WriteLine("Danh sach hoa don cua khach hang");

    foreach (var od in dshd)
    {
        Console.WriteLine(od.OrderID + "\t" + od.OrderDate.ToString("dd/MM/yyyy"));
    }
}

//Câu 4: Từ kết quả của câu 3, bổ sung cột Trị giá của đơn hàng cho mỗi hóa đơn
if (cust != null)
{
    var dshd = cust.Orders
                   .Select(od => new
                   {
                       od.OrderID,
                       od.OrderDate,
                       TotalValue = od.Order_Details
                                                   .Sum(odd => odd.Quantity * odd.UnitPrice * (1 - (decimal)odd.Discount))
                   });
    Console.WriteLine("Danh sach hoa don cua khach hang");

    foreach (var od in dshd)
    {
        Console.WriteLine(od.OrderID + "\t" + od.OrderDate.ToString("dd/MM/yyyy"));
    }
}
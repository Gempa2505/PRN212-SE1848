using System.Text;
using System.Xml.Linq;
using DemoAliasClone;

Console.OutputEncoding = Encoding.UTF8;

Customer c1 = new Customer();
c1.Id = 1;
c1.Name = "Tran Van Teo";

Customer c2 = new Customer();
c1.Id = 2;
c1.Name = "Nguyen Van Tet";

c1 = c2; // c1 trỏ tới cùng nhớ mà c2 đang quản lý chứ ko phải c1 = c2. Lúc này xảy ra 2 tình huống
         // 1. Ô nhớ Alpha mà c1 quản lý lúc nãy bị trống, ko còn đối tượng nào tham gia quản lý nữa
         // => Hệ điều dành sẽ thu hồi ô nhớ này, gọi là cơ chế gom rác tự động (Auto Garbage Collection). Ta ko thể lấy giá trị từ ô nhớ này nữa
         // 2. Lúc này ô nhớ Bêt sẽ có 2 đối tượng tham gian quản lý
         // - Đối tượng ban đầu là c2
         // - bây giờ có thêm đối tượng c1 quản lý
         // Trường hợp 1 ô nhớ từ 2 đối tượng trở lên tham gia quản lý nó đc gọi là Alias 
         // -> Bất kì 1 đối tượng nào đổi giá trị tại ô nhớ Beta thì các đối tượng khác cũng sẽ bị thay đổi giá trị
c1.Name = "Hồ Đồ";
         // Lúc này c2.Name cũng sẽ bị thay đổi theo vì c1 và c2 đều đang quản lý ô nhớ Beta
Console.WriteLine("Tên của c2: " + c2.Name);

Customer c3 = new Customer();
Customer c4 = c3;
c3 = c1; //Không có thu hồi ô nhớ của c3 đang quản lý vì c4 vẫn đang quản lý ô nhớ này

//===========================================================================================

Product p1 = new Product { Id = 1, Name = "P1", Quantity = 10, Price = 20 };
Product p2 = new Product { Id = 2, Name = "P2", Quantity = 15, Price = 22 };

p1 = p2; // p1 trỏ tới ô nhớ mà p2 đang quản lý, lúc này p1 và p2 đều quản lý ô nhớ Beta
Console.WriteLine("===Thong tin cua p1===");
Console.WriteLine(p1);
Console.WriteLine("===Thong tin cua p2===");
Console.WriteLine(p2);

p2.Name = "Thuoc dau bung";
p2.Quantity = 50;
p2.Price = 100;
Console.WriteLine("===Thong tin cua p1 khi p2 doi===");
Console.WriteLine(p1);

Product p3 = new Product { Id = 3, Name = "P3", Quantity = 10, Price = 20 };
Product p4 = new Product { Id = 4, Name = "P4", Quantity = 10, Price = 20 };
Product p5 = new Product { Id = 5, Name = "P5", Quantity = 10, Price = 20 };
p3 = p4;
//Nếu bổ sung:
p5 = p3;
//thì có thu hồi ô nhớ đã cấp phát cho p3 hay ko? Vì sao?

Product p6 = p4.Clone();
//HĐH sao chép toàn bộ dữ liệu trong ô nhớ mà p4 đang quản lý qua 1 ô nhớ mới và giao cho p6 quản lý ô nhớ mới này
//p4 và p6 quản lý 2 ô nhớ khác nhau hoàn toàn nhưng giá trị giống nhau
//p6 thay đổi thì ko liên quan của p4 và ngược lại
Console.WriteLine("===Thong tin cua p4===");
Console.WriteLine(p4);
Console.WriteLine("===Thong tin cua p6===");
Console.WriteLine(p6);



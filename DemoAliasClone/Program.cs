using System.Text;
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
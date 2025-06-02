/*
 * Sử dụng Generic List để quản lý nhân sự với đầy đủ tính năng CRUD
 * C -> Create --> Tạo mới dữ liệu
 * R -> Read/Retrieve --> Xem, lọc, tìm kiếm, sắp xếp, thống kê,...
 * U -> Update --> Sửa dữ liệu
 * D -> Delete --> Xóa dữ liệu
*/

//Câu 1: Tạo 5 nhân viên, 3 nhân viên chính thức, 2 nhân viên thời vụ. Lưu vào Generic List:
using System.Text;
using OOP2;

List<Employee> employees = new List<Employee>();
FulltimeEmployee fe1 = new FulltimeEmployee()
{
    Id = 1,
    Name = "Nguyen Van A",
    IdCard = "123",
    Birthday = new DateTime(1981, 1, 1)
};
employees.Add(fe1);

FulltimeEmployee fe2 = new FulltimeEmployee()
{
    Id = 2,
    Name = "Nguyen Van B",
    IdCard = "456",
    Birthday = new DateTime(1982, 2, 2)
};
employees.Add(fe2);

FulltimeEmployee fe3 = new FulltimeEmployee()
{
    Id = 3,
    Name = "Nguyen Van C",
    IdCard = "789",
    Birthday = new DateTime(1983, 3, 3)
};
employees.Add(fe3);

ParttimeEmployee pe1 = new ParttimeEmployee()
{
    Id = 4,
    Name = "Nguyen Van D",
    IdCard = "654",
    Birthday = new DateTime(1984, 4, 4),
    WorkingHour = 1
};
employees.Add(pe1);

ParttimeEmployee pe2 = new ParttimeEmployee()
{
    Id = 5,
    Name = "Nguyen Van E",
    IdCard = "987",
    Birthday = new DateTime(1985, 5, 5),
    WorkingHour = 2
};
employees.Add(pe2);

//Câu 2: R -> Xuất toàn bộ nhân sự:
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Câu 2: R -> Xuất toàn bộ nhân sự: ");
//Cách 1:
employees.ForEach(e => Console.WriteLine(e));

//Câu 3: R -> Lọc ra các nhân sự chính thức:
//Cách 1:
List<FulltimeEmployee> fe_List = employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("Câu 3: R -> Lọc ra các nhân sự chính thức: ");
foreach (FulltimeEmployee fe in fe_List)
    Console.WriteLine(fe);


//Câu 4: Tổng lương nhân viên chính thức:
double fe_sum_salary = fe_List.Sum(e => e.calSalary());
Console.Write("Câu 4: Tổng lương nhân viên chính thức: ");
Console.WriteLine(fe_sum_salary);

//Câu 5: Tổng lương nhân viên thời vụ:
double pe_sum_salary = employees.OfType<ParttimeEmployee>().Sum(e => e.calSalary());
Console.Write("Câu 5: Tổng lương nhân viên thời vụ: ");
Console.WriteLine(pe_sum_salary);

//Bài tập:
//Sửa thông tin nhân viên:
Console.WriteLine("======================Bài tập=======================");
Employee empToUpdate = employees.FirstOrDefault(e => e.Id == 2);
if (empToUpdate != null)
{
    empToUpdate.Name = "Nguyen Van B";
    empToUpdate.IdCard = "456";
    empToUpdate.Birthday = new DateTime(1990, 12, 12);

    Console.WriteLine($"Đã sửa nhân viên có ID = {empToUpdate.Id}");
    Console.WriteLine($"Thông tin mới: ID = {empToUpdate.Id}, Tên = {empToUpdate.Name}, IdCard = {empToUpdate.IdCard}, Ngày sinh = {empToUpdate.Birthday:dd/MM/yyyy}");
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên này.");
}

//Xóa nhân viên:
Console.Write("Nhập ID nhân viên cần xóa: ");
int idToDelete = int.Parse(Console.ReadLine());

Employee empToDelete = employees.FirstOrDefault(e => e.Id == idToDelete);
if (empToDelete != null)
{
    employees.Remove(empToDelete);
    Console.WriteLine("Đã xóa nhân viên. Danh sách sau khi xóa:");
}
else
{
    Console.WriteLine("Không tìm thấy nhân viên có ID vừa nhập.");
}
employees.ForEach(e => Console.WriteLine(e));

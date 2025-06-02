using System.Text;
using OOP2;
using OOP4_Reuse_OOP2;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee fe =  new FulltimeEmployee();
fe.Id = 1;
fe.IdCard = "123";
fe.Name = "Putin";
fe.Birthday = new DateTime(1952, 12, 25);
Console.WriteLine(fe);
Console.WriteLine("AGE= " + fe.Tuoi());

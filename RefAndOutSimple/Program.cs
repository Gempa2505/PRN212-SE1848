using System.Text;

Console.OutputEncoding=Encoding.UTF8;
void ham1(int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
int n  = 5;
Console.WriteLine($"n trước khi vào hàm: {n}");
ham1(n);
Console.WriteLine($"n sau khi vào hàm: {n}");

//ref có thể tham chiếu đến giá trị nhưng yêu cầu biến đc tham chiếu phải có giá trị.
void ham2(ref int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm: {n}");
}
Console.WriteLine("===========================");
n = 5;
Console.WriteLine($"n trước khi vào hàm: {n}");
ham2(ref n);
Console.WriteLine($"n sau khi vào hàm: {n}");

//out ko cần giá trị ban đầu
void ham3(out int n)
{
    n = 9;
}
n = 113;
ham3(out n);
Console.WriteLine($"m là: {n}");

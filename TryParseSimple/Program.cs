﻿/*
 Đề bài:
    - Nhập vào 1 số >= 0, nếu nhập sai bắt nhập lại
    - Nếu nhập đúng ===> Tính giai thừa của nó
 */
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int n  = -1;
while (n < 0)
{
    Console.Write("Nhập n >= 0: ");
    string s = Console.ReadLine();
    if(int.TryParse(s, out n) == false)
    {
        Console.WriteLine("Bạn phải nhập số.");
    }
    else
    {
        if(n < 0)
        {
            Console.WriteLine("Bạn phải nhập n >= 0: ");
        }
    }
}
int giai_thua  = 1;
for (int i = 1; i <= n; i++)
    giai_thua *= i;
Console.WriteLine($"{n} != {giai_thua}");
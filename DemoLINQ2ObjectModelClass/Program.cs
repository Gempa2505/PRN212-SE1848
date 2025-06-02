using DemoLINQ2ObjectModelClass;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

ListProduct lp = new ListProduct();
lp.gen_products();

/*
 * Câu 1: Lọc ra các sản phẩm có giá từ a đến b
 */
var result = lp.FilterProductByPrice(100, 200);
Console.WriteLine("Cac san pham co gia tri tu 100 -> 200:");
result.ForEach(x => Console.WriteLine(x));

/*
 * Câu 2: Sắp xếp các sản phẩm theo giá tăng dần
 */
var result2 = lp.SortProductsByPriceAsc2();
Console.WriteLine("Cac san pham sau khi sap xep tang dan:");
result2.ForEach(x => Console.WriteLine(x));

/*
 * Câu 3: Sắp xếp các sản phẩm theo giá giảm dần
 */
var result3 = lp.SortProductsByPriceDesc();
Console.WriteLine("Cac san pham sau khi sap xep giam dan:");
result3.ForEach(x => Console.WriteLine(x));

/*
 * Câu 4: Tính tổng giá trị kho hàng
 */
Console.WriteLine("Tong gia tri kho hang = " + lp.SumOfValue());

/*
 * Câu 5: Tìm chi tiết sản phẩm khi biết mã sản phẩm
 */
Product p = lp.SearchProDuctDetail(3);
if(p != null)
{
    Console.WriteLine("Tim thay san pham, thong tin chi tiet:");
    Console.WriteLine(p);
}
else
{
    Console.WriteLine("Khong tim thay san pham.");
}

/*
 * Câu 6: Viết hàm lọc ra top n sản phẩm có trị giá lớn nhất
 */
var result4 = lp.GetTopProducts(3);
Console.WriteLine("Danh sach san pham co tong tri gia lon nhat:");
result4.ForEach(x => Console.WriteLine(x + " => " + p.Quantity * p.Price));
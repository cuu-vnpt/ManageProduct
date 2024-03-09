using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "products.dat";

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tìm kiếm sản phẩm");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(filePath);
                    break;
                case "2":
                    DisplayProducts(filePath);
                    break;
                case "3":
                    SearchProduct(filePath);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }
    }

    static void AddProduct(string filePath)
    {
        Console.WriteLine("Nhập thông tin sản phẩm:");
        Console.Write("Mã sản phẩm: ");
        string id = Console.ReadLine();
        Console.Write("Tên sản phẩm: ");
        string name = Console.ReadLine();
        Console.Write("Hãng sản xuất: ");
        string manufacturer = Console.ReadLine();
        Console.Write("Giá: ");
        string price = Console.ReadLine();
        Console.Write("Mô tả khác: ");
        string description = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{id},{name},{manufacturer},{price},{description}");
        }

        Console.WriteLine("Sản phẩm đã được thêm vào file.");
    }

    static void DisplayProducts(string filePath)
    {
        Console.WriteLine("Danh sách sản phẩm:");

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                Console.WriteLine($"Mã: {fields[0]}, Tên: {fields[1]}, Hãng: {fields[2]}, Giá: {fields[3]}, Mô tả: {fields[4]}");
            }
        }
    }

    static void SearchProduct(string filePath)
    {
        Console.Write("Nhập mã sản phẩm cần tìm: ");
        string searchId = Console.ReadLine();

        bool found = false;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                if (fields[0] == searchId)
                {
                    Console.WriteLine($"Tìm thấy sản phẩm:");
                    Console.WriteLine($"Mã: {fields[0]}, Tên: {fields[1]}, Hãng: {fields[2]}, Giá: {fields[3]}, Mô tả: {fields[4]}");
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Không tìm thấy sản phẩm có mã bạn nhập.");
        }
    }
}

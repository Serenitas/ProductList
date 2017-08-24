using System;

namespace ProductList.Products
{
    class Product
    {
        public Product(string name, double price, string barcode)
        {
            Name = name;
            Price = price;
            Barcode = barcode;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Barcode { get; set; }

        public static readonly string AttributeSeparator = Environment.NewLine;

        public virtual string GetData()
        {
            const string productName = "Название: ";
            const string price = "Цена: ";
            const string barcode = "Штрихкод: ";
            return string.Concat(productName, Name, AttributeSeparator, price, Price, AttributeSeparator, barcode, Barcode);
        }
    }
}

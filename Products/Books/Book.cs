using System;

namespace ProductList.Products.Books
{
    class Book : Product
    {
        public Book(string name, double price, string barcode, int pageCount) : base(name, price, barcode)
        {
            PageCount = pageCount;
        }

        public int PageCount { get; set; }

        public override string GetData()
        {
            const string pageCount = "Количество страниц: ";

            return string.Concat(base.GetData(), AttributeSeparator, pageCount, PageCount);
        }
    }
}

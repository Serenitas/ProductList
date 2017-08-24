namespace ProductList.Products.Books
{
    class EsotericsBook : Book
    {
        public EsotericsBook(string name, double price, string barcode, int pageCount, int readerMinimumAge) : base(name, price, barcode, pageCount)
        {
            ReaderMinimumAge = readerMinimumAge;
        }

        public int ReaderMinimumAge { get; set; }
        public override string GetData()
        {
            const string readerMinimumAge = "Минимальный возраст читателя: ";

            return string.Concat(base.GetData(), AttributeSeparator, readerMinimumAge, ReaderMinimumAge);
        }
    }
}

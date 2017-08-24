namespace ProductList.Products.Books
{
    class ProgrammingBook : Book
    {
        public ProgrammingBook(string name, double price, string barcode, int pageCount, string programmingLanguage) : base(name, price, barcode, pageCount)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public string ProgrammingLanguage { get; set; }
        public override string GetData()
        {
            const string programmingLanguage = "Язык программирования: ";

            return string.Concat(base.GetData(), AttributeSeparator, programmingLanguage, ProgrammingLanguage);
        }
    }
}

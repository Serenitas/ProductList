namespace ProductList.Products.Books
{
    class CookeryBook : Book
    {
        public CookeryBook(string name, double price, string barcode, int pageCount, string mainIngredient) : base(name, price, barcode, pageCount)
        {
            MainIngredient = mainIngredient;
        }

        public string MainIngredient { get; set; }
        public override string GetData()
        {
            const string mainIngredient = "Основной ингредиент: ";

            return string.Concat(base.GetData(), AttributeSeparator, mainIngredient, MainIngredient);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ProductList.Products;
using ProductList.Products.Books;
using ProductList.Products.Discs;

namespace ProductList
{
    class Program
    {
        private const string ProductTypeBook = "book";
        private const string ProductTypeDisc = "disc";
        private const string BookThemeProgramming = "programming";
        private const string BookThemeCookery = "cookery";
        private const string BookThemeEsoterics = "esoterics";

        private const string DatabaseName = "productsBase.txt";

        private static LinkedList<Product> ReadProductsData(string filename)
        {
            var productList = new LinkedList<Product>();

            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            try
            {
                using (var inFileStream = new FileStream(path, FileMode.Open))
                {
                    using (var streamReader = new StreamReader(inFileStream))
                    {
                        string productType;
                        while ((productType = streamReader.ReadLine()) != null)
                        {
                            if (productType == ProductTypeBook)
                            {
                                var bookTheme = streamReader.ReadLine();
                                var name = streamReader.ReadLine();
                                var priceString = streamReader.ReadLine();
                                var price = 0.0;
                                if (priceString != null)
                                {
                                    try
                                    {
                                        price = double.Parse(priceString, CultureInfo.InvariantCulture);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine(
                                            "Неверный формат цены продукта {0}, требуется значение в формате 00.00",
                                            name);
                                    }
                                }
                                var barCode = streamReader.ReadLine();
                                var pageCountString = streamReader.ReadLine();
                                var pageCount = 0;
                                if (pageCountString != null)
                                {
                                    try
                                    {
                                        pageCount = int.Parse(pageCountString);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine(
                                            "Неверный формат количества страниц продукта {0}, требуется целочисленное значение",
                                            name);
                                    }
                                }
                                switch (bookTheme)
                                {
                                    case BookThemeProgramming:
                                        var language = streamReader.ReadLine();
                                        productList.AddLast(new ProgrammingBook(name, price, barCode, pageCount,
                                            language));
                                        break;
                                    case BookThemeCookery:
                                        var ingredient = streamReader.ReadLine();
                                        productList.AddLast(
                                            new CookeryBook(name, price, barCode, pageCount, ingredient));
                                        break;
                                    case BookThemeEsoterics:
                                        var ageString = streamReader.ReadLine();
                                        var age = 0;
                                        if (ageString != null)
                                        {
                                            try
                                            {
                                                age = int.Parse(ageString);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine(
                                                    "Неверный формат возраста читателя в продукте {0}, требуется целочисленное значение",
                                                    name);
                                            }
                                        }
                                        productList.AddLast(new EsotericsBook(name, price, barCode, pageCount, age));
                                        break;
                                    default:
                                        Console.WriteLine("Тема книги {0} неизвестна", name);
                                        break;
                                }
                            }
                            else if (productType == ProductTypeDisc)
                            {
                                var discType = streamReader.ReadLine();
                                var name = streamReader.ReadLine();
                                var priceString = streamReader.ReadLine();
                                var price = 0.0;
                                if (priceString != null)
                                {
                                    try
                                    {
                                        price = double.Parse(priceString, CultureInfo.InvariantCulture);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine(
                                            "Неверный формат цены продукта {0}, требуется значение в формате 00.00",
                                            name);
                                    }
                                }
                                var barCode = streamReader.ReadLine();
                                var contentType = streamReader.ReadLine();
                                productList.AddLast(new Disc(name, price, barCode, discType, contentType));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return productList;
        }

        private static void WriteProductsData(LinkedList<Product> products)
        {
            const string books = "1. Книги";
            const string programmingBooks = "1.1. Книги по программированию";
            const string cookeryBooks = "1.2. Книги по кулинарии";
            const string esotericsBooks = "1.3. Книги по эзотерике";
            const string discs = "2. Диски";
            const string discsCd = "2.1. CD-диски";
            const string discsDvd = "2.2. DVD-диски";
            const string discsCdMusic = "2.1.1. CD-диски c музыкой";
            const string discsCdVideo = "2.1.2. CD-диски c видео";
            const string discsCdSoftware = "2.1.3. CD-диски c ПО";
            const string discsDvdMusic = "2.2.1. DVD-диски c музыкой";
            const string discsDvdVideo = "2.2.2. DVD-диски c видео";
            const string discsDvdSoftware = "2.2.3. DVD-диски c ПО";
        
            Console.WriteLine(books);
            #region books data writing
            Console.WriteLine(programmingBooks);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(ProgrammingBook))
                { 
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            Console.WriteLine(cookeryBooks);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(CookeryBook))
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            Console.WriteLine(esotericsBooks);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(EsotericsBook))
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
#endregion
            Console.WriteLine(discs);
            Console.WriteLine(discsCd);
            #region cd discs data writing
            Console.WriteLine(discsCdMusic);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(Disc) &&
                    ((Disc) products.ElementAt(i)).DiscType == Disc.DiscTypeCd &&
                    ((Disc) products.ElementAt(i)).DiscContentType == Disc.DiscContentTypeMusic)
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            Console.WriteLine(discsCdVideo);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(Disc) &&
                    ((Disc)products.ElementAt(i)).DiscType == Disc.DiscTypeCd &&
                    ((Disc)products.ElementAt(i)).DiscContentType == Disc.DiscContentTypeVideo)
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            Console.WriteLine(discsCdSoftware);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(Disc) &&
                    ((Disc)products.ElementAt(i)).DiscType == Disc.DiscTypeCd &&
                    ((Disc)products.ElementAt(i)).DiscContentType == Disc.DiscContentTypeSoftware)
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            #endregion
            Console.WriteLine(discsDvd);
            #region dvd discs data writing
            Console.WriteLine(discsDvdMusic);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(Disc) &&
                    ((Disc)products.ElementAt(i)).DiscType == Disc.DiscTypeDvd &&
                    ((Disc)products.ElementAt(i)).DiscContentType == Disc.DiscContentTypeMusic)
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            Console.WriteLine(discsDvdVideo);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(Disc) &&
                    ((Disc)products.ElementAt(i)).DiscType == Disc.DiscTypeDvd &&
                    ((Disc)products.ElementAt(i)).DiscContentType == Disc.DiscContentTypeVideo)
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
            Console.WriteLine(discsDvdSoftware);
            for (var i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).GetType() == typeof(Disc) &&
                    ((Disc)products.ElementAt(i)).DiscType == Disc.DiscTypeDvd &&
                    ((Disc)products.ElementAt(i)).DiscContentType == Disc.DiscContentTypeSoftware)
                {
                    Console.WriteLine(products.ElementAt(i).GetData());
                    Console.WriteLine();
                    products.Remove(products.ElementAt(i));
                }
            }
#endregion
        }

        private static void Main(string[] args)
        {
            var productList = ReadProductsData(DatabaseName);

            WriteProductsData(productList);
            Console.ReadKey();
        }
    }
}

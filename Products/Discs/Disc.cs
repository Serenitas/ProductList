using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList.Products.Discs
{

    class Disc : Product
    {
        public Disc(string name, double price, string barcode, string discType, string discContentType) : base(name, price, barcode)
        {
            DiscType = discType;
            DiscContentType = discContentType;
        }

        public string DiscType { get; set; }
        public string DiscContentType { get; set; }

        public const string DiscTypeCd = "CD";
        public const string DiscTypeDvd = "DVD";
        public const string DiscContentTypeMusic = "music";
        public const string DiscContentTypeVideo = "video";
        public const string DiscContentTypeSoftware = "software";

        public override string GetData()
        {
            const string discType = "Тип диска: ";
            const string discContentType = "Содержимое диска: ";

            return string.Concat(base.GetData(), AttributeSeparator, discType, DiscType, AttributeSeparator, discContentType, DiscContentType);
        }
    }
}

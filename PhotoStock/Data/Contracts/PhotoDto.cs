using System;

namespace PhotoStock.Data.Contracts
{
    public record PhotoDto 
    {
        public string Name { get; set; }
        public string ContentUri { get; set; }
        public string Size { get; set; }
        public DateTime CreationDate { get; set; }
        public string AuthorName { get; set; }
        public string AuthorNickname { get; set; }
        public decimal Price { get; set; }
        public int CountOfPurchases { get; set; }
        public int Rating { get; set; }
    }
}

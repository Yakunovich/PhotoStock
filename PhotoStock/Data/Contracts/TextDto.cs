using System;

namespace PhotoStock.Data.Contracts
{
    public class TextDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public DateTime CreationDate { get; set; }
        public Decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string AuthorNickname { get; set; }
        public int CountOfPurchases { get; set; }
        public int Rating { get; set; }
        public override string ToString()
        {
            return $"{Name},{Content},{Size},{CreationDate},{Price},{AuthorName},{AuthorNickname},{Rating}";
        }
    }
}

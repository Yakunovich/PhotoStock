using System;
using System.Collections.Generic;

namespace PhotoStock.Data.Models
{
    public class Text : BaseModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public DateTime CreationDate { get; set; }
        public Decimal Price { get; set; }
        public Guid AuthorId { get; set; }
        public Guid RatingId { get; set; }
        public int CountOfPurchases { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual Author Author { get; set; }

    }
}

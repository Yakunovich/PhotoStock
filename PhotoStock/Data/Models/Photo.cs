using System;
using System.Collections.Generic;

namespace PhotoStock.Data.Models
{
    public class Photo : BaseModel
    {
        public  string Name { get; set; }
        public string ContentUri { get; set; }
        public string Size { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid RatingId { get; set; }
        public decimal Price { get; set; }
        public int CountOfPurchases { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual Author Author { get; set; }
    }
}

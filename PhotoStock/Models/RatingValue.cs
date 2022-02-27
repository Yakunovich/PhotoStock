using PhotoStock.Data.Models;
using System;

namespace PhotoStock.Data.Models
{
    public class RatingValue : BaseModel
    {
        public int Value { get; set; }
        public Guid RatingId { get; set; }
        public virtual Rating Rating { get; set; }
    }
}

using PhotoStock.Models;
using System;
using System.Collections.Generic;

namespace PhotoStock.Data.Models
{
    public class Rating : BaseModel
    {
        public virtual List<RatingValue> RatingValues { get; set; } = new List<RatingValue>();
        public double AvarageRating()
        {
            double avg = 0;
            foreach(var rating in RatingValues)
            {
                avg += (double)rating.Value/ RatingValues.Count;
            }
            return avg;
        }
        public List<RatingValue> AddRatingValue(int ratingValue, Guid ratingId)
        {
            RatingValues.Add(new RatingValue() { Id = Guid.NewGuid(), RatingId = ratingId, Value = ratingValue});

            return RatingValues;
        }
        
    }
}

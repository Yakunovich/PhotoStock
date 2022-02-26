using System;

namespace PhotoStock.Data.Models
{
    public class Author : BaseModel
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountCreationDate { get; set; }

    }
}

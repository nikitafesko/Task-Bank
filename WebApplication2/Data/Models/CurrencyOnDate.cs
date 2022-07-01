using System;

namespace WebApplication2.Data.Models
{
    public class CurrencyOnDate
    {
        public Guid Id { get; set; }
        public int Curr_Id { get; set; }
        public double Curval { get; set; }
        public DateTime Date { get; set; }
    }
}

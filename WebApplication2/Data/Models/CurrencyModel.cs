namespace WebApplication2.Data.Models
{
    public class CurrencyModel
    {
        public int Cur_ID { get; set; }
        public int Cur_Code { get; set; }
        public string Cur_Abbreviation { get; set; }
        public string Cur_Name { get; set; }
        public string Cur_QuotName { get; set; }
        public DateTime Cur_DateStart { get; set; }
        public DateTime Cur_DateEnd { get; set; }
    }
}

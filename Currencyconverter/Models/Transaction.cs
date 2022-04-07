using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Currencyconverter.Models
{
    public class Transaction
    {
        public int transactionId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Amount")]
        public decimal amountFrom { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Convert To")]
        public decimal amountTo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Rate")]
        public decimal rate { get; set; }

        [Display(Name = "Currency")]
        public string currencyFrom { get; set; }

        [Display(Name = "Converted To")]
        public string currencyTo { get; set; }

        [Display(Name = "Date")]
        public DateTime? createdDate { get; set; } = DateTime.Now;
    }
}

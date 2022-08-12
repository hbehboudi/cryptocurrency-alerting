using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels.Rule
{
    public class AddRuleViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }

        public string Description { get; set; }

        [Required]
        public string Indicator { get; set; }

        [Required]
        public string MorePriceType { get; set; }

        [Required]
        public string LessPriceType { get; set; }

        [Required]
        public int MorePeriod { get; set; }

        [Required]
        public int LessPeriod { get; set; }

        [Required]
        public string TimeFrame { get; set; }

        [Required]
        public string Condition { get; set; }
    }
}

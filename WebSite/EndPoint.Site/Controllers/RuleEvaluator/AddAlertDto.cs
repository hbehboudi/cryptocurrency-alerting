using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Controllers.RuleEvaluator
{
    public class AddAlertDto
    {
        [Required]
        public long RuleId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public long Time { get; set; }

        public string Secretkey { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using WebSite.Domain.Entities.Commons;

namespace WebSite.Domain.Entities.Alert
{
    public class Alert : BaseEntity
    {
        [Required]
        public long RuleId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}

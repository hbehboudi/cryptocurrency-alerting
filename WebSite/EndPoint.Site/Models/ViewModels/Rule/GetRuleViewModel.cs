using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.Rule
{
    public class GetRuleViewModel
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public string Description { get; set; }

        public string Indicator { get; set; }

        public string MorePriceType { get; set; }

        public string LessPriceType { get; set; }

        public int MorePeriod { get; set; }

        public int LessPeriod { get; set; }
    }
}

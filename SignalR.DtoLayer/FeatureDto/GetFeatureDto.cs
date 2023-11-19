using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.FeatureDto
{
    public class GetFeatureDto
    {
        public int FeatureId { get; set; }
        public string TitleFirst { get; set; }
        public string DescriptionFirst { get; set; }
        public string TitleTwo { get; set; }
        public string DescriptionTwo { get; set; }
        public string TitleThree { get; set; }
        public string DescriptionThree { get; set; }
    }
}

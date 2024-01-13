using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.FeatureDtos;

public class ResultFeatureDto
{
    public int FeatureId { get; set; }
    public string TitleFirst { get; set; }
    public string DescriptionFirst { get; set; }
    public string TitleTwo { get; set; }
    public string DescriptionTwo { get; set; }
    public string TitleThree { get; set; }
    public string DescriptionThree { get; set; }
}


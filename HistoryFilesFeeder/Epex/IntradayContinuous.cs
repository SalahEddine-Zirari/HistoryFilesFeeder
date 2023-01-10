using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace HistoryFilesFeeder.Epex;

public class IntradayContinuous
{
    [Key]
    public DateTime DeliveryStart { get; set; }
    public DateTime DeliveryEnd { get; set; }
    [Ignore]
    public string? Area { get; set; } = "austria";
    public double? LowPrice { get; set; }
    public double? HighPrice { get; set; }
    public double? LastPrice { get; set; }
    public double? WeightedAveragePrice { get; set; }
    public string? Currency { get; set; }
    public DateTime LastPriceTimestamp { get; set; }
    public double? VolumeBuy { get; set; }
    public double? VolumeSell { get; set; }
    public string? VolumeUnit { get; set; }


}

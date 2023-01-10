using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryFilesFeeder.Epex.Epex.EntityFramework;

public class IntradayContinuousMapping : ClassMap<IntradayContinuous>
{
    public IntradayContinuousMapping()
    {
        Map(x => x.DeliveryStart).Index(0);
        Map(x => x.DeliveryEnd).Index(1);
        Map(x => x.LowPrice).Index(2);
        Map(x => x.HighPrice).Index(3);
        Map(x => x.LastPrice).Index(4);
        Map(x => x.WeightedAveragePrice).Index(5);
        Map(x => x.Currency).Index(6);
        Map(x => x.LastPriceTimestamp).Index(7);
        Map(x => x.VolumeBuy).Index(8);
        Map(x => x.VolumeSell).Index(9);
        Map(x => x.VolumeUnit).Index(10);

    }
}

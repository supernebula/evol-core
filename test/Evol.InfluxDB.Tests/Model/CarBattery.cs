using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.InfluxDB.Tests.Model
{
    public class CarBattery
    {
        public int Id { get; set; }

        public string DeviceNumber { get; set; }

        public string CustomerCode { get; set; }

        public string DeviceWays { get; set; }

        public string TransactionID { get; set; }

        public double RVOL { get; set; }

        public double RCUR { get; set; }

        public double Ptemp { get; set; }

        public double Ntemp { get; set; }

        public double BATType { get; set; }

        public double BATPOW { get; set; }

        public double Capacity { get; set; }

        public double MaxCVol { get; set; }

        public double MaxCCur { get; set; }

        public double SigleMaxVol { get; set; }

        public double SigleMinVol { get; set; }

        public double StartSigleMaxVol { get; set; }

        public double StartSigleMinVol { get; set; }

        public double EndSigleMaxVol { get; set; }

        public double EndSigleMinVol { get; set; }

        public double MaxTemp { get; set; }

        public double StartVol { get; set; }

        public string VIN { get; set; }

        public DateTime CreateDate { get; set; }
    }
}

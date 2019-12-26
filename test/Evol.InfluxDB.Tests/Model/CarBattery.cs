using AdysTech.InfluxDB.Client.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.InfluxDB.Tests.Model
{
    public class CarBattery : InfluxDatapoint<double>
    {
        public string DeviceNumber
        {
            get  { return Tags.GetValueOrDefault(nameof(DeviceNumber)); }
            set { this.Tags.Add(nameof(DeviceNumber), value); }
        }

        public string CustomerCode
        {
            get { return Tags.GetValueOrDefault(nameof(CustomerCode)); }
            set { this.Tags.Add(nameof(CustomerCode), value); }
        }

        public string DeviceWays
        {
            get { return Tags.GetValueOrDefault(nameof(DeviceWays)); }
            set { this.Tags.Add(nameof(DeviceWays), value); }
        }

        public string TransactionID
        {
            get { return Tags.GetValueOrDefault(nameof(TransactionID)); }
            set { this.Tags.Add(nameof(TransactionID), value); }
        }

        public string VIN
        {
            get { return Tags.GetValueOrDefault(nameof(VIN)); }
            set { this.Tags.Add(nameof(VIN), value); }
        }

        public double RVOL
        {
            get { return Fields.GetValueOrDefault(nameof(RVOL)); }
            set { this.Fields.Add(nameof(RVOL), value); }
        }

        public double RCUR
        {
            get { return Fields.GetValueOrDefault(nameof(RCUR)); }
            set { this.Fields.Add(nameof(RCUR), value); }
        }

        public double Ptemp
        {
            get { return Fields.GetValueOrDefault(nameof(Ptemp)); }
            set { this.Fields.Add(nameof(Ptemp), value); }
        }

        public double Ntemp
        {
            get { return Fields.GetValueOrDefault(nameof(Ntemp)); }
            set { this.Fields.Add(nameof(Ntemp), value); }
        }

        public double BATType
        {
            get { return Fields.GetValueOrDefault(nameof(BATType)); }
            set { this.Fields.Add(nameof(BATType), value); }
        }

        public double BATPOW
        {
            get { return Fields.GetValueOrDefault(nameof(BATPOW)); }
            set { this.Fields.Add(nameof(BATPOW), value); }
        }

        public double Capacity
        {
            get { return Fields.GetValueOrDefault(nameof(Capacity)); }
            set { this.Fields.Add(nameof(Capacity), value); }
        }

        public double MaxCVol
        {
            get { return Fields.GetValueOrDefault(nameof(MaxCVol)); }
            set { this.Fields.Add(nameof(MaxCVol), value); }
        }

        public double MaxCCur
        {
            get { return Fields.GetValueOrDefault(nameof(MaxCCur)); }
            set { this.Fields.Add(nameof(MaxCCur), value); }
        }

        public double SigleMaxVol
        {
            get { return Fields.GetValueOrDefault(nameof(SigleMaxVol)); }
            set { this.Fields.Add(nameof(SigleMaxVol), value); }
        }

        public double SigleMinVol
        {
            get { return Fields.GetValueOrDefault(nameof(SigleMinVol)); }
            set { this.Fields.Add(nameof(SigleMinVol), value); }
        }

        public double StartSigleMaxVol
        {
            get { return Fields.GetValueOrDefault(nameof(StartSigleMaxVol)); }
            set { this.Fields.Add(nameof(StartSigleMaxVol), value); }
        }

        public double StartSigleMinVol
        {
            get { return Fields.GetValueOrDefault(nameof(StartSigleMinVol)); }
            set { this.Fields.Add(nameof(StartSigleMinVol), value); }
        }

        public double EndSigleMaxVol
        {
            get { return Fields.GetValueOrDefault(nameof(EndSigleMaxVol)); }
            set { this.Fields.Add(nameof(EndSigleMaxVol), value); }
        }

        public double EndSigleMinVol
        {
            get { return Fields.GetValueOrDefault(nameof(EndSigleMinVol)); }
            set { this.Fields.Add(nameof(EndSigleMinVol), value); }
        }

        public double MaxTemp
        {
            get { return Fields.GetValueOrDefault(nameof(MaxTemp)); }
            set { this.Fields.Add(nameof(MaxTemp), value); }
        }

        public double StartVol
        {
            get { return Fields.GetValueOrDefault(nameof(StartVol)); }
            set { this.Fields.Add(nameof(StartVol), value); }
        }



        public DateTime CreateDate
        {
            get { return this.UtcTimestamp; }
            set { this.UtcTimestamp = value; }
        }
    }
}

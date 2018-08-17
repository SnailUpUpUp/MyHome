using System;
using System.Collections.Generic;

namespace MyHome.Models
{
    public class Temperature
    {
        public int ID { get; set; }

        public string DeviceName { get; set; }
        public float Temp { get; set; }
        public float Humidity { get; set; }
        public DateTime AcquisitionTime { get; set; }

        public string Memo { get; set; }
    }
}
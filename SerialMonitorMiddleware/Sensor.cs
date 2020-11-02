using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    class Sensor : ISensor {
        public int id { get; set; }
        public string name { get; set; }
        public IRecord[] records { get; set; }

        public Sensor(int id, string name) {
            this.id = id;
            this.name = name;
        }
    }
}

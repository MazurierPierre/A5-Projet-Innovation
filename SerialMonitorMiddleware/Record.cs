using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    class Record : IRecord {
        
        public Record(float value, DateTime recordedAt) {
            this.value = value;
            this.recordedAt = recordedAt;
        }

        public float value { get; set; }
        public DateTime recordedAt { get; set; }
    }
}

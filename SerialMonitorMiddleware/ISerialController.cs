using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    interface ISerialController {

        void monitorSerial();
        bool interpretLine(string line);

    }
}

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace SerialMonitorMiddleware {
    class SerialController : ISerialController {

        private IDAL dal;
        private SerialPort port;

        public SerialController(IDAL dal, string port, int baudRate) {
            this.port = new SerialPort(port, baudRate);
            this.dal = dal;
        }
        public bool interpretLine(string line) {

            // Slice input
            string[] info = line.Split(':');

            if (info.Length != 2)
                return false;

            ISensor sensor = new Sensor(int.Parse(info[0]), "SEN" + info[0]);
            IRecord record = new Record(int.Parse(info[1]), DateTime.Now);

            // Verify if sensor already exists, if not create new sensor
            if (dal.getSensor(sensor.id) == null) {
                dal.addSensor(sensor);
            }

            // Update database
            dal.addRecord(sensor, record);

            return true;
        }

        public void monitorSerial() {
            this.port.Open();

            while (true) {
                interpretLine(this.port.ReadLine());
            }
        }
    }
}

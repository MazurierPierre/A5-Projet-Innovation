using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialMonitorMiddleware {
    class Program {
        static void Main(string[] args) {

            if(args.Length != 6) {
                Console.WriteLine("Syntax : SerialMonitorMiddleware [Serial port name] [Serial baud rate] [MySql server address] [MySql username] [MySql password] [MySql target database]");
                return;
            }

            IDAL dal = new DAL("server=" + args[2] + ";userid=" + args[3] + ";password=" + args[4] + ";database=" + args[5] + ";");

            ISerialController controller = new SerialController(dal, args[0].ToString(), int.Parse(args[1]));
            controller.monitorSerial();
        }
    }
}

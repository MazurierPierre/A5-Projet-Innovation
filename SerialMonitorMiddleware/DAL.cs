using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerialMonitorMiddleware {
    class DAL : IDAL {
        private MySqlConnection conn;

        public DAL(string connString) {

            conn = new MySqlConnection(connString);

            Console.WriteLine("Attempting to connect to database ...");

            try {
                conn.Open();
                Console.WriteLine("Connection successful !");
            } catch (Exception e) {
                Console.WriteLine("Failed to connect to database.");
            }
        }

        public bool addSensor(ISensor sensor) {
            var cmd = new MySqlCommand("INSERT INTO sensor (id, name, type_id) VALUES (" + sensor.id + ", '" + sensor.name + "', 1);", this.conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Added new sensor (" + sensor.id + ") : " + sensor.name);

            return true;
        }

        public bool addRecord(ISensor sensor, IRecord record) {
            var cmd = new MySqlCommand("INSERT INTO recording (sensor_id, value, recorded_at) VALUES (" + sensor.id + ", " + record.value + ",'" + record.recordedAt.ToString("yyyy-MM-dd HH:mm:ss") + "');", this.conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Added new record (" + record.value + ") to sensor (" + sensor.id + ")");

            return true;
        }

        public ISensor getSensor(int id) {

            Sensor sensor = null;

            var cmd = new MySqlCommand("SELECT name FROM sensor WHERE id=" + id + ";", this.conn);
            MySqlDataReader response = cmd.ExecuteReader();
            
            if(response.HasRows) {
                response.Read();
                sensor = new Sensor(id, response.GetValue(0).ToString());
            }

            response.Close();

            return sensor;
        }

        public IRecord getRecord(int id) {
            throw new NotImplementedException();
        }
    }
}

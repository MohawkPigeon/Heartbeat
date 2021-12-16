using System;
using Prometheus;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Heartbeat.Models;
using Heartbeat.Data;
using Geohash;
using System.Globalization;
using System.IO;

namespace Heartbeat
{
    public class Program
    {
        private static HeartbeatContext db = new HeartbeatContext();


        private static readonly List<Counter> counters = new List<Counter>
        {
                    Metrics.CreateCounter("Adresse_1", "totalPriceSumInclVat"),
                    Metrics.CreateCounter("Adresse_2", "1"),
                    Metrics.CreateCounter("Adresse_3", "1"),
                    Metrics.CreateCounter("Adresse_4", "1"),
                    Metrics.CreateCounter("Adresse_5", "1"),
                    Metrics.CreateCounter("Adresse_6", "1"),
                    Metrics.CreateCounter("Adresse_7", "1"),
                    Metrics.CreateCounter("Adresse_8", "1"),
                    Metrics.CreateCounter("Adresse_9", "1"),
                    Metrics.CreateCounter("Adresse_10", "1"),
                    Metrics.CreateCounter("Adresse_11", "1"),
                    Metrics.CreateCounter("Adresse_12", "1"),
                    Metrics.CreateCounter("Adresse_13", "1"),
                    Metrics.CreateCounter("Adresse_14", "1"),
                    Metrics.CreateCounter("Adresse_15", "1"),
                    Metrics.CreateCounter("Adresse_16", "1"),
                    Metrics.CreateCounter("Adresse_17", "1"),
                    Metrics.CreateCounter("Adresse_18", "1"),
                    Metrics.CreateCounter("Adresse_19", "1"),
                    Metrics.CreateCounter("Adresse_20", "1"),
                    Metrics.CreateCounter("Adresse_21", "1"),
                    Metrics.CreateCounter("Adresse_22", "1"),
                    Metrics.CreateCounter("Adresse_23", "1"),
                    Metrics.CreateCounter("Adresse_24", "1"),
                    Metrics.CreateCounter("Adresse_25", "1"),
                    Metrics.CreateCounter("Adresse_26", "1"),
                    Metrics.CreateCounter("Adresse_27", "1"),
                    Metrics.CreateCounter("Adresse_28", "1"),
                    Metrics.CreateCounter("Adresse_29", "1"),
                    Metrics.CreateCounter("Adresse_30", "1"),
                    Metrics.CreateCounter("Adresse_31", "1"),
                    Metrics.CreateCounter("Adresse_32", "1"),
                    Metrics.CreateCounter("Adresse_33", "1"),
                    Metrics.CreateCounter("Adresse_34", "1"),
                    Metrics.CreateCounter("Adresse_35", "1"),
                    Metrics.CreateCounter("Adresse_36", "1"),
                    Metrics.CreateCounter("Adresse_37", "1"),
                    Metrics.CreateCounter("Adresse_38", "1"),
                    Metrics.CreateCounter("Adresse_39", "1"),
                    Metrics.CreateCounter("Adresse_40", "1"),
                    Metrics.CreateCounter("Adresse_41", "1"),
                    Metrics.CreateCounter("Adresse_42", "1"),
                    Metrics.CreateCounter("Adresse_43", "1"),
                    Metrics.CreateCounter("Adresse_44", "1"),
                    Metrics.CreateCounter("Adresse_45", "1"),
                    Metrics.CreateCounter("Adresse_46", "1"),
                    Metrics.CreateCounter("Adresse_47", "1"),
                    Metrics.CreateCounter("Adresse_48", "1"),
                    Metrics.CreateCounter("Adresse_49", "1"),
                    Metrics.CreateCounter("Adresse_50", "1"),
                    Metrics.CreateCounter("Adresse_51", "1"),
                    Metrics.CreateCounter("Adresse_52", "1"),
                    Metrics.CreateCounter("Adresse_53", "1"),
                    Metrics.CreateCounter("Adresse_54", "1"),
                    Metrics.CreateCounter("Adresse_55", "1"),
                    Metrics.CreateCounter("Adresse_56", "1"),
                    Metrics.CreateCounter("Adresse_57", "1"),
                    Metrics.CreateCounter("Adresse_58", "1"),
                    Metrics.CreateCounter("Adresse_59", "1"),
                    Metrics.CreateCounter("Adresse_60", "1"),
                    Metrics.CreateCounter("Adresse_61", "1"),
                    Metrics.CreateCounter("Adresse_62", "1"),
                    Metrics.CreateCounter("Adresse_63", "1"),
                    Metrics.CreateCounter("Adresse_64", "1"),
                    Metrics.CreateCounter("Adresse_65", "1"),
                    Metrics.CreateCounter("Adresse_66", "1"),
                    Metrics.CreateCounter("Adresse_67", "1"),
                    Metrics.CreateCounter("Adresse_68", "1"),
                    Metrics.CreateCounter("Adresse_69", "1"),
                    Metrics.CreateCounter("Adresse_70", "1"),
                    Metrics.CreateCounter("Adresse_71", "1"),
                    Metrics.CreateCounter("Adresse_72", "1"),
                    Metrics.CreateCounter("Adresse_73", "1"),
                    Metrics.CreateCounter("Adresse_74", "1"),
                    Metrics.CreateCounter("Adresse_75", "1"),
                    Metrics.CreateCounter("Adresse_76", "1"),
                    Metrics.CreateCounter("Adresse_77", "1"),
                    Metrics.CreateCounter("Adresse_78", "1"),
                    Metrics.CreateCounter("Adresse_79", "1"),
                    Metrics.CreateCounter("Adresse_80", "1"),
                    Metrics.CreateCounter("Adresse_81", "1"),
                    Metrics.CreateCounter("Adresse_82", "1"),
                    Metrics.CreateCounter("Adresse_83", "1"),
                    Metrics.CreateCounter("Adresse_84", "1"),
                    Metrics.CreateCounter("Adresse_85", "1"),
                    Metrics.CreateCounter("Adresse_86", "1"),
                    Metrics.CreateCounter("Adresse_87", "1"),
                    Metrics.CreateCounter("Adresse_88", "1"),
                    Metrics.CreateCounter("Adresse_89", "1"),
                    Metrics.CreateCounter("Adresse_90", "1"),
                    Metrics.CreateCounter("Adresse_91", "1"),
                    Metrics.CreateCounter("Adresse_92", "1"),
                    Metrics.CreateCounter("Adresse_93", "1"),
                    Metrics.CreateCounter("Adresse_94", "1"),
                    Metrics.CreateCounter("Adresse_95", "1"),
                    Metrics.CreateCounter("Adresse_96", "1"),
        };
        private static readonly Counter heartbeat = Metrics.CreateCounter("Heartbeat", "Heartbeat Counter");
        public static void createKeysForWorldmap()
        {
            List<Key> keys = new List<Key>();
            List<Address> addresses = db.Addresses.ToList();

            for (int i = 0; i < addresses.Count; i++)
            {
                Key key = new Key();
                key.latitude = addresses[i].addressXCoordinate;
                key.longitude = addresses[i].addressYCoordinate;
                key.name = addresses[i].street;
                keys.Add(key);

                if (db.Keys.FirstOrDefault() == null)
                db.Keys.Add(key);
            }
            db.SaveChanges();
        }

        public static void Main()
        {
            Console.WriteLine("Child thread starts");
            var server = new MetricServer(hostname: "localhost", port: 1234);
            server.Start();

            List<Order> orders = db.Orders.ToList();

            for (int i = 0; i < counters.Count; i++)
            {
                counters[i].IncTo(orders[i].totalPriceSumInclVat);

            }
            while (true)
            {
                heartbeat.IncTo(db.Orders.Count());
                Thread.Sleep(60000);
            }
        }
    }
}
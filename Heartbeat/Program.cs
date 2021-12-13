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

    public class Target
    {
        public string target { get; set; }
        public List<string> datapoints { get; set;}
    }

    public class Program
    {
        private static HeartbeatContext db = new HeartbeatContext();
        private static readonly Counter TickTock =
        Metrics.CreateCounter("sampleapp_ticks_total", "Just keeps on ticking");

        private static readonly List<Counter> counters = new List<Counter>
        {
                    Metrics.CreateCounter("Adresse_1", "Size"),
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

        private static readonly List<Counter> hashCounters = new List<Counter>
        {
                    Metrics.CreateCounter("Adresse_1_", "Latitude"),
                    Metrics.CreateCounter("Adresse_2_", "1"),
                    Metrics.CreateCounter("Adresse_3_", "1"),
                    Metrics.CreateCounter("Adresse_4_", "1"),
                    Metrics.CreateCounter("Adresse_5_", "1"),
                    Metrics.CreateCounter("Adresse_6_", "1"),
                    Metrics.CreateCounter("Adresse_7_", "1"),
                    Metrics.CreateCounter("Adresse_8_", "1"),
                    Metrics.CreateCounter("Adresse_9_", "1"),
                    Metrics.CreateCounter("Adresse_10_", "1"),
                    Metrics.CreateCounter("Adresse_11_", "1"),
                    Metrics.CreateCounter("Adresse_12_", "1"),
                    Metrics.CreateCounter("Adresse_13_", "1"),
                    Metrics.CreateCounter("Adresse_14_", "1"),
                    Metrics.CreateCounter("Adresse_15_", "1"),
                    Metrics.CreateCounter("Adresse_16_", "1"),
                    Metrics.CreateCounter("Adresse_17_", "1"),
                    Metrics.CreateCounter("Adresse_18_", "1"),
                    Metrics.CreateCounter("Adresse_19_", "1"),
                    Metrics.CreateCounter("Adresse_20_", "1"),
                    Metrics.CreateCounter("Adresse_21_", "1"),
                    Metrics.CreateCounter("Adresse_22_", "1"),
                    Metrics.CreateCounter("Adresse_23_", "1"),
                    Metrics.CreateCounter("Adresse_24_", "1"),
                    Metrics.CreateCounter("Adresse_25_", "1"),
                    Metrics.CreateCounter("Adresse_26_", "1"),
                    Metrics.CreateCounter("Adresse_27_", "1"),
                    Metrics.CreateCounter("Adresse_28_", "1"),
                    Metrics.CreateCounter("Adresse_29_", "1"),
                    Metrics.CreateCounter("Adresse_30_", "1"),
                    Metrics.CreateCounter("Adresse_31_", "1"),
                    Metrics.CreateCounter("Adresse_32_", "1"),
                    Metrics.CreateCounter("Adresse_33_", "1"),
                    Metrics.CreateCounter("Adresse_34_", "1"),
                    Metrics.CreateCounter("Adresse_35_", "1"),
                    Metrics.CreateCounter("Adresse_36_", "1"),
                    Metrics.CreateCounter("Adresse_37_", "1"),
                    Metrics.CreateCounter("Adresse_38_", "1"),
                    Metrics.CreateCounter("Adresse_39_", "1"),
                    Metrics.CreateCounter("Adresse_40_", "1"),
                    Metrics.CreateCounter("Adresse_41_", "1"),
                    Metrics.CreateCounter("Adresse_42_", "1"),
                    Metrics.CreateCounter("Adresse_43_", "1"),
                    Metrics.CreateCounter("Adresse_44_", "1"),
                    Metrics.CreateCounter("Adresse_45_", "1"),
                    Metrics.CreateCounter("Adresse_46_", "1"),
                    Metrics.CreateCounter("Adresse_47_", "1"),
                    Metrics.CreateCounter("Adresse_48_", "1"),
                    Metrics.CreateCounter("Adresse_49_", "1"),
                    Metrics.CreateCounter("Adresse_50_", "1"),
                    Metrics.CreateCounter("Adresse_51_", "1"),
                    Metrics.CreateCounter("Adresse_52_", "1"),
                    Metrics.CreateCounter("Adresse_53_", "1"),
                    Metrics.CreateCounter("Adresse_54_", "1"),
                    Metrics.CreateCounter("Adresse_55_", "1"),
                    Metrics.CreateCounter("Adresse_56_", "1"),
                    Metrics.CreateCounter("Adresse_57_", "1"),
                    Metrics.CreateCounter("Adresse_58_", "1"),
                    Metrics.CreateCounter("Adresse_59_", "1"),
                    Metrics.CreateCounter("Adresse_60_", "1"),
                    Metrics.CreateCounter("Adresse_61_", "1"),
                    Metrics.CreateCounter("Adresse_62_", "1"),
                    Metrics.CreateCounter("Adresse_63_", "1"),
                    Metrics.CreateCounter("Adresse_64_", "1"),
                    Metrics.CreateCounter("Adresse_65_", "1"),
                    Metrics.CreateCounter("Adresse_66_", "1"),
                    Metrics.CreateCounter("Adresse_67_", "1"),
                    Metrics.CreateCounter("Adresse_68_", "1"),
                    Metrics.CreateCounter("Adresse_69_", "1"),
                    Metrics.CreateCounter("Adresse_70_", "1"),
                    Metrics.CreateCounter("Adresse_71_", "1"),
                    Metrics.CreateCounter("Adresse_72_", "1"),
                    Metrics.CreateCounter("Adresse_73_", "1"),
                    Metrics.CreateCounter("Adresse_74_", "1"),
                    Metrics.CreateCounter("Adresse_75_", "1"),
                    Metrics.CreateCounter("Adresse_76_", "1"),
                    Metrics.CreateCounter("Adresse_77_", "1"),
                    Metrics.CreateCounter("Adresse_78_", "1"),
                    Metrics.CreateCounter("Adresse_79_", "1"),
                    Metrics.CreateCounter("Adresse_80_", "1"),
                    Metrics.CreateCounter("Adresse_81_", "1"),
                    Metrics.CreateCounter("Adresse_82_", "1"),
                    Metrics.CreateCounter("Adresse_83_", "1"),
                    Metrics.CreateCounter("Adresse_84_", "1"),
                    Metrics.CreateCounter("Adresse_85_", "1"),
                    Metrics.CreateCounter("Adresse_86_", "1"),
                    Metrics.CreateCounter("Adresse_87_", "1"),
                    Metrics.CreateCounter("Adresse_88_", "1"),
                    Metrics.CreateCounter("Adresse_89_", "1"),
                    Metrics.CreateCounter("Adresse_90_", "1"),
                    Metrics.CreateCounter("Adresse_91_", "1"),
                    Metrics.CreateCounter("Adresse_92_", "1"),
                    Metrics.CreateCounter("Adresse_93_", "1"),
                    Metrics.CreateCounter("Adresse_94_", "1"),
                    Metrics.CreateCounter("Adresse_95_", "1"),
                    Metrics.CreateCounter("Adresse_96_", "1"),
        };

        private static readonly List<Counter> hashCounters_ = new List<Counter>
        {
                    Metrics.CreateCounter("Adresse_1__", "Longitude"),
                    Metrics.CreateCounter("Adresse_2__", "1"),
                    Metrics.CreateCounter("Adresse_3__", "1"),
                    Metrics.CreateCounter("Adresse_4__", "1"),
                    Metrics.CreateCounter("Adresse_5__", "1"),
                    Metrics.CreateCounter("Adresse_6__", "1"),
                    Metrics.CreateCounter("Adresse_7__", "1"),
                    Metrics.CreateCounter("Adresse_8__", "1"),
                    Metrics.CreateCounter("Adresse_9__", "1"),
                    Metrics.CreateCounter("Adresse_10__", "1"),
                    Metrics.CreateCounter("Adresse_11__", "1"),
                    Metrics.CreateCounter("Adresse_12__", "1"),
                    Metrics.CreateCounter("Adresse_13__", "1"),
                    Metrics.CreateCounter("Adresse_14__", "1"),
                    Metrics.CreateCounter("Adresse_15__", "1"),
                    Metrics.CreateCounter("Adresse_16__", "1"),
                    Metrics.CreateCounter("Adresse_17__", "1"),
                    Metrics.CreateCounter("Adresse_18__", "1"),
                    Metrics.CreateCounter("Adresse_19__", "1"),
                    Metrics.CreateCounter("Adresse_20__", "1"),
                    Metrics.CreateCounter("Adresse_21__", "1"),
                    Metrics.CreateCounter("Adresse_22__", "1"),
                    Metrics.CreateCounter("Adresse_23__", "1"),
                    Metrics.CreateCounter("Adresse_24__", "1"),
                    Metrics.CreateCounter("Adresse_25__", "1"),
                    Metrics.CreateCounter("Adresse_26__", "1"),
                    Metrics.CreateCounter("Adresse_27__", "1"),
                    Metrics.CreateCounter("Adresse_28__", "1"),
                    Metrics.CreateCounter("Adresse_29__", "1"),
                    Metrics.CreateCounter("Adresse_30__", "1"),
                    Metrics.CreateCounter("Adresse_31__", "1"),
                    Metrics.CreateCounter("Adresse_32__", "1"),
                    Metrics.CreateCounter("Adresse_33__", "1"),
                    Metrics.CreateCounter("Adresse_34__", "1"),
                    Metrics.CreateCounter("Adresse_35__", "1"),
                    Metrics.CreateCounter("Adresse_36__", "1"),
                    Metrics.CreateCounter("Adresse_37__", "1"),
                    Metrics.CreateCounter("Adresse_38__", "1"),
                    Metrics.CreateCounter("Adresse_39__", "1"),
                    Metrics.CreateCounter("Adresse_40__", "1"),
                    Metrics.CreateCounter("Adresse_41__", "1"),
                    Metrics.CreateCounter("Adresse_42__", "1"),
                    Metrics.CreateCounter("Adresse_43__", "1"),
                    Metrics.CreateCounter("Adresse_44__", "1"),
                    Metrics.CreateCounter("Adresse_45__", "1"),
                    Metrics.CreateCounter("Adresse_46__", "1"),
                    Metrics.CreateCounter("Adresse_47__", "1"),
                    Metrics.CreateCounter("Adresse_48__", "1"),
                    Metrics.CreateCounter("Adresse_49__", "1"),
                    Metrics.CreateCounter("Adresse_50__", "1"),
                    Metrics.CreateCounter("Adresse_51__", "1"),
                    Metrics.CreateCounter("Adresse_52__", "1"),
                    Metrics.CreateCounter("Adresse_53__", "1"),
                    Metrics.CreateCounter("Adresse_54__", "1"),
                    Metrics.CreateCounter("Adresse_55__", "1"),
                    Metrics.CreateCounter("Adresse_56__", "1"),
                    Metrics.CreateCounter("Adresse_57__", "1"),
                    Metrics.CreateCounter("Adresse_58__", "1"),
                    Metrics.CreateCounter("Adresse_59__", "1"),
                    Metrics.CreateCounter("Adresse_60__", "1"),
                    Metrics.CreateCounter("Adresse_61__", "1"),
                    Metrics.CreateCounter("Adresse_62__", "1"),
                    Metrics.CreateCounter("Adresse_63__", "1"),
                    Metrics.CreateCounter("Adresse_64__", "1"),
                    Metrics.CreateCounter("Adresse_65__", "1"),
                    Metrics.CreateCounter("Adresse_66__", "1"),
                    Metrics.CreateCounter("Adresse_67__", "1"),
                    Metrics.CreateCounter("Adresse_68__", "1"),
                    Metrics.CreateCounter("Adresse_69__", "1"),
                    Metrics.CreateCounter("Adresse_70__", "1"),
                    Metrics.CreateCounter("Adresse_71__", "1"),
                    Metrics.CreateCounter("Adresse_72__", "1"),
                    Metrics.CreateCounter("Adresse_73__", "1"),
                    Metrics.CreateCounter("Adresse_74__", "1"),
                    Metrics.CreateCounter("Adresse_75__", "1"),
                    Metrics.CreateCounter("Adresse_76__", "1"),
                    Metrics.CreateCounter("Adresse_77__", "1"),
                    Metrics.CreateCounter("Adresse_78__", "1"),
                    Metrics.CreateCounter("Adresse_79__", "1"),
                    Metrics.CreateCounter("Adresse_80__", "1"),
                    Metrics.CreateCounter("Adresse_81__", "1"),
                    Metrics.CreateCounter("Adresse_82__", "1"),
                    Metrics.CreateCounter("Adresse_83__", "1"),
                    Metrics.CreateCounter("Adresse_84__", "1"),
                    Metrics.CreateCounter("Adresse_85__", "1"),
                    Metrics.CreateCounter("Adresse_86__", "1"),
                    Metrics.CreateCounter("Adresse_87__", "1"),
                    Metrics.CreateCounter("Adresse_88__", "1"),
                    Metrics.CreateCounter("Adresse_89__", "1"),
                    Metrics.CreateCounter("Adresse_90__", "1"),
                    Metrics.CreateCounter("Adresse_91__", "1"),
                    Metrics.CreateCounter("Adresse_92__", "1"),
                    Metrics.CreateCounter("Adresse_93__", "1"),
                    Metrics.CreateCounter("Adresse_94__", "1"),
                    Metrics.CreateCounter("Adresse_95__", "1"),
                    Metrics.CreateCounter("Adresse_96__", "1"),
        };

        public static void createJsonForWorldmap()
        {
            List<Address> addresses = new List<Address>();
            List<Order> orders = new List<Order>();
            List<Target> targets = new List<Target>();
            List<Key> keys = new List<Key>();

            var hasher = new Geohasher();

            addresses = db.Addresses.ToList();
            orders = db.Orders.ToList();

            string adresse_ = "Adresse_";
            int k = 1;

            for (int i = 0; i < addresses.Count; i++)
            {
                Target target = new Target();
                target.target = addresses[i].street;
                target.datapoints = new List<string>() {orders[i].totalPriceSumInclVat.ToString(), DateTime.Now.ToString()};
                targets.Add(target);

                Key key = new Key();
                key.key = adresse_ + k.ToString();
                key.latitude = addresses[i].addressXCoordinate;
                key.longitude = addresses[i].addressYCoordinate;
                key.name = addresses[i].street;
                keys.Add(key);

                k++;

                double xcord = Double.Parse(addresses[i].addressXCoordinate, CultureInfo.InvariantCulture);
                double ycord = Double.Parse(addresses[i].addressYCoordinate, CultureInfo.InvariantCulture);
                hashCounters[i].IncTo(xcord);
                hashCounters_[i].IncTo(ycord);

                if (db.Keys.FirstOrDefault() == null)
                db.Keys.Add(key);
            }

            string jsonTarget = JsonConvert.SerializeObject(targets);
            string jsonKey = JsonConvert.SerializeObject(keys);

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
                TickTock.Inc();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

    }
}
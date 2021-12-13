using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ClosedXML.Excel;
using Heartbeat.Models;
using Newtonsoft.Json;

namespace Heartbeat.Data
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HeartbeatContext>
    {
        protected override void Seed(HeartbeatContext context)
        {

            using (StreamReader r = new StreamReader("c:/Users/oscar/Downloads/jsonOrder.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);

                List<Order> orders = new List<Order>();

                foreach (var item in items)
                {
                    Order order = new Order{ /*companyId = 0, currency = null, Customers = null, deductionPercentage = 0, Deliveries = null,*/ orderDate = item.orderDate, orderNumber = item.id, storeCode = item.storeCode, totalPriceSumInclVat = item.totalPriceSumInclVat };
                    orders.Add(order);
                }

            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();
            }


            Reader reader = new Reader();
            List<Address> addresses = new List<Address>();
            addresses = reader.read();
            addresses.ForEach(a => context.Addresses.Add(a));
            context.SaveChanges();
        }
    }

    public class Reader
    {
        string file;
        const string defaultSheet = "Ark1";
        char[] abcde = new char[] { 'a', 'b', 'c', 'd', 'e' };
        public Reader(string filename = "addressdata.xlsx")
        {
            this.file = filename;
        }

        public string form(char c, int i)
        {
            return string.Format("{0}{1}", c, i);
        }

        public List<Address> read(int rows = 97, string worksheet = defaultSheet)
        {
            string filepath = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), file);
            //var addressdata = new XLWorkbook("c:/Users/oscar/Downloads/addressdata.xlsx");
            var addressdata = new XLWorkbook(filepath);
            var addressdataSheet = addressdata.Worksheet(worksheet);

            List<Address> addressList = new List<Address>();

            for (int i = 1; i < rows; i++)
            {
                List<string> strings = new List<string>();

                foreach (char c in abcde)
                {
                    strings.Add(addressdataSheet.Cell(form(c, i)).GetValue<string>());
                }
                Address nAddress = new Address();

                nAddress.AddressID = i;
                nAddress.street = strings[0];
                nAddress.city = strings[1];
                nAddress.Country = strings[2];
                nAddress.addressXCoordinate = strings[3];
                nAddress.addressYCoordinate = strings[4];
                addressList.Add(nAddress);

                strings.Clear();
            }
            return addressList;
        }
    }
    public class Item
    {
        public string id;
        public string type;
        public string paymentType;
        public int? orderNumber;
        public int? customerNumber;
        public string customerFullName;
        public float? orderLineSubTotal;
        public float totalPriceSumInclVat;
        public string salesHandler;
        public int? salesHandlerCode;
        public int? storeCode;
        public bool? creditNote;
        public string appOrigin;
        public string orderStatus;
        public string orderProcessStatus;
        public string orderProcessMessage;
        public string note;
        public bool? isMobileOrder;
        public string orderDate;
        public string createDateTime;
        public string updateDateTime;
    }
}
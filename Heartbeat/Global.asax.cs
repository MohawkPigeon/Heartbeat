using Prometheus;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiContrib.Formatting.Jsonp;

namespace Heartbeat
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //AspNetMetricServer.RegisterRoutes(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.AddJsonpFormatter();


            //HttpClient2 httpClient2 = new HttpClient2();
            //HttpClient2.Main().Wait();

            /*
            ThreadStart childref = new ThreadStart(HttpClientHelper.Main);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            */
            ThreadStart childref2 = new ThreadStart(Program.createJsonForWorldmap);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread2 = new Thread(childref2);
            childThread2.Start();
            childThread2.Join();

            ThreadStart childref = new ThreadStart(Program.Main);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            
        }
    }
}

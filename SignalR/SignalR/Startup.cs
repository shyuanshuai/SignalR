using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(SignalR.SignalR.Startup), "Configuration")]
namespace SignalR.SignalR {

    public static class Startup {

        public static void ConfigureSignalR(IAppBuilder app) {
            app.MapSignalR();
        }

        public static void Configuration(IAppBuilder app) {
            SignalR.Startup.ConfigureSignalR(app);
        }

    }
}
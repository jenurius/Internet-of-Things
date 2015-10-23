using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonServices;
using JsonServices.Web;

namespace IOTWebsite_Final
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : JsonHandler
    {

        public Handler()
        {
            this.service.Name = "JSONWebAPI";
            this.service.Description = "JSON API for Web and Android App";
            InterfaceConfiguration iConfig = new InterfaceConfiguration("RestAPI", typeof(IServiceAPI), typeof(ServiceAPI));
            this.service.Interfaces.Add(iConfig);
        }
    }
}
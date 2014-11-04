﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ASPTraining.Models;

namespace ASPTraining
{
    public static class WebApiConfig2
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

             
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Improvement>("ImprovementsOdata");
            builder.EntitySet<Comment>("Comments"); 
            builder.EntitySet<Status>("Statuses"); 
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}

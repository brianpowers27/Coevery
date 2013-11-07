﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Coevery.Common {
    public class DefaultRoute : RouteBase {
        private readonly RouteBase _route;

        public DefaultRoute() {
            _route = new Route("{area}/{controller}/{action}/{id}", new MvcRouteHandler());
        }

        public override RouteData GetRouteData(HttpContextBase httpContext) {
            var routeData = _route.GetRouteData(httpContext);
            if (routeData == null) {
                return null;
            }
            routeData.Values["area"] = "Coevery.Common";
            routeData.DataTokens["area"] = "Coevery.Common";
            routeData.Values["controller"] = "ViewTemplate";
            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) {
            return _route.GetVirtualPath(requestContext, values);
        }
    }
}
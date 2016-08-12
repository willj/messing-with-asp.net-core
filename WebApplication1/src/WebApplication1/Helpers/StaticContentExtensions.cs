using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public static class StaticContentExtensions
    {
        private static string staticContentUrl;

        public static void SetUrl(string url)
        {
            staticContentUrl = url;
        }

        public static string StaticContent(this IUrlHelper helper, string src, string overrideProtocol = "")
        {
            if (string.IsNullOrEmpty(staticContentUrl))
            {
                return helper.Content("~/static/" + src);
            }
            else
            {
                //string protocol = ((string.IsNullOrEmpty(overrideProtocol)) ? HttpContext.Current.Request.Url.Scheme : overrideProtocol) + "://";
                string protocol = ((string.IsNullOrEmpty(overrideProtocol)) ? helper.ActionContext.HttpContext.Request.Scheme : overrideProtocol) + "://";

                if (!staticContentUrl.StartsWith(protocol))
                {
                    staticContentUrl = staticContentUrl.Replace("http://", protocol);
                    staticContentUrl = staticContentUrl.Replace("https://", protocol);
                }

                return staticContentUrl + src;
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowBoardMarket.Helpers
{
    public class RewriterHelper : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;

            if (request.Host.Value.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
            {
                HttpResponse response = context.HttpContext.Response;

                string redirectUrl = $"{request.Scheme}://{request.Host.Value.Substring(4)}{request.Path}{request.QueryString}";
                response.Headers[HeaderNames.Location] = redirectUrl;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
            }
            else
            {
                return;
            }
        }
    }
}
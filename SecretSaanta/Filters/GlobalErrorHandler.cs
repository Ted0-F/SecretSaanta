﻿using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace SecretSantaa.Filters
{
    public class GlobalErrorHandler : ExceptionFilterAttribute, IAutofacExceptionFilter
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            // Логваме, трейсваме и подобни, после скриваме грешката зад 500
            if (!(actionExecutedContext.Exception is HttpResponseException))
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError);

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Net.Http;
using Messenger.DataLayer;
using NLog;
using System.Net;
using Messenger.DataLayer.Sql;
using Messenger.Model;


namespace Messenger.Api.Filters
{
    public class ExpectedExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var exeption = context.Exception;
            switch (exeption)
            {
                case ArgumentNullException nae:
                        logger.Error(nae.ToString());
                        throw new HttpResponseException(context.Request.CreateErrorResponse(HttpStatusCode.Conflict, nae));
                        
                case ArgumentException ae:
                        logger.Error(ae.ToString());
                        throw new HttpResponseException(context.Request.CreateErrorResponse(HttpStatusCode.NotFound, ae));

                case System.Data.SqlClient.SqlException sqle:
                        logger.Error("SQL Server error: {0}",sqle.ToString());
                    throw new HttpResponseException(context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, sqle));

                default: logger.Error(exeption.ToString());
                    break; 
            }
            
        }
    }
}
using System;

using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using NLog;

using Messenger.Api.Extentions;

namespace Messenger.Api.Handlers
{
    public class LoggingHandler :DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uri = request.Method.ToString()+" "+request.RequestUri.ToString();
            var logger=  LogManager.GetCurrentClassLogger();
            logger.Trace("Обращение к {0}", uri);
            using (var exectimelogger = new ExecTimeLoger(uri))
            {// Call the inner handler.
                var response = await base.SendAsync(request, cancellationToken);

                return response;
            }
        }
    }
}
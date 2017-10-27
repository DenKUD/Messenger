using System;

using System.Diagnostics;
using NLog;

namespace Messenger.Api.Extentions
{
    public class ExecTimeLoger :IDisposable
    {
        private Stopwatch _stopwatch;
        private string _message;
        public ExecTimeLoger(string message)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _message = message;
        }

        public void Dispose()
        {
            var logger = LogManager.GetCurrentClassLogger();
            var elapsed =_stopwatch.ElapsedMilliseconds;
            logger.Debug("Вызов {0} выполнен за {1} мс", _message, elapsed);
        }
    }
}
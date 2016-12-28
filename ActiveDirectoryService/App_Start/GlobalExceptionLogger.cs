using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace ActiveDirectoryService
{
    public class GlobalExceptionLogger : ExceptionLogger
	{
		private readonly TraceSource _traceSource;

		public GlobalExceptionLogger(TraceSource traceSource)
		{
			_traceSource = traceSource;
		}

		public override void Log(ExceptionLoggerContext context)
		{
			if(context != null)
			{
				_traceSource.TraceEvent(TraceEventType.Error, 1,
					"Unhandled exception processing {0} for {1}: {2}",
					context.Request.Method,
					context.Request.RequestUri,
					context.Exception);
			}	
		}
	}
}

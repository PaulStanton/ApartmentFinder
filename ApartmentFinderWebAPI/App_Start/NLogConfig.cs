using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
namespace ApartmentFinderWebAPI
{
    public class NLogConfig
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public void TraceMethod()
        {
            int k = 23;
            int j = 88;

            logger.Trace("Test trace message - k={0} j={1}", k, j);
        }
    }
}
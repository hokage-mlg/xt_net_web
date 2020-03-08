using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Final.Logger
{
    public static class Logger
    {
        static Logger() { InitLogger(); }
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");
        public static void InitLogger() { XmlConfigurator.Configure(); }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Virpil.Communicator.PluginBase
{
    public abstract class PluginBase
    {
        /// <summary>
        /// Called when your plugin has data to send.
        /// </summary>
        public Action<string, int> SendData { get; set; } = null!;

        /// <summary>
        /// Logger factory that can be used to create loggers for your plugin.
        /// </summary>
        public ILoggerFactory LoggerFactory { get; set; } = null!;

        /// <summary>
        /// Starts the thread used by the plugin to process and send data. Returns true if start was successful, false
        /// if otherwise.
        /// </summary>
        /// <returns>success of start</returns>
        public abstract Task<bool> Start();
    }
}
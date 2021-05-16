using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ViLA.PluginBase
{
    public abstract class PluginBase
    {
        /// <summary>
        /// Called when your plugin has integer data to send.
        /// </summary>
        public Action<string, int> SendData { get; set; } = null!;

        /// <summary>
        /// Called when your plugin has string data to send.
        /// </summary>
        public Action<string, string> SendString { get; set; } = null!;

        /// <summary>
        /// Called when your plugin has float data to send.
        /// </summary>
        public Action<string, float> SendFloat { get; set; } = null!;

        /// <summary>
        /// Called when your plugin has boolean data to send.
        /// </summary>
        public Action<string, bool> SendBool { get; set; } = null!;

        /// <summary>
        /// Called when your plugin has a trigger to send.
        /// </summary>
        public Action<string> SendTrigger { get; set; } = null!;

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
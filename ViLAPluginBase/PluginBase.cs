using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ViLA.PluginBase;

public abstract class PluginBase
{
    /// <summary>
    /// Called when your plugin has any data to send.
    /// </summary>
    public Action<string, dynamic> Send { get; set; } = null!;

    /// <summary>
    /// Called when your plugin has a trigger to send (an action with no data).
    /// </summary>
    public Action<string> SendTrigger { get; set; } = null!;

    /// <summary>
    /// Called when your plugin wants to clear the existing state cache and start fresh.
    /// </summary>
    public Action ClearState { get; set; } = null!;

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

    /// <summary>
    /// Stops the active thread and cleans up any unmanaged resources, if necessary. Stopping a plugin does not mean
    /// it needs to be able to be started again.
    /// </summary>
    public abstract Task Stop();
}

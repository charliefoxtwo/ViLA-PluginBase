
# ViLA Plugin Base

[![Nuget](https://img.shields.io/nuget/v/ViLA.PluginBase?style=flat-square)](https://www.nuget.org/packages/ViLA.PluginBase)
[![.NET 5 CI build](https://github.com/charliefoxtwo/ViLA-PluginBase/actions/workflows/ci-build.yml/badge.svg?branch=develop)](https://github.com/charliefoxtwo/ViLA-PluginBase/actions/workflows/ci-build.yml)
[![GitHub](https://img.shields.io/github/license/charliefoxtwo/ViLA-PluginBase?style=flat-square)](LICENSE)
[![Discord](https://img.shields.io/discord/840762843917582347?style=flat-square)](https://discord.gg/rWAF3AdsKT)

This contains a single abstract class `PluginBase` to be used by any virpil communicator plugins.

<img src="https://raw.githubusercontent.com/charliefoxtwo/ViLA-PluginBase/main/ViLAPluginBase/resources/rounded-plug.png" alt="ViLA Plugin Base logo - a vector outline of a plug, with the cord wound around it like an @ symbol" width="150" />

## Usage/Examples

```c#
// custom inheriting class with *parameterless constructor*
public class MyPlugin : PluginBase
{
    // you can define your own parameterless constructor if you want, but
    // you won't be able to send data and LoggerFactory won't be defined

    public override async Task<bool> Start()
    {
        // probably not something you want to do in practice, but
        // shows you should run your task on a different thread
        return ThreadPool.QueueUserWorkItem(_ =>
        {
            var i = 0;
            while (true)
            {
                // it's important to call PluginBase.Send with your data
                Send("id", i++);
                Thread.Sleep(1000);
            }
        });
    }
}
```
Note that `QueueUserWorkItem()` returns as soon as the task is created, and the task continues running on a different thread.


## Installation

You can find this package on NuGet. When installing, it is important to add the following to your .csproj file:
```
<PackageReference Include="ViLA.PluginBase" Version="<version>">
    <ExcludeAssets>runtime</ExcludeAssets>
</PackageReference>
```

This will prevent any dependency confusion between your plugin, any other plugins, and the application - all of which depend on this package and may be using slightly different versions.

## Used By

Some example plugins include:

- [DCS Bios Reader](https://github.com/charliefoxtwo/ViLA-DCS-BIOS-Reader)


## Acknowledgements

- [Package icon](https://www.freepik.com)
- [readme tools](https://readme.so)
- [badges](https://shields.io)

# Nuclei.Fusion


## FusionHelper

The `FusionHelper` class provides an `ILogger` implementation that can send the log messages to multiple sub-loggers. The
level at which the `DistributedLogger` starts logging is determined by the sub-loggers, a message will be logged if there is a
`ILogger` implementation that will take the message. This allows for instance having a file logger that logs all messages while
having an eventlog logger which only logs the fatal messages.

[!code-csharp[FusionHelper.LocateAssemblyOnAssemblyLoadFailure](..\..\Nuclei.Fusion.Samples\FusionHelperSample.cs?range=29-44)]

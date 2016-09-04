# Nuclei.Fusion


## FusionHelper

The `FusionHelper` class provides members that can be called when the runtime fails to load an assembly, thus allowing the automatic loading of assemblies
which are not on the standard assembly probing paths.

[!code-csharp[FusionHelper.LocateAssemblyOnAssemblyLoadFailure](..\..\Nuclei.Fusion.Samples\FusionHelperSample.cs?range=29-44)]

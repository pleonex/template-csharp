using Cake.Core;
using Cake.Frosting;
using Cake.Frosting.PleOps.Recipe;
using Cake.Frosting.PleOps.Recipe.Dotnet;

return new CakeHost()
    .AddAssembly(typeof(Cake.Frosting.PleOps.Recipe.PleOpsBuildContext).Assembly)
    .UseContext<PleOpsBuildContext>()
    .UseLifetime<BuildLifetime>()
    .Run(args);

public sealed class BuildLifetime : FrostingLifetime<PleOpsBuildContext>
{
    public override void Setup(PleOpsBuildContext context, ISetupContext info)
    {
        // HERE you can set default values overridable by command-line
        // TODO EXAMPLE: context.WarningsAsErrors = false;
        context.DotNetContext.ApplicationProjects.Add(new ProjectPublicationInfo(
            "./src/MyConsole", new[] { "win-x64", "linux-x64", "osx-x64" }, "net8.0"));

        // Update build parameters from command line arguments.
        context.ReadArguments();

        // HERE you can force values non-overridable.
        context.DotNetContext.PreviewNuGetFeed = "https://pkgs.dev.azure.com/benito356/NetDevOpsTest/_packaging/Example-Preview/nuget/v3/index.json";
        context.DotNetContext.StableNuGetFeed = "https://pkgs.dev.azure.com/benito356/NetDevOpsTest/_packaging/Example-Preview/nuget/v3/index.json";

        // Print the build info to use.
        context.Print();
    }

    public override void Teardown(PleOpsBuildContext context, ITeardownContext info)
    {
        // Save the info from the existing artifacts for the next execution (e.g. deploy job)
        context.DeliveriesContext.Save();
    }
}

[TaskName("Default")]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Common.SetGitVersionTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Dotnet.BuildTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Dotnet.TestTask))]
public sealed class DefaultTask : FrostingTask
{
}

[TaskName("CI-Build")]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Common.SetGitVersionTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Common.CleanArtifactsTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.GitHub.ExportReleaseNotesTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Dotnet.DotnetTasks.PrepareProjectBundlesTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.DocFx.DocFxTasks.PrepareProjectBundlesTask))]
public sealed class CIBuildTask : FrostingTask
{
}

[TaskName("CI-Deploy")]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Common.SetGitVersionTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.Dotnet.DotnetTasks.DeployProjectTask))]
[IsDependentOn(typeof(Cake.Frosting.PleOps.Recipe.GitHub.UploadReleaseBinariesTask))]
public sealed class CIDeployTask : FrostingTask
{
}

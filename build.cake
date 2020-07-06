// #load "./../src/PleOps.Cake/targets.cake" // Debug
#load "nuget:?package=PleOps.Cake&prerelease"

Task("Define-Project")
    .Description("Fill specific project information")
    .Does<BuildInfo>(info =>
{
    info.AddLibraryProjects("MyLibrary");
    info.AddApplicationProjects("MyConsole");
    info.AddTestProjects("MyTests");
});

Task("Default")
    .IsDependentOn("Create-Artifacts");

string target = Argument("target", "Default");
RunTarget(target);

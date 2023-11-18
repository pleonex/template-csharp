# .NET project template [![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](https://choosealicense.com/licenses/mit/) ![Build and release](https://github.com/pleonex/template-csharp/workflows/Build%20and%20release/badge.svg)

This is a template repository for .NET projects. It uses the build system and
DevOps workflow of [PleOps.Cake](https://github.com/pleonex/PleOps.Cake).

Tech stack:

- Projects: C# / .NET
- Documentation: DocFX, GitHub page
- CI: GitHub Actions
- Release publication: NuGet feeds, GitHub

<!-- prettier-ignore -->
| Release | Package                                                           |
| ------- | ----------------------------------------------------------------- |
| Stable  | [![Azure Artifacts](https://feeds.dev.azure.com/benito356/339c91a8-9d6c-4082-8b1a-93c2ae76b637/_apis/public/Packaging/Feeds/e3acf8ba-ec70-46f0-b1a5-da1ce3dd5d9f/Packages/b8696a32-e71a-4479-9b0e-002997b8d8ef/Badge)](https://dev.azure.com/benito356/NetDevOpsTest/_packaging?_a=package&feed=e3acf8ba-ec70-46f0-b1a5-da1ce3dd5d9f&package=b8696a32-e71a-4479-9b0e-002997b8d8ef&preferRelease=true) |
| Preview | [Azure Artifacts](https://dev.azure.com/benito356/NetDevOpsTest/_artifacts/feed/Example-Preview) |

## Setup

Follow the
[getting started guide from PleOps.Cake](https://www.pleonex.dev/PleOps.Cake/docs/getting-started/tutorial.html)
to adapt this template to your project.

## Documentation

Feel free to ask any question in the
[project Discussion site!](https://github.com/pleonex/template-csharp/discussions)

Check the [documentation](https://www.pleonex.dev/PleOps.Cake/) for more
information.

## Build

The project requires to build .NET 8.0 SDK.

To build, test and generate artifacts run:

```sh
# Build and run tests
dotnet run --project build/orchestrator

# (Optional) Create bundles (nuget, zips, docs)
dotnet run --project build/orchestrator -- --target=Bundle
```

## Release

Create a new GitHub release with a tag `v{Version}` (e.g. `v2.4`) and that's it!
This triggers a pipeline that builds and deploy the project.

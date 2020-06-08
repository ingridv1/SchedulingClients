# Release Procedure

Needs better automation, but currently (in **DEVEL** branch)

## Update the release notes

Update the markdown file: ```docfx_project\articles\releaseNotes.md```

## Build

Build the solution in release mode. This will automatically re-build the docfx documentation and push the output to the docs folder.

## Update nuspec

Edit ```SchedulingClients.nuspec``` with the required SemVer.

## Build the nuget package

```nuget pack SchedulingClients.nuspec```

## Push branch changes

Commit and push branch changes.

## Pull

Create a pull request to merge **DEVEL** into **MASTER**. This will ensure that the github documentation is looking at the newly created docfx output.

## Release on nuget

Upload the package to nuget.org

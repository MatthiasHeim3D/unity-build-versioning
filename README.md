# Unity Build Versioning

Manage build version numbers in your Unity projects. The tool automatically increments the build number each time you build your project, and allows you to easily retrieve the current version number.

The version format is based on [SemVer](https://semver.org/): major.minor.patch+build number

On each build, the player version setting is automatically updated with the incremented build number.

## Getting Started

To use this package in your Unity project, follow these steps:

1. [Add the package](https://docs.unity3d.com/Manual/upm-ui-giturl.html) to your Unity project.
2. Create a new BuildInfo asset by right-clicking in the Project window and selecting Create > Scriptable Objects > BuildInfo. This asset stores your build version information.
3. Fill in the fields in the BuildInfo asset. You can set the initial version number, and choose whether to create a version txt file next to your executable and append the build type (dev / release) to the version number.
4. Build your project. The build number will automatically increment, and optionally a version text file will be created next to your executable.

## Description

The package hooks into [OnPreprocessBuild](https://docs.unity3d.com/ScriptReference/Build.IPreprocessBuildWithReport.OnPreprocessBuild.html) and [OnPostprocessBuild](https://docs.unity3d.com/ScriptReference/Build.IPostprocessBuildWithReport.OnPostprocessBuild.html) 

The relevant methods are called from Editor/Scripts/SetBuildVersion.cs

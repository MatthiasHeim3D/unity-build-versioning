using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Build Info")]
public class BuildInfo : ScriptableObject
{
    public int MajorVersion;
    public int MinorVersion;
    public int PatchVersion;
    public int BuildNumber;
    public bool CreateVersionTxtFileNextToExecutable = true;

    public string GetVersionString()
    {
        return $"{MajorVersion}.{MinorVersion}.{PatchVersion}+{BuildNumber}";
    }

    public void IncrementBuildNumber()
    {
        BuildNumber++;
    }
}

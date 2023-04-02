using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using UnityEngine;

public class SetBuildVersion : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        if (GetBuildInfo(out BuildInfo buildInfo))
        {
            buildInfo.IncrementBuildNumber();

            PlayerSettings.bundleVersion = buildInfo.GetVersionString();

            EditorUtility.SetDirty(buildInfo);
            AssetDatabase.SaveAssets();

            Debug.Log($"Build Version: {buildInfo.GetVersionString()}");
        }
        else
        {
            Debug.Log("No BuildInfo Asset found.");
        }
    }

    [PostProcessBuild(1)]
    public static void OnPostProcessBuild(BuildTarget target, string pathToExecutable)
    {
        if (GetBuildInfo(out BuildInfo buildInfo))
        {
            if (buildInfo.CreateVersionTxtFileNextToExecutable)
            {
                RemovePreviousVersionTxt(pathToExecutable);
                CreateCurrentVersionTxt(pathToExecutable, target);
            }
        }
    }

    private static void RemovePreviousVersionTxt(string pathToExecutable)
    {
        string directory = Path.GetDirectoryName(pathToExecutable);
        var versionFile = Directory.GetFiles(directory, "version_*.*.*+*.txt");

        if (versionFile.Length > 0)
        {
            File.Delete(versionFile[0]);
        }
    }

    private static void CreateCurrentVersionTxt(string pathToExecutable, BuildTarget target)
    {
        if (GetBuildInfo(out BuildInfo buildInfo))
        {
            string directory = Path.GetDirectoryName(pathToExecutable);
            string debugOrRelease = string.Empty;
            
            if(buildInfo.AppendDevelopmentOrReleaseToVersion)
                debugOrRelease = EditorUserBuildSettings.development ? "_development" : "_release";

            string currentVersionTxtPath = Path.Combine(directory, $"version_{buildInfo.GetVersionString()}{debugOrRelease}.txt");

            File.Create(currentVersionTxtPath).Close();
        }
    }

    static bool GetBuildInfo(out BuildInfo buildInfo)
    {
        string[] buildInfoPath = AssetDatabase.FindAssets("t:BuildInfo", null);

        if (buildInfoPath.Length > 0)
        {
            buildInfo = AssetDatabase.LoadAssetAtPath<BuildInfo>(AssetDatabase.GUIDToAssetPath(buildInfoPath[0]));
            return true;
        }

        buildInfo = null;
        return false;
    }
}

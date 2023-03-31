using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SetBuildVersion : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        PreprocessBuild();
    }

    static void PreprocessBuild()
    {
        if (GetBuildInfo(out BuildInfo buildInfo))
        {
            buildInfo.IncrementBuildNumber();

            PlayerSettings.bundleVersion = buildInfo.GetVersion();

            EditorUtility.SetDirty(buildInfo);
            AssetDatabase.SaveAssets();
        }
        else
        {
            Debug.LogWarning("No BuildInfo Asset found.");
        }
    }

    static bool GetBuildInfo(out BuildInfo buildInfo)
    {
        Debug.Log("Searching BuildInfo");

        string[] buildInfoPath = AssetDatabase.FindAssets("t:BuildInfo", null);

        if (buildInfoPath.Length > 0)
        {
            buildInfo = AssetDatabase.LoadAssetAtPath<BuildInfo>(AssetDatabase.GUIDToAssetPath(buildInfoPath[0]));
            return true;
        }

        buildInfo = null;
        return false;
    }

    [PostProcessBuild(1)]
    public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (GetBuildInfo(out BuildInfo buildInfo))
        {
            // TODO: Remove previous exe if there is one, as it is now not overwritten
            if (buildInfo.AppendVersionToExecutableFileName)
            {
                string directory = Path.GetDirectoryName(pathToBuiltProject);
                string executableName = Path.GetFileNameWithoutExtension(pathToBuiltProject);
                string extension = Path.GetExtension(pathToBuiltProject);
                string executableWithBuildNumber = $"{executableName}_{buildInfo.GetVersion()}{extension}";

                File.Move(pathToBuiltProject, Path.Combine(directory, executableWithBuildNumber));
            }
        }
        else
        {
            Debug.LogWarning("No BuildInfo Asset found.");
        }
    }
}

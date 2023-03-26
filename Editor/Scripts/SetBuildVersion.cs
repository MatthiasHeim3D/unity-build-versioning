using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class SetBuildVersion : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        PreprocessBuild();
    }

    static void PreprocessBuild()
    {
        Debug.Log("Searching BuildInfo");

        string[] buildInfoPath = AssetDatabase.FindAssets("t:BuildInfo", null);

        if(buildInfoPath.Length > 0)
        {
            BuildInfo buildInfo = AssetDatabase.LoadAssetAtPath<BuildInfo>(AssetDatabase.GUIDToAssetPath(buildInfoPath[0]));

            Debug.Log($"BuildInfo found at{buildInfoPath[0]}");

            Debug.Log($"BuildInfo number {buildInfo.BuildNumber}");

            buildInfo.IncrementBuildNumber();

            UnityEditor.PlayerSettings.bundleVersion = buildInfo.GetVersion();
            //PlayerSettings.SetPropertyString("bundleVersion", buildInfo.GetVersion());

            EditorUtility.SetDirty(buildInfo);
            AssetDatabase.SaveAssets();
        }
        else
        {
            Debug.LogWarning("No BuildInfo Asset found.");
        }
    }
}

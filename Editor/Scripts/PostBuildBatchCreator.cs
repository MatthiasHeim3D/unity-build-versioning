using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PostBuildBatchCreator : IPostprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPostprocessBuild(BuildReport report)
    {
        if (report.summary.platform == BuildTarget.StandaloneWindows || report.summary.platform == BuildTarget.StandaloneWindows64)
        {
            DeleteExistingBatFiles(Path.GetDirectoryName(report.summary.outputPath));

            if (GetBatchCommandLineArguments(out BatchCommandLineArguments batchCommandLineArguments))
            {
                string exeName = Path.GetFileName(report.summary.outputPath);
                

                foreach (var argument in batchCommandLineArguments.Arguments)
                {
                    string batFileName = $"{Path.GetFileNameWithoutExtension(exeName)}_{argument.Option}.bat";
                    string batFilePath = Path.Combine(Path.GetDirectoryName(report.summary.outputPath), batFileName);
                    string arguments = $"{argument.Option} {argument.Value}";

                    CreateBatchFile(exeName, batFilePath, arguments);

                    Debug.Log($"Created batch file with arguments \"{arguments}\" at: <i>{batFilePath}</i>");
                }
            }
        }
    }

    static void DeleteExistingBatFiles(string directoryPath)
    {
        string[] batFiles = Directory.GetFiles(directoryPath, "*.bat");

        foreach (string batFile in batFiles)
        {
            File.Delete(batFile);
        }
    }

    static void CreateBatchFile(string exeName, string batFilePath, string arguments)
    {
        //The double quotes after start (\"\") are to ensure that if your exeName or arguments have spaces, they're treated correctly. This is a peculiarity of the start command where the first set of quotes is treated as the title for the new command window (which won't be created in this case because you're launching an exe, but it's good to know).
        string content = $"@echo off\r\nstart \"\" \"{exeName}\" {arguments}\r\nexit";

        File.WriteAllText(batFilePath, content);
    }

    static bool GetBatchCommandLineArguments(out BatchCommandLineArguments batchCommandLineArguments)
    {
        string[] batchCommandLineArgumentsPath = AssetDatabase.FindAssets("t:BatchCommandLineArguments", null);

        if (batchCommandLineArgumentsPath.Length > 0)
        {
            batchCommandLineArguments = AssetDatabase.LoadAssetAtPath<BatchCommandLineArguments>(AssetDatabase.GUIDToAssetPath(batchCommandLineArgumentsPath[0]));

            if (batchCommandLineArgumentsPath.Length > 1)
                Debug.Log("Multiple BatchCommandLineArguments assets found, using first found.");

            return true;
        }

        batchCommandLineArguments = null;
        return false;
    }
}
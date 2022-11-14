using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel.Design;
//using System.IO.Compression;
//using Ionic.Zip;



// place in an "Editor" folder in your Assets folder
public class AutomateBuild
{
    private static string windowsBuildFolderPath = "D:/Jenkins/Tower Defense 3D/Builds/";

    public static void StartBuild()
    {

        //LevelBuildPrep.GenerateOptimizedScenesForEnabledScenesInBuildSettings();

        #region WINDOWS BUILD

        List<string> enabledScenePathNames = new List<string>();

        // Get list of enabled scenes
        foreach (var buildSceneSettingsScene in EditorBuildSettings.scenes)
        {
            if(buildSceneSettingsScene.enabled)
            {
                enabledScenePathNames.Add(buildSceneSettingsScene.path);
            }
        }

        // Location path to be send the build to
        string ExecutableDirectoryPath = windowsBuildFolderPath + "TowerDefense3D_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "/";

        //Create Dirextory

        if(!Directory.Exists(ExecutableDirectoryPath))
        {
            Directory.CreateDirectory(ExecutableDirectoryPath);
        }

        string windowsExecutableName = "TowerDefense3D_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".exe";


        UnityEngine.Debug.Log("****************** Starting to Make the Windows Build *****************************");
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

        buildPlayerOptions.scenes = enabledScenePathNames.ToArray();
        buildPlayerOptions.locationPathName = ExecutableDirectoryPath + windowsExecutableName;
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);


        #endregion
    }

}

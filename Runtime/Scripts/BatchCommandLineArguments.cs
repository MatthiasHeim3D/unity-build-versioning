using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CommandLineArgument
{
    public string Option;
    public string Value;
}

/// <summary>
/// Implements the command line arguments for Unity's batch mode.
/// See <see href="https://docs.unity3d.com/Manual/PlayerCommandLineArguments.html">(Documentation)</see>
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Objects/Batch Command Line Arguments")]
public class BatchCommandLineArguments : ScriptableObject
{
    public List<CommandLineArgument> Arguments = new List<CommandLineArgument>();

    [ContextMenu("Batchmode")]
    public void Batchmode()
    {
        Arguments.Add(new CommandLineArgument { Option = "-batchmode", Value = string.Empty });
    }

    [ContextMenu("DisableGPUSkinning")]
    public void DisableGPUSkinning()
    {
        Arguments.Add(new CommandLineArgument { Option = "-disable-gpu-skinning", Value = string.Empty });
    }

    [ContextMenu("ForceClamped")]
    public void ForceClamped()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-clamped", Value = string.Empty });
    }

    [ContextMenu("ForceD3D11SingleThreaded")]
    public void ForceD3D11SingleThreaded()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-d3d11-singlethreaded", Value = string.Empty });
    }

    [ContextMenu("ForceDeviceIndex")]
    public void ForceDeviceIndex()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-device-index", Value = 0.ToString() });
    }

    [ContextMenu("ForceGfxDirect")]
    public void ForceGfxDirect()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-gfx-direct", Value = string.Empty });
    }

    [ContextMenu("ForceGlcore")]
    public void ForceGlcore()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-glcore", Value = string.Empty });
    }

    [ContextMenu("ForceGlcoreXY")]
    public void ForceGlcoreXY()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-glcoreXY", Value = 32.ToString() });
    }

    [ContextMenu("ForceVulkan")]
    public void ForceVulkan()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-vulkan", Value = string.Empty });
    }

    [ContextMenu("MaxAsyncPsoJobCount")]
    public void MaxAsyncPsoJobCount()
    {
        Arguments.Add(new CommandLineArgument { Option = "-max-async-pso-job-count", Value = 1.ToString() });
    }

    [ContextMenu("Monitor")]
    public void Monitor()
    {
        Arguments.Add(new CommandLineArgument { Option = "-monitor", Value = 0.ToString() });
    }

    [ContextMenu("NoGraphics")]
    public void NoGraphics()
    {
        Arguments.Add(new CommandLineArgument { Option = "-nographics", Value = string.Empty });
    }

    [ContextMenu("NoLog")]
    public void NoLog()
    {
        Arguments.Add(new CommandLineArgument { Option = "-nolog", Value = string.Empty });
    }

    [ContextMenu("NoSteroRendering")]
    public void NoSteroRendering()
    {
        Arguments.Add(new CommandLineArgument { Option = "-no-stereo-rendering", Value = string.Empty });
    }

    [ContextMenu("PopupWindow")]
    public void PopupWindow()
    {
        Arguments.Add(new CommandLineArgument { Option = "-popupwindow", Value = string.Empty });
    }

    [ContextMenu("ScreenFullscreen")]
    public void ScreenFullscreen()
    {
        Arguments.Add(new CommandLineArgument { Option = "-screen-fullscreen", Value = 1.ToString() });
    }

    [ContextMenu("ScreenHeight")]
    public void ScreenHeight()
    {
        Arguments.Add(new CommandLineArgument { Option = "-screen-height", Value = 1080.ToString() });
    }

    [ContextMenu("ScreenWidth")]
    public void ScreenWidth()
    {
        Arguments.Add(new CommandLineArgument { Option = "-screen-width", Value = 1920.ToString() });
    }

    [ContextMenu("ScreenQuality")]
    public void ScreenQuality()
    {
        Arguments.Add(new CommandLineArgument { Option = "-screen-quality", Value = "Beautiful" });
    }

    [ContextMenu("DontConnectAcceleratorEvent")]
    public void DontConnectAcceleratorEvent()
    {
        Arguments.Add(new CommandLineArgument { Option = "-dontConnectAcceleratorEvent", Value = string.Empty });
    }

    [ContextMenu("ForceD3D11")]
    public void ForceD3D11()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-d3d11", Value = string.Empty });
    }

    [ContextMenu("ForceD3D12")]
    public void ForceD3D12()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-d3d12", Value = string.Empty });
    }

    [ContextMenu("ForceD3D11BitBltModel")]
    public void ForceD3D11BitBltModel()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-d3d11-bitblt-model", Value = string.Empty });
    }

    [ContextMenu("ForceD3D11FlipModel")]
    public void ForceD3D11FlipModel()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-d3d11-flip-model", Value = string.Empty });
    }

    [ContextMenu("ForceD3D11NoSingleThreaded")]
    public void ForceD3D11NoSingleThreaded()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-d3d11-no-singlethreaded", Value = string.Empty });
    }

    [ContextMenu("ForceDriverTypeWarp")]
    public void ForceDriverTypeWarp()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-driver-type-warp", Value = string.Empty });
    }

    [ContextMenu("ForceFeatureLevel_10_0")]
    public void ForceFeatureLevel_10_0()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-feature-level-10-0", Value = string.Empty });
    }

    [ContextMenu("ForceFeatureLevel_10_1")]
    public void ForceFeatureLevel_10_1()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-feature-level-10-1", Value = string.Empty });
    }

    [ContextMenu("ForceFeatureLevel_11_0")]
    public void ForceFeatureLevel_11_0()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-feature-level-11-0", Value = string.Empty });
    }

    [ContextMenu("ForceLowPowerDevice")]
    public void ForceLowPowerDevice()
    {
        Arguments.Add(new CommandLineArgument { Option = "-force-low-power-device", Value = string.Empty });
    }

    [ContextMenu("ForceTextBoxBasedKeyboard")]
    public void ForceTextBoxBasedKeyboard()
    {
        Arguments.Add(new CommandLineArgument { Option = "-forceTextBoxBasedKeyboard", Value = string.Empty });
    }

    [ContextMenu("ParentHWND")]
    public void ParentHWND()
    {
        Arguments.Add(new CommandLineArgument { Option = "--parentHWND", Value = string.Empty });
    }

    [ContextMenu("SingleInstance")]
    public void SingleInstance()
    {
        Arguments.Add(new CommandLineArgument { Option = "-single-instance", Value = string.Empty });
    }

    [ContextMenu("WindowMode")]
    public void WindowMode()
    {
        Arguments.Add(new CommandLineArgument { Option = "-window-mode", Value = "exclusive" });
    }
}

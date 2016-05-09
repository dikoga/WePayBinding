using System;
using ObjCRuntime;

[assembly: LinkWith ("libMPOSCommunicationManager.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, SmartLink = false, ForceLoad = true)]

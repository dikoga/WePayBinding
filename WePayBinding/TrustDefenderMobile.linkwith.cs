using ObjCRuntime;

[assembly: LinkWith ("TrustDefenderMobile.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, SmartLink = false, ForceLoad = true)]

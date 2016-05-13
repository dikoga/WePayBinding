using ObjCRuntime;

[assembly: LinkWith ("G4XSwiper.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]

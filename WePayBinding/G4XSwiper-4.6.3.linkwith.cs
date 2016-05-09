using System;
using ObjCRuntime;

[assembly: LinkWith ("G4XSwiper-4.6.3.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64, SmartLink = false, ForceLoad = true)]

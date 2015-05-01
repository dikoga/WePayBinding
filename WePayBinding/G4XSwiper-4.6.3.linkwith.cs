using System;
using ObjCRuntime;

[assembly: LinkWith ("G4XSwiper-4.6.3.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, SmartLink = true, ForceLoad = true)]

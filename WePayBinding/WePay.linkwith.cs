using System;
using ObjCRuntime;

[assembly: LinkWith ("WePay.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, Frameworks = "AudioToolbox CoreBluetooth CoreTelephony MediaPlayer SystemConfiguration", LinkerFlags = "-lstdc++ -lz")]

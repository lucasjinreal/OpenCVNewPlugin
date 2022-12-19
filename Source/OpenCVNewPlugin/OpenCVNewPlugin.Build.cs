// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class OpenCVNewPlugin : ModuleRules
{

	private string ThirdPartyPath => Path.GetFullPath(Path.Combine(ModuleDirectory, "../ThirdParty"));

	public OpenCVNewPlugin(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				"Projects"
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add private dependencies that you statically link with here ...	
			}
			);
		

		// Add third-party include && lib path
		var opencvRelativePath = ThirdPartyPath + "/opencv4.6.0/";
		// var archSuffix = Target.Platform == UnrealTargetPlatform.Win64 ? "x64" : "x86";
		var platformSuffix = Target.Platform.ToString(); // Win64, Mac, IOS, Android
		var opencvLibPath = Path.Combine(opencvRelativePath, "lib", platformSuffix);
		
		PublicIncludePaths.Add(Path.Combine(opencvRelativePath, "include/opencv4"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "libopencv_core.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "libopencv_video.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "libopencv_videoio.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "libopencv_imgcodecs.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "libopencv_imgproc.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "libopencv_highgui.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/liblibjpeg-turbo.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/liblibpng.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/liblibtiff.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/liblibwebp.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/liblibopenjp2.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/libittnotify.a"));
		PublicAdditionalLibraries.Add(Path.Combine(opencvLibPath, "opencv4/3rdparty/libade.a"));
		
		// frameworks for Mac
		if (Target.Platform == UnrealTargetPlatform.Mac)
		{
			PublicAdditionalFrameworks.Add(new Framework("OpenCL", "/System/Library/Frameworks/OpenCL.framework", ""));
		}
	}
}

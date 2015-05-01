// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WePayBindingTest
{
	[Register ("WePayBindingTestViewController")]
	partial class WePayBindingTestViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton InformationButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView StatusText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TokenizeButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TokenizeManualButton { get; set; }

		[Action ("InformationButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void InformationButton_TouchUpInside (UIButton sender);

		[Action ("TokenizeButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void TokenizeButton_TouchUpInside (UIButton sender);

		[Action ("TokenizeManualButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void TokenizeManualButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (InformationButton != null) {
				InformationButton.Dispose ();
				InformationButton = null;
			}
			if (StatusText != null) {
				StatusText.Dispose ();
				StatusText = null;
			}
			if (TokenizeButton != null) {
				TokenizeButton.Dispose ();
				TokenizeButton = null;
			}
			if (TokenizeManualButton != null) {
				TokenizeManualButton.Dispose ();
				TokenizeManualButton = null;
			}
		}
	}
}

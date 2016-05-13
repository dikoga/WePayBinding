using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin;

namespace WePayBindingTest
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			Insights.Initialize ("9b788dbd140e44c0d3ae231e9bd93e82a9515c1a");

			Insights.HasPendingCrashReport += (sender, isStartupCrash) => {
				if (isStartupCrash) {
					Insights.PurgePendingCrashReports ().Wait ();
				}
			};


			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			try {
				UIApplication.Main (args, null, "AppDelegate");
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);				
			}
		}

		static void CurrentDomain_UnhandledException (object sender, UnhandledExceptionEventArgs ex)
		{
			Console.WriteLine (ex);	
		}
	}
}

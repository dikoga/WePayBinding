using System;
using Foundation;

namespace WePayBinding
{
	public static class WePayEnviroment
	{
		public static string Stage { get { return "stage"; } }

		public static string Production { get { return "production"; } }
	}

	public static class WePayPaymentMethod
	{
		public static string WPPaymentMethodApplePay = "Apple Pay";
		public static string WPPaymentMethodGoogleInstantBuy = "Google Instant Buy";
		public static string WPPaymentMethodSwiper = "Swiper";
		public static string WPPaymentMethodManual = "Manual";
	}

	public static class WePaySwiperStatus
	{
		public static string WPSwiperStatusNotConnected = "swiper not connected";
		public static string WPSwiperStatusConnected = "swiper connected";
		public static string WPSwiperStatusWaitingForSwipe = "waiting for swipe";
		public static string WPSwiperStatusTokenizing = "tokenizing";
		public static string WPSwiperStatusStopped = "stopped";
	}

	//
	//	[Static]
	//	interface WePayBillingAddressKeys
	//	{
	//		[Field ("zip")]
	//		NSString ZipKey{ get; set; }
	//
	//		[Field ("country")]
	//		NSString CountryKey{ get; set; }
	//	}
	//

	//
	//	[StrongDictionary ("WePayBillingAddressKeys")]
	//	interface WePayBillingAddress
	//	{
	//		string Zip{ get; set; }
	//
	//		string Country{ get; set; }
	//	}
}


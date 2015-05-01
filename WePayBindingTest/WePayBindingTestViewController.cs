using System;
using System.Drawing;

using Foundation;
using UIKit;
using WePayBinding;

namespace WePayBindingTest
{
	public partial class WePayBindingTestViewController : UIViewController
	{
		private static WePay wePay;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public WePayBindingTestViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var config = new WPConfig ("171482", WePayEnviroment.Stage);
			wePay = new WePay (config);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		public void UpdateStatus (string delegateName, string methodName, string msg)
		{
			InvokeOnMainThread (() => {
				StatusText.Text += Environment.NewLine;
				StatusText.Text += "------- begin " + delegateName + "." + methodName + " -------";
				StatusText.Text += Environment.NewLine;
				StatusText.Text += msg;
				StatusText.Text += Environment.NewLine;
				StatusText.Text += "------- end " + delegateName + "." + methodName + " -------";
				StatusText.Text += Environment.NewLine;
				StatusText.ScrollRangeToVisible (new NSRange (StatusText.Text.Length - 1, 1));
			});
		}


		partial void InformationButton_TouchUpInside (UIButton sender)
		{
			wePay.StartSwiperForReadingWithSwiperDelegate (new SwiperDelegate (UpdateStatus));
		}

		partial void TokenizeButton_TouchUpInside (UIButton sender)
		{
			wePay.StartSwiperForTokenizingWithSwiperDelegate (new SwiperDelegate (UpdateStatus), new TokenizationDelegate (UpdateStatus));
		}

		partial void TokenizeManualButton_TouchUpInside (UIButton sender)
		{
//			NSDictionary cardInfo = @{
//				@"firstName": @"WPiOS",
//				@"lastName": @"Example",
//				@"email": @"wp.ios.example@wepay.com",
//				@"billing_address": @{@"zip":@"94306", @"country":@"US"},
//				@"cc_number": @"5496198584584769",
//				@"cvv": @"123",
//				@"expiration_month": @"04",
//				@"expiration_year": @"2015",
//				@"virtualTerminal":@(YES)
//			};

			var cardInfo = new NSMutableDictionary ();
			cardInfo.Add (new NSString ("firstName"), new NSString ("WPiOS"));
			cardInfo.Add (new NSString ("lastName"), new NSString ("Example"));
			cardInfo.Add (new NSString ("email"), new NSString ("wp.ios.example@wepay.com"));
			var billingAddress = new NSMutableDictionary ();
			billingAddress.Add (new NSString ("zip"), new NSString ("94306"));
			billingAddress.Add (new NSString ("country"), new NSString ("US"));


			//cardInfo.SetValueForKey (billingAddress, new NSString ("billing_address"));
			cardInfo.Add (new NSString ("billing_address"), billingAddress);
			cardInfo.Add (new NSString ("cc_number"), new NSString ("5496198584584769"));
			cardInfo.Add (new NSString ("expiration_month"), new NSString ("04"));
			cardInfo.Add (new NSString ("expiration_year"), new NSString ("2015"));
			cardInfo.Add (new NSString ("virtualTerminal"), new NSString ("YES"));

			Console.WriteLine (cardInfo);
//			var keys = new NSObject[] {
//				new NSString ("firstName"),
//				new NSString ("lastName"),
//				new NSString ("email"),
//				new NSString ("billing_address"),
//				new NSString ("cc_number"),
//				new NSString ("expiration_month"),
//				new NSString ("expiration_year"),
//				new NSString ("virtualTerminal")
//			};
//
//			var values = new NSObject [] {
//				new NSString ("WPiOS"),
//				new NSString ("Example"),
//				new NSString ("wp.ios.example@wepay.com"),
//				new NSString ("sdf"),
//				new NSString ("5496198584584769"),
//				new NSString ("04"),
//				new NSString ("2015"),
//				new NSString ("YES")
//			};
//			var cardInfo = NSDictionary.FromObjectsAndKeys (values, keys);
			var address = new WPAddress ("33056");

			var info = new WPPaymentInfo ("first name", "last name", "email@valid.com", address, address, "5496198584584769", "123", "04", "2018", true);
			wePay.TokenizePaymentInfo (info, new TokenizationDelegate (UpdateStatus));
		}

		#endregion

		class TokenizationDelegate : WPTokenizationDelegate
		{
			Action<string, string, string> _updateStatus;

			public TokenizationDelegate (Action<string, string, string> updateStatus)
			{
				_updateStatus = updateStatus;
			}

			#region implemented abstract members of WPTokenizationDelegate

			public override void DidFailTokenization (WPPaymentInfo paymentInfo, NSError error)
			{
				_updateStatus ("TokenizationDelegate", "DidFailTokenization", "paymentInfo: " + paymentInfo.ToString () + " - error: " + error.ToString ());
			}

			public override void DidTokenize (WPPaymentInfo paymentInfo, WPPaymentToken paymentToken)
			{
				_updateStatus ("TokenizationDelegate", "DidTokenize", "paymentInfo: " + paymentInfo.ToString () + " - paymentToken: " + paymentToken.ToString ());

				var image = UIImage.FromBundle ("signature.png");
				//wePay.StoreSignatureImage (image, "12345", new SignatureDelegate ());
			}

			#endregion
		}

		class SwiperDelegate : WPSwiperDelegate
		{
			Action<string, string, string> _updateStatus;

			public SwiperDelegate (Action<string, string, string> updateStatus)
			{
				_updateStatus = updateStatus;
			}

			#region implemented abstract members of WPSwiperDelegate

			public override void DidFailToReadPaymentInfoWithError (NSError error)
			{
				_updateStatus ("SwiperDelegate", "DidFailToReadPaymentInfoWithError", error.ToString ());
			}

			public override void DidReadPaymentInfo (WPPaymentInfo paymentInfo)
			{
				_updateStatus ("SwiperDelegate", "DidReadPaymentInfo", paymentInfo.ToString ());
			}

			public override void SwiperDidChangeStatus (NSObject status)
			{
				_updateStatus ("SwiperDelegate", "SwiperDidChangeStatus", status.ToString ());
			}

			#endregion

		}

		class SignatureDelegate : WPSignatureDelegate
		{
			Action<string, string, string> _updateStatus;

			public SignatureDelegate (Action<string, string, string> updateStatus)
			{
				_updateStatus = updateStatus;
			}

			#region implemented abstract members of WPSignatureDelegate

			public override void DidFailToStoreSignatureImage (UIImage image, string checkoutId, NSError error)
			{
				_updateStatus ("SignatureDelegate", "DidFailToStoreSignatureImage", error.ToString ());
			}

			public override void DidStoreSignature (string signatureUrl, string checkoutId)
			{
				_updateStatus ("SignatureDelegate", "DidStoreSignature", "signatureUrl: " + signatureUrl + " - checkoutId: " + checkoutId);
			}

			#endregion


		}
	}
}


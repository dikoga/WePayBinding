using System;
using System.Drawing;

using Foundation;
using UIKit;
using WePayBinding;
using Xamarin;

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

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var config = new WPConfig ("171482", WePayEnviroment.Stage, true, false, false, false, false, false);
			wePay = new WePay (config);
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
			wePay.StartCardReaderForReadingWithCardReaderDelegate (new CardReaderDelegate (UpdateStatus));
		}

		partial void TokenizeButton_TouchUpInside (UIButton sender)
		{
			Insights.Report (new Exception ("tokenizing"));

			wePay.StartCardReaderForTokenizingWithCardReaderDelegate (new CardReaderDelegate (UpdateStatus), new TokenizationDelegate (UpdateStatus), new AuthorizationDelegate (UpdateStatus));
		}

		partial void TokenizeManualButton_TouchUpInside (UIButton sender)
		{
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

				//var image = UIImage.FromBundle ("signature.png");
				//wePay.StoreSignatureImage (image, "12345", new SignatureDelegate ());
			}

			#endregion
		}

		class CardReaderDelegate : WPCardReaderDelegate
		{
			Action<string, string, string> _updateStatus;

			public CardReaderDelegate (Action<string, string, string> updateStatus)
			{
				_updateStatus = updateStatus;
			}

			#region implemented abstract members of WPSwiperDelegate

			public override void DidFailToReadPaymentInfoWithError (NSError error)
			{
				_updateStatus ("CardReaderDelegate", "DidFailToReadPaymentInfoWithError", error.ToString ());
			}

			public override void DidReadPaymentInfo (WPPaymentInfo paymentInfo)
			{
				_updateStatus ("CardReaderDelegate", "DidReadPaymentInfo", paymentInfo.ToString ());
			}

			public override void CardReaderDidChangeStatus (NSObject status)
			{
				_updateStatus ("CardReaderDelegate", "SwiperDidChangeStatus", status.ToString ());
			}

			public override void AuthorizeAmountWithCompletion (Action<NSDecimalNumber, NSString, nint> completion)
			{
				_updateStatus ("CardReaderDelegate", "AuthorizeAmountWithCompletion", "amount");
				var amout = new NSDecimalNumber ("21.61");
				var currency = new NSString ("USD");
				completion (amout, currency, 1170640190);
			}

			//			public override void ShouldResetCardReaderWithCompletion (Action<bool> completion)
			//			{
			//				completion (false);
			//			}

			#endregion
		}

		class SignatureDelegate : WPCheckoutDelegate
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

		class AuthorizationDelegate : WPAuthorizationDelegate
		{
			Action<string, string, string> _updateStatus;

			public AuthorizationDelegate (Action<string, string, string> updateStatus)
			{
				_updateStatus = updateStatus;
			}

			#region implemented abstract members of WPAuthorizationDelegate

			public override void DidAuthorize (WPPaymentInfo paymentInfo, WPAuthorizationInfo authorizationInfo)
			{
				_updateStatus ("AuthorizationDelegate", "DidAuthorize", "paymentInfo: " + paymentInfo.ToString () + " - paymentToken: " + authorizationInfo.ToString ());
			}

			public override void DidFailAuthorization (WPPaymentInfo paymentInfo, NSError error)
			{
				_updateStatus ("AuthorizationDelegate", "DidFailAuthorization", error.ToString ());
			}

			public override void SelectEMVApplication (NSObject[] applications, Action<nint> completion)
			{
				completion (0);
				_updateStatus ("AuthorizationDelegate", "SelectEMVApplication", applications.ToString ());
			}

			public override void InsertPayerEmailWithCompletion (Action<NSString> completion)
			{
				completion (new NSString ("emv@example.com"));
				_updateStatus ("AuthorizationDelegate", "InsertPayerEmailWithCompletion", "emv@example.com");
			}

			#endregion
		}
	}
}


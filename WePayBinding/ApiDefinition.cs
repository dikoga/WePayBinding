using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace WePayBinding
{
	// @interface WPAddress : NSObject
	[BaseType (typeof(NSObject))]
	interface WPAddress
	{
		// @property (readonly, nonatomic, strong) NSString * address1;
		[Export ("address1", ArgumentSemantic.Strong)]
		string Address1 { get; }

		// @property (readonly, nonatomic, strong) NSString * address2;
		[Export ("address2", ArgumentSemantic.Strong)]
		string Address2 { get; }

		// @property (readonly, nonatomic, strong) NSString * city;
		[Export ("city", ArgumentSemantic.Strong)]
		string City { get; }

		// @property (readonly, nonatomic, strong) NSString * country;
		[Export ("country", ArgumentSemantic.Strong)]
		string Country { get; }

		// @property (readonly, nonatomic, strong) NSString * postcode;
		[Export ("postcode", ArgumentSemantic.Strong)]
		string Postcode { get; }

		// @property (readonly, nonatomic, strong) NSString * region;
		[Export ("region", ArgumentSemantic.Strong)]
		string Region { get; }

		// @property (readonly, nonatomic, strong) NSString * state;
		[Export ("state", ArgumentSemantic.Strong)]
		string State { get; }

		// @property (readonly, nonatomic, strong) NSString * zip;
		[Export ("zip", ArgumentSemantic.Strong)]
		string Zip { get; }

		// -(instancetype)initWithZip:(NSString *)zip;
		[Export ("initWithZip:")]
		IntPtr Constructor (string zip);

		// -(instancetype)initWithAddress1:(NSString *)address1 address2:(NSString *)address2 city:(NSString *)city state:(NSString *)state zip:(NSString *)zip;
		[Export ("initWithAddress1:address2:city:state:zip:")]
		IntPtr Constructor (string address1, string address2, string city, string state, string zip);

		// -(instancetype)initWithAddress1:(NSString *)address1 address2:(NSString *)address2 city:(NSString *)city region:(NSString *)region postcode:(NSString *)postcode country:(NSString *)country;
		[Export ("initWithAddress1:address2:city:region:postcode:country:")]
		IntPtr Constructor (string address1, string address2, string city, string region, string postcode, string country);

		// -(NSDictionary *)toDict;
		//		[Export ("toDict")]
		//		[Verify (MethodToProperty)]
		//		NSDictionary ToDict { get; }
	}

	// @interface WPConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface WPConfig
	{
		// @property (readonly, nonatomic, strong) NSString * clientId;
		[Export ("clientId", ArgumentSemantic.Strong)]
		string ClientId { get; }

		// @property (readonly, nonatomic, strong) NSString * environment;
		[Export ("environment", ArgumentSemantic.Strong)]
		string Environment { get; }

		// @property (assign, nonatomic) BOOL useLocation;
		[Export ("useLocation")]
		bool UseLocation { get; set; }

		// @property (assign, nonatomic) BOOL useTestEMVCards;
		[Export ("useTestEMVCards")]
		bool UseTestEMVCards { get; set; }

		// @property (assign, nonatomic) BOOL callDelegateMethodsOnMainThread;
		[Export ("callDelegateMethodsOnMainThread")]
		bool CallDelegateMethodsOnMainThread { get; set; }

		// @property (assign, nonatomic) BOOL restartCardReaderAfterSuccess;
		[Export ("restartCardReaderAfterSuccess")]
		bool RestartCardReaderAfterSuccess { get; set; }

		// @property (assign, nonatomic) BOOL restartCardReaderAfterGeneralError;
		[Export ("restartCardReaderAfterGeneralError")]
		bool RestartCardReaderAfterGeneralError { get; set; }

		// @property (assign, nonatomic) BOOL restartCardReaderAfterOtherErrors;
		[Export ("restartCardReaderAfterOtherErrors")]
		bool RestartCardReaderAfterOtherErrors { get; set; }

		// -(instancetype)initWithClientId:(NSString *)clientId environment:(NSString *)environment;
		[Export ("initWithClientId:environment:")]
		IntPtr Constructor (string clientId, string environment);

		// -(instancetype)initWithClientId:(NSString *)clientId environment:(NSString *)environment useLocation:(BOOL)useLocation useTestEMVCards:(BOOL)useTestEMVCards callDelegateMethodsOnMainThread:(BOOL)callDelegateMethodsOnMainThread restartCardReaderAfterSuccess:(BOOL)restartCardReaderAfterSuccess restartCardReaderAfterGeneralError:(BOOL)restartCardReaderAfterGeneralError restartCardReaderAfterOtherErrors:(BOOL)restartCardReaderAfterOtherErrors;
		[Export ("initWithClientId:environment:useLocation:useTestEMVCards:callDelegateMethodsOnMainThread:restartCardReaderAfterSuccess:restartCardReaderAfterGeneralError:restartCardReaderAfterOtherErrors:")]
		IntPtr Constructor (string clientId, string environment, bool useLocation, bool useTestEMVCards, bool callDelegateMethodsOnMainThread, bool restartCardReaderAfterSuccess, bool restartCardReaderAfterGeneralError, bool restartCardReaderAfterOtherErrors);
	}

	// @interface WPPaymentInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface WPPaymentInfo
	{
		// @property (readonly, nonatomic, strong) NSString * firstName;
		[Export ("firstName", ArgumentSemantic.Strong)]
		string FirstName { get; }

		// @property (readonly, nonatomic, strong) NSString * lastName;
		[Export ("lastName", ArgumentSemantic.Strong)]
		string LastName { get; }

		// @property (readonly, nonatomic, strong) NSString * email;
		[Export ("email", ArgumentSemantic.Strong)]
		string Email { get; }

		// @property (readonly, nonatomic, strong) NSString * paymentDescription;
		[Export ("paymentDescription", ArgumentSemantic.Strong)]
		string PaymentDescription { get; }

		// @property (readonly, nonatomic) BOOL isVirtualTerminal;
		[Export ("isVirtualTerminal")]
		bool IsVirtualTerminal { get; }

		// @property (readonly, nonatomic, strong) WPAddress * billingAddress;
		[Export ("billingAddress", ArgumentSemantic.Strong)]
		WPAddress BillingAddress { get; }

		// @property (readonly, nonatomic, strong) WPAddress * shippingAddress;
		[Export ("shippingAddress", ArgumentSemantic.Strong)]
		WPAddress ShippingAddress { get; }

		// @property (readonly, nonatomic, strong) id paymentMethod;
		[Export ("paymentMethod", ArgumentSemantic.Strong)]
		NSObject PaymentMethod { get; }

		// @property (readonly, nonatomic, strong) id swiperInfo;
		[Export ("swiperInfo", ArgumentSemantic.Strong)]
		NSObject SwiperInfo { get; }

		// @property (readonly, nonatomic, strong) id manualInfo;
		[Export ("manualInfo", ArgumentSemantic.Strong)]
		NSObject ManualInfo { get; }

		// @property (readonly, nonatomic, strong) id emvInfo;
		[Export ("emvInfo", ArgumentSemantic.Strong)]
		NSObject EmvInfo { get; }

		// -(instancetype)initWithSwipedInfo:(id)swipedInfo;
		[Export ("initWithSwipedInfo:")]
		IntPtr Constructor (NSDictionary swipedInfo);

		// -(instancetype)initWithEMVInfo:(id)emvInfo;
		[Export ("initWithEMVInfo:")]
		IntPtr Constructor (NSObject emvInfo);

		// -(instancetype)initWithFirstName:(NSString *)firstName lastName:(NSString *)lastName email:(NSString *)email billingAddress:(WPAddress *)billingAddress shippingAddress:(WPAddress *)shippingAddress cardNumber:(NSString *)cardNumber cvv:(NSString *)cvv expMonth:(NSString *)expMonth expYear:(NSString *)expYear virtualTerminal:(BOOL)virtualTerminal;
		[Export ("initWithFirstName:lastName:email:billingAddress:shippingAddress:cardNumber:cvv:expMonth:expYear:virtualTerminal:")]
		IntPtr Constructor (string firstName, string lastName, string email, WPAddress billingAddress, WPAddress shippingAddress, string cardNumber, string cvv, string expMonth, string expYear, bool virtualTerminal);

		// -(void)addEmail:(NSString *)email;
		[Export ("addEmail:")]
		void AddEmail (string email);
	}

	// @interface WPPaymentToken : NSObject
	[BaseType (typeof(NSObject))]
	interface WPPaymentToken
	{
		// @property (readonly, nonatomic, strong) NSString * tokenId;
		[Export ("tokenId", ArgumentSemantic.Strong)]
		string TokenId { get; }

		// -(instancetype)initWithId:(NSString *)tokenId;
		[Export ("initWithId:")]
		IntPtr Constructor (string tokenId);
	}

	// @interface WPAuthorizationInfo : WPPaymentToken
	[BaseType (typeof(WPPaymentToken))]
	interface WPAuthorizationInfo
	{
		// @property (readonly, nonatomic, strong) NSDecimalNumber * amount;
		[Export ("amount", ArgumentSemantic.Strong)]
		NSDecimalNumber Amount { get; }

		// @property (readonly, nonatomic, strong) NSString * currencyCode;
		[Export ("currencyCode", ArgumentSemantic.Strong)]
		string CurrencyCode { get; }

		// @property (readonly, nonatomic, strong) NSString * transactionToken;
		[Export ("transactionToken", ArgumentSemantic.Strong)]
		string TransactionToken { get; }

		// -(instancetype)initWithAmount:(NSDecimalNumber *)amount currencyCode:(NSString *)currencyCode transactionToken:(NSString *)transactionToken tokenId:(NSString *)tokenId;
		[Export ("initWithAmount:currencyCode:transactionToken:tokenId:")]
		IntPtr Constructor (NSDecimalNumber amount, string currencyCode, string transactionToken, string tokenId);
	}

	//	[Static]
	//	[Verify (ConstantsInterfaceAssociation)]
	//	partial interface Constants
	//	{
	//		// extern NSString *const kWPEnvironmentStage;
	//		[Field ("kWPEnvironmentStage", "__Internal")]
	//		NSString kWPEnvironmentStage { get; }
	//
	//		// extern NSString *const kWPEnvironmentProduction;
	//		[Field ("kWPEnvironmentProduction", "__Internal")]
	//		NSString kWPEnvironmentProduction { get; }
	//
	//		// extern NSString *const kWPPaymentMethodSwipe;
	//		[Field ("kWPPaymentMethodSwipe", "__Internal")]
	//		NSString kWPPaymentMethodSwipe { get; }
	//
	//		// extern NSString *const kWPPaymentMethodManual;
	//		[Field ("kWPPaymentMethodManual", "__Internal")]
	//		NSString kWPPaymentMethodManual { get; }
	//
	//		// extern NSString *const kWPPaymentMethodDip;
	//		[Field ("kWPPaymentMethodDip", "__Internal")]
	//		NSString kWPPaymentMethodDip { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusNotConnected;
	//		[Field ("kWPCardReaderStatusNotConnected", "__Internal")]
	//		NSString kWPCardReaderStatusNotConnected { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusConnected;
	//		[Field ("kWPCardReaderStatusConnected", "__Internal")]
	//		NSString kWPCardReaderStatusConnected { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusCheckingReader;
	//		[Field ("kWPCardReaderStatusCheckingReader", "__Internal")]
	//		NSString kWPCardReaderStatusCheckingReader { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusConfiguringReader;
	//		[Field ("kWPCardReaderStatusConfiguringReader", "__Internal")]
	//		NSString kWPCardReaderStatusConfiguringReader { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusWaitingForCard;
	//		[Field ("kWPCardReaderStatusWaitingForCard", "__Internal")]
	//		NSString kWPCardReaderStatusWaitingForCard { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusShouldNotSwipeEMVCard;
	//		[Field ("kWPCardReaderStatusShouldNotSwipeEMVCard", "__Internal")]
	//		NSString kWPCardReaderStatusShouldNotSwipeEMVCard { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusCheckCardOrientation;
	//		[Field ("kWPCardReaderStatusCheckCardOrientation", "__Internal")]
	//		NSString kWPCardReaderStatusCheckCardOrientation { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusChipErrorSwipeCard;
	//		[Field ("kWPCardReaderStatusChipErrorSwipeCard", "__Internal")]
	//		NSString kWPCardReaderStatusChipErrorSwipeCard { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusSwipeErrorSwipeAgain;
	//		[Field ("kWPCardReaderStatusSwipeErrorSwipeAgain", "__Internal")]
	//		NSString kWPCardReaderStatusSwipeErrorSwipeAgain { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusSwipeDetected;
	//		[Field ("kWPCardReaderStatusSwipeDetected", "__Internal")]
	//		NSString kWPCardReaderStatusSwipeDetected { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusCardDipped;
	//		[Field ("kWPCardReaderStatusCardDipped", "__Internal")]
	//		NSString kWPCardReaderStatusCardDipped { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusTokenizing;
	//		[Field ("kWPCardReaderStatusTokenizing", "__Internal")]
	//		NSString kWPCardReaderStatusTokenizing { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusAuthorizing;
	//		[Field ("kWPCardReaderStatusAuthorizing", "__Internal")]
	//		NSString kWPCardReaderStatusAuthorizing { get; }
	//
	//		// extern NSString *const kWPCardReaderStatusStopped;
	//		[Field ("kWPCardReaderStatusStopped", "__Internal")]
	//		NSString kWPCardReaderStatusStopped { get; }
	//
	//		// extern NSString *const kWPCurrencyCodeUSD;
	//		[Field ("kWPCurrencyCodeUSD", "__Internal")]
	//		NSString kWPCurrencyCodeUSD { get; }
	//	}

	// @protocol WPAuthorizationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface WPAuthorizationDelegate
	{
		// @required -(void)selectEMVApplication:(NSArray *)applications completion:(void (^)(NSInteger))completion;
		[Abstract]
		[Export ("selectEMVApplication:completion:")]
		//[Verify (StronglyTypedNSArray)]
		void SelectEMVApplication (NSObject[] applications, Action<nint> completion);

		// @required -(void)paymentInfo:(WPPaymentInfo *)paymentInfo didAuthorize:(WPAuthorizationInfo *)authorizationInfo;
		[Abstract]
		[Export ("paymentInfo:didAuthorize:")]
		void DidAuthorize (WPPaymentInfo paymentInfo, WPAuthorizationInfo authorizationInfo);

		// @required -(void)paymentInfo:(WPPaymentInfo *)paymentInfo didFailAuthorization:(NSError *)error;
		[Abstract]
		[Export ("paymentInfo:didFailAuthorization:")]
		void DidFailAuthorization (WPPaymentInfo paymentInfo, NSError error);

		// @optional -(void)insertPayerEmailWithCompletion:(void (^)(NSString *))completion;
		[Export ("insertPayerEmailWithCompletion:")]
		void InsertPayerEmailWithCompletion (Action<NSString> completion);
	}

	// @protocol WPTokenizationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface WPTokenizationDelegate
	{
		// @required -(void)paymentInfo:(WPPaymentInfo *)paymentInfo didTokenize:(WPPaymentToken *)paymentToken;
		[Abstract]
		[Export ("paymentInfo:didTokenize:")]
		void DidTokenize (WPPaymentInfo paymentInfo, WPPaymentToken paymentToken);

		// @required -(void)paymentInfo:(WPPaymentInfo *)paymentInfo didFailTokenization:(NSError *)error;
		[Abstract]
		[Export ("paymentInfo:didFailTokenization:")]
		void DidFailTokenization (WPPaymentInfo paymentInfo, NSError error);
	}

	// @protocol WPCardReaderDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface WPCardReaderDelegate
	{
		// @required -(void)didReadPaymentInfo:(WPPaymentInfo *)paymentInfo;
		[Abstract]
		[Export ("didReadPaymentInfo:")]
		void DidReadPaymentInfo (WPPaymentInfo paymentInfo);

		// @required -(void)didFailToReadPaymentInfoWithError:(NSError *)error;
		[Abstract]
		[Export ("didFailToReadPaymentInfoWithError:")]
		void DidFailToReadPaymentInfoWithError (NSError error);

		// @optional -(void)cardReaderDidChangeStatus:(id)status;
		[Export ("cardReaderDidChangeStatus:")]
		void CardReaderDidChangeStatus (NSObject status);

		// @optional -(void)shouldResetCardReaderWithCompletion:(void (^)(BOOL))completion;
		[Export ("shouldResetCardReaderWithCompletion:")]
		void ShouldResetCardReaderWithCompletion (Action<bool> completion);

		// @optional -(void)authorizeAmountWithCompletion:(void (^)(NSDecimalNumber *, NSString *, long))completion;
		[Export ("authorizeAmountWithCompletion:")]
		void AuthorizeAmountWithCompletion (Action<NSDecimalNumber, NSString, nint> completion);
	}

	// @protocol WPCheckoutDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface WPCheckoutDelegate
	{
		// @required -(void)didStoreSignature:(NSString *)signatureUrl forCheckoutId:(NSString *)checkoutId;
		[Abstract]
		[Export ("didStoreSignature:forCheckoutId:")]
		void DidStoreSignature (string signatureUrl, string checkoutId);

		// @required -(void)didFailToStoreSignatureImage:(UIImage *)image forCheckoutId:(NSString *)checkoutId withError:(NSError *)error;
		[Abstract]
		[Export ("didFailToStoreSignatureImage:forCheckoutId:withError:")]
		void DidFailToStoreSignatureImage (UIImage image, string checkoutId, NSError error);
	}

	// @interface WePay : NSObject
	[BaseType (typeof(NSObject))]
	interface WePay
	{
		// @property (readonly, nonatomic, strong) WPConfig * config;
		[Export ("config", ArgumentSemantic.Strong)]
		WPConfig Config { get; }

		// -(instancetype)initWithConfig:(WPConfig *)config;
		[Export ("initWithConfig:")]
		IntPtr Constructor (WPConfig config);

		// -(void)tokenizePaymentInfo:(WPPaymentInfo *)paymentInfo tokenizationDelegate:(id<WPTokenizationDelegate>)tokenizationDelegate;
		[Export ("tokenizePaymentInfo:tokenizationDelegate:")]
		void TokenizePaymentInfo (WPPaymentInfo paymentInfo, WPTokenizationDelegate tokenizationDelegate);

		// -(void)startCardReaderForReadingWithCardReaderDelegate:(id<WPCardReaderDelegate>)cardReaderDelegate;
		[Export ("startCardReaderForReadingWithCardReaderDelegate:")]
		void StartCardReaderForReadingWithCardReaderDelegate (WPCardReaderDelegate cardReaderDelegate);

		// -(void)startCardReaderForTokenizingWithCardReaderDelegate:(id<WPCardReaderDelegate>)cardReaderDelegate tokenizationDelegate:(id<WPTokenizationDelegate>)tokenizationDelegate authorizationDelegate:(id<WPAuthorizationDelegate>)authorizationDelegate;
		[Export ("startCardReaderForTokenizingWithCardReaderDelegate:tokenizationDelegate:authorizationDelegate:")]
		void StartCardReaderForTokenizingWithCardReaderDelegate (WPCardReaderDelegate cardReaderDelegate, WPTokenizationDelegate tokenizationDelegate, WPAuthorizationDelegate authorizationDelegate);

		// -(void)stopCardReader;
		[Export ("stopCardReader")]
		void StopCardReader ();

		// -(void)storeSignatureImage:(UIImage *)image forCheckoutId:(NSString *)checkoutId checkoutDelegate:(id<WPCheckoutDelegate>)checkoutDelegate;
		[Export ("storeSignatureImage:forCheckoutId:checkoutDelegate:")]
		void StoreSignatureImage (UIImage image, string checkoutId, WPCheckoutDelegate checkoutDelegate);
	}

}
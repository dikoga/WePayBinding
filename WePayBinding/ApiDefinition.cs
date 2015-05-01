using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

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
		[Export ("toDict")]
		NSDictionary ToDict { get; }
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

		// @property (readonly, nonatomic, strong) NSString * applePayMerchantId;
		[Export ("applePayMerchantId", ArgumentSemantic.Strong)]
		string ApplePayMerchantId { get; }

		// @property (assign, nonatomic) BOOL useLocation;
		[Export ("useLocation")]
		bool UseLocation { get; set; }

		// @property (assign, nonatomic) BOOL restartSwiperAfterSuccess;
		[Export ("restartSwiperAfterSuccess")]
		bool RestartSwiperAfterSuccess { get; set; }

		// @property (assign, nonatomic) BOOL restartSwiperAfterSwipeGeneralError;
		[Export ("restartSwiperAfterSwipeGeneralError")]
		bool RestartSwiperAfterSwipeGeneralError { get; set; }

		// @property (assign, nonatomic) BOOL restartSwiperAfterSwipeOtherErrors;
		[Export ("restartSwiperAfterSwipeOtherErrors")]
		bool RestartSwiperAfterSwipeOtherErrors { get; set; }
		// -(instancetype)initWithClientId:(NSString *)clientId environment:(NSString *)environment;
		[Export ("initWithClientId:environment:")]
		IntPtr Constructor (string clientId, string environment);

		// -(instancetype)initWithClientId:(NSString *)clientId environment:(NSString *)environment applePayMerchantId:(NSString *)applePayMerchantId useLocation:(BOOL)useLocation restartSwiperAfterSuccess:(BOOL)restartSwiperAfterSuccess restartSwiperAfterSwipeGeneralError:(BOOL)restartSwiperAfterSwipeGeneralError restartSwiperAfterSwipeOtherErrors:(BOOL)restartSwiperAfterSwipeOtherErrors;
		[Export ("initWithClientId:environment:applePayMerchantId:useLocation:restartSwiperAfterSuccess:restartSwiperAfterSwipeGeneralError:restartSwiperAfterSwipeOtherErrors:")]
		IntPtr Constructor (string clientId, string environment, string applePayMerchantId, bool useLocation, bool restartSwiperAfterSuccess, bool restartSwiperAfterSwipeGeneralError, bool restartSwiperAfterSwipeOtherErrors);
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

		// @property (readonly, nonatomic, strong) id applePayInfo;
		[Export ("applePayInfo", ArgumentSemantic.Strong)]
		NSObject ApplePayInfo { get; }

		// @property (readonly, nonatomic, strong) id googleInstantBuyInfo;
		[Export ("googleInstantBuyInfo", ArgumentSemantic.Strong)]
		NSObject GoogleInstantBuyInfo { get; }

		// -(instancetype)initWithSwipedInfo:(id)swipedInfo;
		[Export ("initWithSwipedInfo:")]
		IntPtr Constructor (NSObject swipedInfo);

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
		
	// @protocol WPSwiperDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface WPSwiperDelegate
	{
		// @required -(void)didReadPaymentInfo:(WPPaymentInfo *)paymentInfo;
		[Abstract]
		[Export ("didReadPaymentInfo:")]
		void DidReadPaymentInfo (WPPaymentInfo paymentInfo);

		// @required -(void)didFailToReadPaymentInfoWithError:(NSError *)error;
		[Abstract]
		[Export ("didFailToReadPaymentInfoWithError:")]
		void DidFailToReadPaymentInfoWithError (NSError error);

		// @required -(void)swiperDidChangeStatus:(id)status;
		[Abstract]
		[Export ("swiperDidChangeStatus:")]
		void SwiperDidChangeStatus (NSObject status);
	}

	// @protocol WPSignatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface WPSignatureDelegate
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

		// -(NSArray *)availablePaymentMethods;
		[Export ("availablePaymentMethods")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSArray AvailablePaymentMethods { get; }

		// -(void)tokenizePaymentInfo:(WPPaymentInfo *)paymentInfo tokenizationDelegate:(id<WPTokenizationDelegate>)tokenizationDelegate;
		[Export ("tokenizePaymentInfo:tokenizationDelegate:")]
		void TokenizePaymentInfo (WPPaymentInfo paymentInfo, WPTokenizationDelegate tokenizationDelegate);

		// -(void)startSwiperForReadingWithSwiperDelegate:(id<WPSwiperDelegate>)delegate;
		[Export ("startSwiperForReadingWithSwiperDelegate:")]
		void StartSwiperForReadingWithSwiperDelegate (WPSwiperDelegate _delegate);

		// -(void)startSwiperForTokenizingWithSwiperDelegate:(id<WPSwiperDelegate>)swiperDelegate tokenizationDelegate:(id<WPTokenizationDelegate>)tokenizationDelegate;
		[Export ("startSwiperForTokenizingWithSwiperDelegate:tokenizationDelegate:")]
		void StartSwiperForTokenizingWithSwiperDelegate (WPSwiperDelegate swiperDelegate, WPTokenizationDelegate tokenizationDelegate);

		// -(void)stopSwiper;
		[Export ("stopSwiper")]
		void StopSwiper ();

		// -(void)storeSignatureImage:(UIImage *)image forCheckoutId:(NSString *)checkoutId signatureDelegate:(id<WPSignatureDelegate>)signatureDelegate;
		[Export ("storeSignatureImage:forCheckoutId:signatureDelegate:")]
		void StoreSignatureImage (UIImage image, string checkoutId, WPSignatureDelegate signatureDelegate);

		// -(void)tokenizeManualPaymentInfo:(WPPaymentInfo *)paymentInfo tokenizationDelegate:(id<WPTokenizationDelegate>)tokenizationDelegate;
	}
}


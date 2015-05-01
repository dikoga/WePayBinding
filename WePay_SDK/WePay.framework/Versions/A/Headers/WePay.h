//
//  WePay.h
//  WePay
//
//  Created by Chaitanya Bagaria on 10/30/14.
//  Copyright (c) 2014 WePay. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

#import "WPAddress.h"
#import "WPConfig.h"
#import "WPPaymentInfo.h"
#import "WPPaymentToken.h"

@class WePay_Swiper;

@class WPApplePayPaymentRequest;
@class WPConfig;
@class WPGoogleInstantBuyPaymentRequest;
@class WPPaymentInfo;
@class WPPaymentToken;

// Environments
static NSString* const kWPEnvironmentStage = @"stage";
static NSString* const kWPEnvironmentProduction = @"production";

// Payment Methods
static NSString* const kWPPaymentMethodApplePay = @"Apple Pay";
static NSString* const kWPPaymentMethodGoogleInstantBuy = @"Google Instant Buy";
static NSString* const kWPPaymentMethodSwiper = @"Swiper";
static NSString* const kWPPaymentMethodManual = @"Manual";

// Swiper status
static NSString* const kWPSwiperStatusNotConnected = @"swiper not connected";
static NSString* const kWPSwiperStatusConnected = @"swiper connected";
static NSString* const kWPSwiperStatusWaitingForSwipe = @"waiting for swipe";
static NSString* const kWPSwiperStatusSwipeDetected = @"swipe detected";
static NSString* const kWPSwiperStatusTokenizing = @"tokenizing";
static NSString* const kWPSwiperStatusStopped = @"stopped";


/** \protocol WPTokenizationDelegate
 *  This delegate protocol has to be adopted by any class that handles tokenization responses.
 */
@protocol WPTokenizationDelegate <NSObject>

/**
 *  Called when a tokenization call succeeds.
 *
 *  @param paymentInfo  The payment token to be used for completing the transaction.
 *  @param paymentToken The payment token representing the payment info.
 */
- (void) paymentInfo:(WPPaymentInfo *)paymentInfo
         didTokenize:(WPPaymentToken *)paymentToken;

/**
 *  Called when a tokenization call fails.
 *
 *  @param paymentInfo The payment info that was provided while making the tokenization call.
 *  @param error       The error which caused the failure.
 */
- (void) paymentInfo:(WPPaymentInfo *)paymentInfo
 didFailTokenization:(NSError *)error;

@end


/** \protocol WPApplePayDelegate
 *  This delegate protocol has to be adopted by any class that handles Apple Pay responses.
 */
@protocol WPApplePayDelegate <NSObject>

/**
 *  Called when the user selects a shipping address. Provides an opportunity to respond to this action, via the completion block.
 *
 *  @param paymentRequest The payment request being processed.
 *  @param address        The address selected by the user.
 *  @param completion     The completion block to be executed to respond to the event.
 */
- (void) paymentRequest:(WPApplePayPaymentRequest *)paymentRequest
didSelectShippingAddress:(id)address
             completion:(void (^)(id status, NSArray *shippingMethods, NSArray *summaryItems))completion;

/**
 *  Called when the user selects a shipping method. Provides an opportunity to respond to this action, via the completion block.
 *
 *  @param paymentRequest The payment request being processed.
 *  @param shippingMethod The shippingMethod selected by the user.
 *  @param completion     The completion block to be executed to respond to the event.
 */
- (void) paymentRequest:(WPApplePayPaymentRequest *)paymentRequest
didSelectShippingMethod:(id)shippingMethod
             completion:(void (^)(id status, NSArray *shippingMethods, NSArray *summaryItems))completion;

/**
 *  Called when a tokenization call succeeds, but the user is still waiting for a final response
 *
 *  @param paymentRequest The payment request being processed.
 *  @param paymentToken   The payment token to be used for completing the transaction.
 *  @param completion     The completion block to be executed to respond to the event. The boolean status parameter will be displayed to user as the final result.
 */
- (void) paymentRequest:(WPApplePayPaymentRequest *)paymentRequest
            didTokenize:(WPPaymentToken *)paymentToken
             completion:(void (^)(BOOL status))completion;

/**
 *  Called when a tokenization call fails.
 *
 *  @param paymentRequest The payment request being processed.
 *  @param error          The error which caused the failure.
 */
- (void) paymentRequest:(WPApplePayPaymentRequest *)paymentRequest
    didFailTokenization:(NSError *)error;

@end


/** \protocol WPGoogleInstantBuyDelegate
 *  This delegate protocol has to be adopted by any class that handles Google Instant Buy responses.
 */
@protocol WPGoogleInstantBuyDelegate <NSObject>

/**
 *  Called when payment info is successfully obtained from Google.
 *
 *  @param paymentRequest The payment request being processed.
 *  @param paymentInfo The payment info.
 */
- (void) paymentRequest:(WPGoogleInstantBuyPaymentRequest *)paymentRequest
      didGetPaymentInfo:(WPPaymentInfo *)paymentInfo;

/**
 *  Called when an error occurs while obtaining payment info from Google.
 *
 *  @param paymentRequest The payment request being processed.
 *  @param error The error which caused the failure.
 */
- (void) paymentRequest:(WPGoogleInstantBuyPaymentRequest *)paymentRequest
didFailToGetPaymentInfo:(NSError *)error;

/**
 *  Called in response to checkForPreauthorization
 *
 *  @param preauthorized YES if user is pre-authorized, No otherwise.
 */
- (void) userIsPreauthorized:(BOOL)preauthorized;

@end


/** \protocol WPSwiperDelegate
 *  This delegate protocol has to be adopted by any class that handles Swiper responses.
 */
@protocol WPSwiperDelegate <NSObject>

/**
 *  Called when payment info is successfully obtained from a swiped card.
 *
 *  @param paymentInfo The payment info.
 */
- (void) didReadPaymentInfo:(WPPaymentInfo *)paymentInfo;

/**
 *  Called when an error occurs while reading a card.
 *
 *  @param error The error which caused the failure.
 */
- (void) didFailToReadPaymentInfoWithError:(NSError *)error;

/**
 *  Called when the swiper changes status.
 *
 *  @param status Current status of the swiper, one of (kWPSwiperStatusNotConnected, kWPSwiperStatusWaitingForSwipe, kWPSwiperStatusTokenizing).
 */
- (void) swiperDidChangeStatus:(id)status;


@end


/** \protocol WPSignatureDelegate
 *  This delegate protocol has to be adopted by any class that handles Signature responses.
 */
@protocol WPSignatureDelegate <NSObject>

/**
 *  Called when a signature is successfully stored for the given checkout id.
 *
 *  @param signatureUrl The url for the signature image.
 *  @param checkoutId   The checkout id associated with the signature.
 */
- (void) didStoreSignature:(NSString *)signatureUrl
             forCheckoutId:(NSString *)checkoutId;

/**
 *  Called when an error occurs while storing a signature.
 *
 *  @param image        The signature image to be stored.
 *  @param checkoutId   The checkout id associated with the signature.
 *  @param error        The error which caused the failure.
 */
- (void) didFailToStoreSignatureImage:(UIImage *)image
                        forCheckoutId:(NSString *)checkoutId
                            withError:(NSError *)error;


@end


/**
 *  Main Class containing all public endpoints.
 */
@interface WePay : NSObject

/**
 *  Your WePay config
 */
@property (nonatomic, strong, readonly) WPConfig *config;


/**
 *  The designated intializer. Use this to initialize the SDK.
 *
 *  @param config A \ref WPConfig instance.
 *
 *  @return A \ref WePay instance, which can be used to access most of the functionality of this sdk.
 */
- (instancetype) initWithConfig:(WPConfig *)config;

/**
 *  Gets a list of all available payment methods, from (kWPPaymentMethodApplePay, kWPPaymentMethodGoogleInstantBuy, kWPPaymentMethodManual, kWPPaymentMethodSwiper).
 *
 *  @return An array of payment methods that can be used on this device.
 */
- (NSArray *) availablePaymentMethods;

/**
 *  Creates a payment token from a WPPaymentInfo object.
 *
 *  @param paymentInfo          The payment info obtained from the user in any form.
 *  @param tokenizationDelegate The delegate class which will receive the tokenization response(s) for this call.
 */
- (void) tokenizePaymentInfo:(WPPaymentInfo *)paymentInfo
        tokenizationDelegate:(id<WPTokenizationDelegate>)tokenizationDelegate;


#pragma mark -
#pragma mark Apple Pay

/** @name Apple Pay
 */
///@{

/**
 *  Provides an Apple Pay button to be inserted into the UI. Initiates the Apple Pay experience when the user taps the button and then creates a payment token.
 *
 *  @param size                 Size for the button.
 *  @param paymentRequest       All the information required for using ApplePay (e.g., merchantId, amount, shippingAddressRequired, billingAddressRequired).
 *  @param applePayDelegate     The delegate class which will receive the Apple Pay response(s) for this call.
 */
- (UIButton *) buttonForApplePayWithSize:(CGRect)size
                    paymentRequest:(WPApplePayPaymentRequest *)paymentRequest
                  applePayDelegate:(id<WPApplePayDelegate>)applePayDelegate;

/**
 *  Initiates the Apple Pay experience, then creates a payment token.
 *
 *  @param paymentRequest       All the information required for using ApplePay (e.g., merchantId, amount, shippingAddressRequired, billingAddressRequired).
 *  @param applePayDelegate     The delegate class which will receive the Apple Pay response(s) for this call.
 */
- (void) tokenizeApplePayPaymentRequest:(WPApplePayPaymentRequest *)paymentRequest
                       applePayDelegate:(id<WPApplePayDelegate>)applePayDelegate;

///@}

#pragma mark -
#pragma mark google Instant Buy

/** @name Google Instant Buy
 */
///@{

/**
 *  Checks if the user has previously authorized this app to use Google Instant Buy. If yes, then Google may return the user's payment info without showing the user any selection UI. In this case, the app should show appropriate UI to allow the user to confirm/change the payment info.
 *
 *  @param googleInstantBuyDelegate The delegate class which will receive the Google Instant Buy response(s) for this call.
 */
- (void) checkForPreauthorizationWithGoogleInstantBuyDelegate:(id<WPGoogleInstantBuyDelegate>)googleInstantBuyDelegate;

/**
 *  Provides a Buy With Google button to be inserted into the UI. Initiates the Buy With Google experience when the user taps the button.
 *
 *  @param size                     Size for the button.
 *  @param paymentRequest           All the information required for using Google Instant Buy (e.g., merchantId, amount, shippingAddressRequired, billingAddressRequired).
 *  @param googleInstantBuyDelegate The delegate class which will receive the Google Instant Buy response(s) for this call.
 */
- (UIButton *) buttonForGoogleInstantBuyWithSize:(CGRect)size
                            paymentRequest:(WPGoogleInstantBuyPaymentRequest *)paymentRequest
                  googleInstantBuyDelegate:(id<WPGoogleInstantBuyDelegate>)googleInstantBuyDelegate;

/**
 *  Initiates the Buy With Google experience.
 *
 *  @param paymentRequest           All the information required for using Google Instant Buy (e.g., merchantId, amount, shippingAddressRequired, billingAddressRequired).
 *  @param googleInstantBuyDelegate The delegate class which will receive the Google Instant Buy response(s) for this call.
 */
- (void) paymentInfoWithPaymentRequest:(WPGoogleInstantBuyPaymentRequest *)paymentRequest
              googleInstantBuyDelegate:(id<WPGoogleInstantBuyDelegate>)googleInstantBuyDelegate;

/**
 *  Allows the user to change the payments option they chose.
 *
 *  @param paymentInfo              The payment info to be changed.
 *  @param googleInstantBuyDelegate The delegate class which will receive the Google Instant Buy response(s) for this call.
 */
- (void) changeGoogleInstantBuyPaymentInfo:(WPPaymentInfo *)paymentInfo
                  googleInstantBuyDelegate:(id<WPGoogleInstantBuyDelegate>)googleInstantBuyDelegate;

///@}

#pragma mark -
#pragma mark Card Reader - Swipe

/** @name Card Reader - Swipe
 */
///@{

/**
 *  Initializes the swiper for reading card info.
 *
 *  The swiper will wait 60 seconds for a swipe, and then return a timout error if a swipe is not detected.
 *  The swiper will automatically stop waiting for swipe if:
 *  - a timeout occurs
 *  - a successful swipe is detected
 *  - an unexpected error occurs
 *  - stopSwiper is called
 *
 *  However, if a general error (domain:kWPErrorCategorySwiper, errorCode:WPErrorSwiperGeneralError) occurs while reading, after a few seconds delay, the swiper will automatically start waiting again for another 60 seconds. At that time, WPSwiperDelegate's swiperDidChangeStatus: method will be called with kWPSwiperStatusWaitingForSwipe, and the user can try to swipe again. This behavior can be configured with \ref WPConfig.
 *
 *  WARNING: When this method is called, a (normally inaudible) signal is sent to the headphone jack of the phone, where the swiper is expected to be connected. If headphones are connected instead of the swiper, they may emit a very loud audible tone on receiving this signal. This method should only be called when the user intends to use the swiper.
 *
 *  @param delegate The delegate class which will receive the response(s) for this call.
 */
- (void) startSwiperForReadingWithSwiperDelegate:(id<WPSwiperDelegate>) delegate;

/**
 *  Initializes the swiper for reading card info, and then tokenizes the obtained payment info.
 *
 *  The swiper will wait 60 seconds for a swipe, and then return a timout error if a swipe is not detected.
 *  The swiper will automatically stop waiting for swipe if:
 *  - a timeout occurs
 *  - a successful swipe is detected
 *  - an unexpected error occurs
 *  - stopSwiper is called
 *
 *  However, if a general error (domain:kWPErrorCategorySwiper, errorCode:WPErrorSwiperGeneralError) occurs while reading, after a few seconds delay, the swiper will automatically start waiting again for another 60 seconds. At that time, WPSwiperDelegate's swiperDidChangeStatus: method will be called with kWPSwiperStatusWaitingForSwipe, and the user can try to swipe again. This behavior can be configured with \ref WPConfig.
 *
 *  WARNING: When this method is called, a (normally inaudible) signal is sent to the headphone jack of the phone, where the swiper is expected to be connected. If headphones are connected instead of the swiper, they may emit a very loud audible tone on receiving this signal. This method should only be called when the user intends to use the swiper.
 *
 *  @param swiperDelegate       The delegate class which will receive the Swiper response(s) for this call.
 *  @param tokenizationDelegate The delegate class which will receive the tokenization response(s) for this call.
 */
- (void) startSwiperForTokenizingWithSwiperDelegate:(id<WPSwiperDelegate>) swiperDelegate
                               tokenizationDelegate:(id<WPTokenizationDelegate>) tokenizationDelegate;

/**
 *  Stops the swiper. In response, WPTokenizationDelegate's swiperDidChangeStatus: method will be called with kWPSwiperStatusStopped.
 *  Any tokenization in progress will not be stopped, and its result will be delivered to the WPTokenizationDelegate.
 */
- (void) stopSwiper;

/**
 *  Stores a signature image associated with a checkout id on WePay's servers.
 *  The signature can be retrieved via a server-to-server call that fetches the checkout object.
 *  The aspect ratio (width:height) of the image must be between 1:4 and 4:1.
 *  If needed, the image will internally be scaled to fit inside 256x256 pixels, while maintaining the original aspect ratio.
 *
 *  @param image                The signature image to be stored.
 *  @param checkoutId           The checkout id associated with this transaction.
 *  @param signatureDelegate    The delegate class which will receive the response(s) for this call.
 */
- (void) storeSignatureImage:(UIImage *)image
               forCheckoutId:(NSString *)checkoutId
           signatureDelegate:(id<WPSignatureDelegate>) signatureDelegate;

///@}

@end


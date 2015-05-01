//
//  WPConfig.h
//  WePay
//
//  Created by Chaitanya Bagaria on 11/7/14.
//  Copyright (c) 2014 WePay. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * The configuration object used for initializing a \ref WePay instance.
 */
@interface WPConfig : NSObject

/**
 *  Your WePay clientId for the specified environment
 */
@property (nonatomic, strong, readonly) NSString *clientId;

/**
 *  The environment to be used, one of (staging, production)
 */
@property (nonatomic, strong, readonly) NSString *environment;

/**
 *  Your Apple Pay merchant Id
 */
@property (nonatomic, strong, readonly) NSString *applePayMerchantId;

/**
 *  Determines if we should use location services. Defaults to NO.
 */
@property (nonatomic, assign) BOOL useLocation;

/**
 *  Determines if the swiper should automatically restart after a successful swipe. Defaults to NO.
 */
@property (nonatomic, assign) BOOL restartSwiperAfterSuccess;

/**
 *  Determines if the swiper should automatically restart after a general error (domain:kWPErrorCategorySwiper, errorCode:WPErrorSwiperGeneralError). Defaults to YES.
 */
@property (nonatomic, assign) BOOL restartSwiperAfterSwipeGeneralError;

/**
 *  Determines if the swiper should automatically restart after an error other than general error. Defaults to NO.
 */
@property (nonatomic, assign) BOOL restartSwiperAfterSwipeOtherErrors;

/**
 *  A convenience initializer
 *
 *  @param clientId    Your WePay clientId.
 *  @param environment The environment to be used, one of (kWPEnvironmentStage, kWPEnvironmentProduction).
 *
 *  @return A \ref WPConfig instance which can be used to initialize a \ref WePay instance.
 */
- (instancetype) initWithClientId:(NSString *)clientId
                      environment:(NSString *)environment;

/**
 *  The designated initializer
 *
 *  @param clientId                             Your WePay clientId.
 *  @param environment                          The environment to be used, one of (kWPEnvironmentStage, kWPEnvironmentProduction).
 *  @param applePayMerchantId                   Your Apple Pay merchant Id.
 *  @param useLocation                          Flag to determine if we should use location services.
 *  @param restartSwiperAfterSuccess            Flag to determine if the swiper should automatically restart after a successful swipe.
 *  @param restartSwiperAfterSwipeGeneralError  Flag to determine if the swiper should automatically restart after a general error (domain:kWPErrorCategorySwiper, errorCode:WPErrorSwiperGeneralError).
 *  @param restartSwiperAfterSwipeOtherErrors   Flag to determine if the swiper should automatically restart after an error other than general error.
 *
 *  @return A \ref WPConfig instance which can be used to initialize a \ref WePay instance.
 */
- (instancetype) initWithClientId:(NSString *)clientId
                      environment:(NSString *)environment
               applePayMerchantId:(NSString *)applePayMerchantId
                      useLocation:(BOOL)useLocation
        restartSwiperAfterSuccess:(BOOL)restartSwiperAfterSuccess
restartSwiperAfterSwipeGeneralError:(BOOL)restartSwiperAfterSwipeGeneralError
restartSwiperAfterSwipeOtherErrors:(BOOL)restartSwiperAfterSwipeOtherErrors;

@end

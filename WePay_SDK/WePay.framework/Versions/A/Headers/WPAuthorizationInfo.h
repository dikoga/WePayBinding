//
//  WPAuthorizationInfo.h
//  WePay
//
//  Created by Chaitanya Bagaria on 7/17/15.
//  Copyright (c) 2015 WePay. All rights reserved.
//

#import "WPPaymentToken.h"

/**
 *  A \ref WPAuthorizationInfo represents authorization information that was obtained from the user's EMV card and is stored on WePay's servers. This information can be used to complete the payment transaction via WePay's web APIs.
 */
@interface WPAuthorizationInfo : WPPaymentToken

/**
 *  The amount that was authorized.
 */
@property (nonatomic, readonly) double amount;

/**
 *  The currency code that the amount is specified in.
 */
@property (nonatomic, strong, readonly) NSString* currencyCode;

/**
 *  The transaction token that certifies the transaction.
 */
@property (nonatomic, strong, readonly) NSString* transactionToken;

/**
 *  Initializes a \ref WPAuthorizationInfo with the info provided.
 *
 *  @param amount           The amount that was authorized.
 *  @param currencyCode     The currency code that the amount is specified in.
 *  @param transactionToken The transaction token that certifies the transaction
 *  @param tokenId          The ID of the payment token.
 *
 *  @return A \ref WPAuthorizationInfo object initialized with the info provided.
 */
- (instancetype) initWithAmount:(double) amount
                   currencyCode:(NSString *)currencyCode
               transactionToken:(NSString *)transactionToken
                        tokenId:(NSString* )tokenId;


@end

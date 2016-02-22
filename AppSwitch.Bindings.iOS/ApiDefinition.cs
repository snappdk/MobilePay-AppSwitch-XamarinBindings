using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using CoreGraphics;
using CoreImage;

namespace MobilePay {

	// @interface MobilePayPayment : NSObject
	[BaseType (typeof(NSObject))]
	interface MobilePayPayment
	{
		// @property (nonatomic, strong) NSString * orderId;
		[Export ("orderId", ArgumentSemantic.Strong)]
		string OrderId { get; set; }

		// @property (nonatomic) float productPrice;
		[Export ("productPrice")]
		float ProductPrice { get; set; }

	//	// @property (nonatomic, strong) NSString * productName __attribute__((deprecated("")));
	//	[Export ("productName", ArgumentSemantic.Strong)]
	//	string ProductName { get; set; }
	//
	//	// @property (nonatomic, strong) UIImage * productImage __attribute__((deprecated("")));
	//	[Export ("productImage", ArgumentSemantic.Strong)]
	//	UIImage ProductImage { get; set; }
	//
	//	// @property (nonatomic, strong) NSString * receiptMessage __attribute__((deprecated("")));
	//	[Export ("receiptMessage", ArgumentSemantic.Strong)]
	//	string ReceiptMessage { get; set; }

		// @property (nonatomic, strong) NSString * bulkRef;
		[Export ("bulkRef", ArgumentSemantic.Strong)]
		string BulkRef { get; set; }

		// -(MobilePayPayment *)initWithOrderId:(NSString *)orderId productPrice:(float)productPrice;
		[Export ("initWithOrderId:productPrice:")]
		IntPtr Constructor (string orderId, float productPrice);
	}

	// @interface MobilePaySuccessfulPayment : NSObject
	[BaseType (typeof(NSObject))]
	interface MobilePaySuccessfulPayment
	{
		// @property (readonly, nonatomic, strong) NSString * orderId;
		[Export ("orderId", ArgumentSemantic.Strong)]
		string OrderId { get; }

		// @property (readonly, nonatomic, strong) NSString * transactionId;
		[Export ("transactionId", ArgumentSemantic.Strong)]
		string TransactionId { get; }

		// @property (readonly, nonatomic, strong) NSString * signature;
		[Export ("signature", ArgumentSemantic.Strong)]
		string Signature { get; }

		// @property (readonly, nonatomic) float productPrice;
		[Export ("productPrice")]
		float ProductPrice { get; }

		// @property (readonly, nonatomic) float amountWithdrawnFromCard;
		[Export ("amountWithdrawnFromCard")]
		float AmountWithdrawnFromCard { get; }

		// -(instancetype)initWithOrderId:(NSString *)orderId transactionId:(NSString *)transactionId signature:(NSString *)signature productPrice:(float)productPrice amountWithdrawnFromCard:(float)amountWithdrawnFromCard;
		[Export ("initWithOrderId:transactionId:signature:productPrice:amountWithdrawnFromCard:")]
		IntPtr Constructor (string orderId, string transactionId, string signature, float productPrice, float amountWithdrawnFromCard);
	}

	// @interface MobilePayCancelledPayment : NSObject
	[BaseType (typeof(NSObject))]
	interface MobilePayCancelledPayment
	{
		// @property (readonly, nonatomic, strong) NSString * orderId;
		[Export ("orderId", ArgumentSemantic.Strong)]
		string OrderId { get; }

		// -(instancetype)initWithOrderId:(NSString *)orderId;
		[Export ("initWithOrderId:")]
		IntPtr Constructor (string orderId);
	}

	// typedef void (^MobilePayPaymentErrorBlock)(NSError * _Nonnull);
	delegate void MobilePayPaymentErrorBlock (NSError arg0);

	// typedef void (^MobilePayCallbackSuccessBlock)(NSString * _Nullable, NSString * _Nullable, NSString * _Nullable);
	delegate void MobilePayCallbackSuccessBlock ([NullAllowed] string arg0, [NullAllowed] string arg1, [NullAllowed] string arg2);

	// typedef void (^MobilePayCallbackErrorBlock)(NSString * _Nullable, int, NSString * _Nullable);
	delegate void MobilePayCallbackErrorBlock ([NullAllowed] string arg0, int arg1, [NullAllowed] string arg2);

	// typedef void (^MobilePayCallbackCancelBlock)(NSString * _Nullable);
	delegate void MobilePayCallbackCancelBlock ([NullAllowed] string arg0);

	// typedef void (^MobilePayPaymentSuccessBlock)(MobilePaySuccessfulPayment * _Nullable);
	delegate void MobilePayPaymentSuccessBlock ([NullAllowed] MobilePaySuccessfulPayment arg0);

	// typedef void (^MobilePayPaymentCancelledBlock)(MobilePayCancelledPayment * _Nullable);
	delegate void MobilePayPaymentCancelledBlock ([NullAllowed] MobilePayCancelledPayment arg0);

	// @interface MobilePayManager : NSObject
	[BaseType (typeof(NSObject))]
	interface MobilePayManager
	{
		// +(MobilePayManager * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MobilePayManager SharedInstance { get; }

	//	// -(void)setupWithMerchantId:(NSString * _Nonnull)merchantId merchantUrlScheme:(NSString * _Nonnull)merchantUrlScheme __attribute__((deprecated("Use setupWithMerchantId:(NSString * __nonnull)merchantId merchantUrlScheme:(NSString * __nonnull)merchantUrlScheme country:(Country __nonnull)country instead")));
	//	[Export ("setupWithMerchantId:merchantUrlScheme:")]
	//	void SetupWithMerchantId (string merchantId, string merchantUrlScheme);

		// -(void)setupWithMerchantId:(NSString * _Nonnull)merchantId merchantUrlScheme:(NSString * _Nonnull)merchantUrlScheme country:(MobilePayCountry)country;
		[Export ("setupWithMerchantId:merchantUrlScheme:country:")]
		void Setup (string merchantId, string merchantUrlScheme, MobilePayCountry country);

	//	// -(void)setupWithMerchantId:(NSString * _Nonnull)merchantId merchantUrlScheme:(NSString * _Nonnull)merchantUrlScheme timeoutSeconds:(int)timeoutSeconds returnSeconds:(int)returnSeconds capture:(BOOL)capture __attribute__((deprecated("Use setupWithMerchantId:merchantUrlScheme:timeoutSeconds:returnSeconds:captureType: method instead.")));
	//	[Export ("setupWithMerchantId:merchantUrlScheme:timeoutSeconds:returnSeconds:capture:")]
	//	void SetupWithMerchantId (string merchantId, string merchantUrlScheme, int timeoutSeconds, int returnSeconds, bool capture);

		// -(void)setupWithMerchantId:(NSString * _Nonnull)merchantId merchantUrlScheme:(NSString * _Nonnull)merchantUrlScheme timeoutSeconds:(int)timeoutSeconds returnSeconds:(int)returnSeconds captureType:(MobilePayCaptureType)captureType country:(MobilePayCountry)country;
		[Export ("setupWithMerchantId:merchantUrlScheme:timeoutSeconds:returnSeconds:captureType:country:")]
		void Setup (string merchantId, string merchantUrlScheme, int timeoutSeconds, int returnSeconds, MobilePayCaptureType captureType, MobilePayCountry country);

	//	// -(void)beginMobilePaymentWithOrderId:(NSString * _Nonnull)orderId productPrice:(float)productPrice receiptMessage:(NSString * _Nullable)receiptMessage error:(MobilePayPaymentErrorBlock _Nullable)errorBlock __attribute__((deprecated("Use beginMobilePaymentWithPayment: method instead.")));
	//	[Export ("beginMobilePaymentWithOrderId:productPrice:receiptMessage:error:")]
	//	void BeginMobilePaymentWithOrderId (string orderId, float productPrice, [NullAllowed] string receiptMessage, [NullAllowed] MobilePayPaymentErrorBlock errorBlock);

		// -(void)beginMobilePaymentWithOrderId:(NSString * _Nonnull)orderId productName:(NSString * _Nullable)productName productPrice:(float)productPrice productImage:(UIImage * _Nullable)productImage receiptMessage:(NSString * _Nullable)receiptMessage error:(MobilePayPaymentErrorBlock _Nullable)errorBlock __attribute__((deprecated("Use beginMobilePaymentWithPayment: method instead.")));
		[Export ("beginMobilePaymentWithOrderId:productName:productPrice:productImage:receiptMessage:error:")]
		void BeginMobilePayment (string orderId, [NullAllowed] string productName, float productPrice, [NullAllowed] UIImage productImage, [NullAllowed] string receiptMessage, [NullAllowed] MobilePayPaymentErrorBlock errorBlock);

		// -(void)beginMobilePaymentWithPayment:(MobilePayPayment * _Nonnull)payment error:(MobilePayPaymentErrorBlock _Nullable)errorBlock;
		[Export ("beginMobilePaymentWithPayment:error:")]
		void BeginMobilePayment (MobilePayPayment payment, [NullAllowed] MobilePayPaymentErrorBlock errorBlock);

//		// -(void)handleMobilePayCallbacksWithUrl:(NSURL * _Nonnull)url success:(MobilePayCallbackSuccessBlock _Nonnull)successBlock error:(MobilePayCallbackErrorBlock _Nullable)errorBlock cancel:(MobilePayCallbackCancelBlock _Nullable)cancelBlock __attribute__((deprecated("Use handleMobilePayCallbacksWithUrl:(NSURL * __nonnull)url success:(__nonnull MobilePaySuccessfulPayment)successfulBlock error:(__nullable MobilePayCallbackErrorBlock)errorBlock cancel:(__nullable MobilePayCallbackCancelBlock)cancelBlock instead")));
//		[Export ("handleMobilePayCallbacksWithUrl:success:error:cancel:")]
//		void HandleMobilePayCallbacks (NSUrl url, MobilePayCallbackSuccessBlock successBlock, [NullAllowed] MobilePayCallbackErrorBlock errorBlock, [NullAllowed] MobilePayCallbackCancelBlock cancelBlock);

		// -(void)handleMobilePayPaymentWithUrl:(NSURL * _Nonnull)url success:(MobilePayPaymentSuccessBlock _Nullable)successfulBlock error:(MobilePayPaymentErrorBlock _Nullable)errorBlock cancel:(MobilePayPaymentCancelledBlock _Nullable)cancelBlock;
		[Export ("handleMobilePayPaymentWithUrl:success:error:cancel:")]
		void HandleMobilePayPayment (NSUrl url, [NullAllowed] MobilePayPaymentSuccessBlock successfulBlock, [NullAllowed] MobilePayPaymentErrorBlock errorBlock, [NullAllowed] MobilePayPaymentCancelledBlock cancelBlock);

		// -(BOOL)isMobilePayInstalled:(MobilePayCountry)country;
		[Export ("isMobilePayInstalled:")]
		bool IsMobilePayInstalled (MobilePayCountry country);

	//	// @property (nonatomic) BOOL capture __attribute__((deprecated("Use captureType property instead.")));
	//	[Export ("capture")]
	//	bool Capture { get; set; }

		// @property (nonatomic) MobilePayCaptureType captureType;
		[Export ("captureType", ArgumentSemantic.Assign)]
		MobilePayCaptureType CaptureType { get; set; }

		// @property (nonatomic) MobilePayCountry country;
		[Export ("country", ArgumentSemantic.Assign)]
		MobilePayCountry Country { get; set; }

	//	// @property (readonly, nonatomic) ErrorCode errorCode __attribute__((deprecated("Use MobilePayErrorCode instead.")));
	//	[Export ("errorCode")]
	//	ErrorCode ErrorCode { get; }

		// @property (readonly, nonatomic) MobilePayErrorCode mobilePayErrorCode;
		[Export ("mobilePayErrorCode")]
		MobilePayErrorCode MobilePayErrorCode { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull sdkVersion;
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// @property (nonatomic) NSString * _Nullable merchantId;
		[NullAllowed, Export ("merchantId")]
		string MerchantId { get; set; }

		// @property (nonatomic) int timeoutSeconds;
		[Export ("timeoutSeconds")]
		int TimeoutSeconds { get; set; }

		// @property (nonatomic) int returnSeconds;
		[Export ("returnSeconds")]
		int ReturnSeconds { get; set; }

	//	// @property (readonly, nonatomic) BOOL isMobilePayInstalled __attribute__((deprecated("Use isMobilePayInstalled:(MobilePayCountry)country instead.")));
	//	[Export ("isMobilePayInstalled")]
	//	bool IsMobilePayInstalled { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull mobilePayAppStoreLinkDK;
		[Export ("mobilePayAppStoreLinkDK")]
		string MobilePayAppStoreLinkDK { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull mobilePayAppStoreLinkNO;
		[Export ("mobilePayAppStoreLinkNO")]
		string MobilePayAppStoreLinkNO { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull mobilePayAppStoreLinkFI;
		[Export ("mobilePayAppStoreLinkFI")]
		string MobilePayAppStoreLinkFI { get; }

		// @property (readonly, nonatomic) BOOL isAppSwitchInProgress;
		[Export ("isAppSwitchInProgress")]
		bool IsAppSwitchInProgress { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull signatureVersion;
		[Export ("signatureVersion")]
		string SignatureVersion { get; }
//
//		// -(void)setCertificate:(NSString * _Nonnull)certificate;
//		[Export ("setCertificate:")]
//		void SetCertificate (string certificate);
//
//		// -(void)setMobilePayUrlScheme:(NSString * _Nonnull)mobilePayUrlScheme;
//		[Export ("setMobilePayUrlScheme:")]
//		void SetMobilePayUrlScheme (string mobilePayUrlScheme);
	}

}
using System;
using ObjCRuntime;

namespace MobilePay {
	//[Native]
	//public enum ErrorCode : nint
	//{
	//	Unknown = 0,
	//	InvalidParameters = 1,
	//	MerchantValidationFailed = 2,
	//	UpdateApp = 3,
	//	MerchantNotValid = 4,
	//	HMACNotValid = 5,
	//	TimeOut = 6,
	//	LimitsExceeded = 7,
	//	MerchantTimeout = 8,
	//	InvalidSignature = 9,
	//	SDKIsOutdated = 10,
	//	OrderIdAlreadyUsed = 11,
	//	PaymentRejectedFraud = 12
	//}

	[Native]
	public enum MobilePayErrorCode : long
	{
		Unknown = 0,
		InvalidParameters = 1,
		MerchantValidationFailed = 2,
		UpdateApp = 3,
		MerchantNotValid = 4,
		HMACNotValid = 5,
		TimeOut = 6,
		LimitsExceeded = 7,
		MerchantTimeout = 8,
		InvalidSignature = 9,
		SDKIsOutdated = 10,
		OrderIdAlreadyUsed = 11,
		PaymentRejectedFraud = 12
	}

	[Native]
	public enum MobilePayCaptureType : long
	{
		Capture = 0,
		Reserve = 1,
		PartialCapture = 2
	}

	[Native]
	public enum MobilePayCountry : long
	{
		Denmark = 0,
		Norway = 1,
		Finland = 2
	}

}
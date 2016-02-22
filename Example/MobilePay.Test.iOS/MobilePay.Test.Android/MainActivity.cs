using Android.App;
using Android.Widget;
using Android.OS;
using DK.Danskebank.Mobilepay.Sdk;
using DK.Danskebank.Mobilepay.Sdk.Model;
using Java.Math;
using Android.Content;

namespace MobilePay.Test.Android
{
	[Activity (Label = "MobilePay Test", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private DK.Danskebank.Mobilepay.Sdk.MobilePay _mobilePay;
		private MobilePayCallback _mobilePayCallback;

		private const int MOBILEPAY_PAYMENT_REQUEST_CODE = 1337;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			_mobilePay = DK.Danskebank.Mobilepay.Sdk.MobilePay.Instance;
			_mobilePay.Init ("APPDK0000000000", Country.Denmark);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button button = FindViewById<Button> (Resource.Id.payButton);
			
			button.Click += delegate {
				if (_mobilePay.IsMobilePayInstalled(Application.Context)) {
					
					var payment = new Payment ();
					payment.ProductPrice = new BigDecimal(42.0f);
					payment.OrderId = "123456";

					var intent = _mobilePay.CreatePaymentIntent (payment);

					StartActivityForResult (intent, MOBILEPAY_PAYMENT_REQUEST_CODE);
				} else {
					var intent = _mobilePay.CreateDownloadMobilePayIntent (Application.Context);
					StartActivity (intent);
				}
			};
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);
			if (requestCode == MOBILEPAY_PAYMENT_REQUEST_CODE) {
				_mobilePayCallback = new MobilePayCallback ();
				_mobilePay.HandleResult ((int)resultCode, data, _mobilePayCallback);
			}
		}

		public class MobilePayCallback : Java.Lang.Object, IResultCallback {
			#region IResultCallback implementation

			public void OnFailure (FailureResult p0)
			{
				var toast = Toast.MakeText (Application.Context, string.Format("MobilePay Error {0}: {1}", p0.ErrorCode, p0.ErrorMessage), ToastLength.Long);
				toast.Show ();
				// The payment failed - show an appropriate error message to the user. Consult the MobilePay class documentation for possible error codes.
			}

			public void OnCancel ()
			{
				var toast = Toast.MakeText (Application.Context, string.Format("MobilePay canceled"), ToastLength.Long);
				toast.Show ();
				// The payment was cancelled.
			}

			public void OnSuccess (SuccessResult p0)
			{
				var toast = Toast.MakeText (Application.Context, string.Format("MobilePay Success - OrderId: {0}, Transaction ID: {1}, Charged: {2}", p0.OrderId, p0.TransactionId, p0.AmountWithdrawnFromCard), ToastLength.Long);
				toast.Show ();
				// The payment succeeded - you can deliver the product.
			}

			#endregion
		}
	}
}



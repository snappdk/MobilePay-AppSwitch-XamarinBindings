using Foundation;
using UIKit;
using MobilePay;

namespace MobilePay.Test.iOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			return true;
		}

		public override bool OpenUrl (UIApplication app, NSUrl url, NSDictionary options)
		{
			HandleMobilePayPayment (url);
			return true;
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			HandleMobilePayPayment (url);
			return true;
		}

		public override bool HandleOpenURL (UIApplication application, NSUrl url)
		{
			HandleMobilePayPayment (url);
			return true;
		}

		private void HandleMobilePayPayment(NSUrl url) {
			MobilePayManager.SharedInstance.HandleMobilePayPayment (url, (successful) => {
				var orderId = successful.OrderId;
				var transactionId = successful.TransactionId;
				var amountCharged = successful.AmountWithdrawnFromCard;

				// Do something useful with this information

				var alert = new UIAlertView("MobilePay Succeeded", string.Format("OrderId: {0}, Transaction ID: {1}, Charged: {2}", orderId, transactionId, amountCharged), null, "OK", null);
				alert.Show();
			}, (error) => {
				var alert = new UIAlertView("MobilePay Failed", string.Format("Error {0}: {1}. {2}", error.Code, error.LocalizedDescription, error.LocalizedFailureReason), null, "OK", null);
				alert.Show();
			}, (cancel) => {
				var alert = new UIAlertView("MobilePay canceled", "You cancled the payment", null, "OK", null);
				alert.Show();
			});
		}
	}
}



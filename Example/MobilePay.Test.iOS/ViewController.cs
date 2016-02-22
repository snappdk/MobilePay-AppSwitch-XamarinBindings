using System;

using UIKit;

namespace MobilePay.Test.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			MobilePayManager.SharedInstance.Setup("APPDK0000000000", "snapptest", MobilePayCountry.Denmark);

			PayButton.TouchUpInside += BeginPayment;
		}

		public void BeginPayment(object sender, EventArgs args) {
			var payment = new MobilePayPayment("123456", 42.0f);

			if (payment != null) {
				MobilePayManager.SharedInstance.BeginMobilePayment (payment, (error) => {
					var alert = new UIAlertView(error.LocalizedDescription, string.Format("Reason: {0}, suggestion: {1}", error.LocalizedFailureReason, error.LocalizedRecoverySuggestion), null, "OK", null);
					alert.Show();
				});
			}
		}
	}
}


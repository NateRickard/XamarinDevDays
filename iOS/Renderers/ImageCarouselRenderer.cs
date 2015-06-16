using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using XamarinDevDaysDemo;
using XamarinDevDaysDemo.iOS;

[assembly: ExportRenderer (typeof(ImageCarousel), typeof(ImageCarouselRenderer))]
namespace XamarinDevDaysDemo.iOS
{
	public class ImageCarouselRenderer : VisualElementRenderer<ImageCarousel>
	{
		UISwipeGestureRecognizer swipeLeftGestureRecognizer;
		UISwipeGestureRecognizer swipeRightGestureRecognizer;

		protected override void OnElementChanged (ElementChangedEventArgs<ImageCarousel> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) {
				if (swipeLeftGestureRecognizer != null) {
					this.RemoveGestureRecognizer (swipeLeftGestureRecognizer);
				}

				if (swipeRightGestureRecognizer != null) {
					this.RemoveGestureRecognizer (swipeRightGestureRecognizer);
				}
			}

			if (e.NewElement != null) {
				swipeLeftGestureRecognizer = new UISwipeGestureRecognizer (Element.OnSwipeLeft);
				swipeLeftGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Left;
				swipeRightGestureRecognizer = new UISwipeGestureRecognizer (Element.OnSwipeRight);
				swipeRightGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Right;

				this.AddGestureRecognizer (swipeLeftGestureRecognizer);
				this.AddGestureRecognizer (swipeRightGestureRecognizer);
			}
		}
	}
}
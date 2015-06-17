using Xamarin.Forms;

namespace XamarinDevDaysDemo
{
	public class MyPage : ContentPage
	{
		public MyPage ()
		{
			var images = new [] {
				new FileImageSource { File = "mickey.png" },
				new FileImageSource { File = "goofy.gif" },
				new FileImageSource { File = "pluto.jpg" }
			};
			
			Content = new StackLayout {
				Children = {
					new Label {
						Text = "Hello Xamarin Dev Days!",
						HorizontalOptions = LayoutOptions.Center,
						TextColor = Color.Black
					},
					new ImageCarousel (images) {
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand
					},
					new Label {
						Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque in nisi nibh.",
						HorizontalOptions = LayoutOptions.Center,
						TextColor = Color.Black
					}
				},
				Spacing = 30,
				Padding = new Thickness (10, 30, 10, 20),
				BackgroundColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
		}
	}
}
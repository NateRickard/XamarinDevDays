using Xamarin.Forms;

namespace XamarinDevDaysDemo
{
	public class MyPage : ContentPage
	{
		public MyPage ()
		{
			var images = new [] {
				new Image { Source = "mickey.png", WidthRequest = 340, HorizontalOptions = LayoutOptions.CenterAndExpand },
				new Image { Source = "goofy.gif", WidthRequest = 340, HorizontalOptions = LayoutOptions.CenterAndExpand },
				new Image { Source = "pluto.jpg", WidthRequest = 340, HorizontalOptions = LayoutOptions.CenterAndExpand }
			};
			
			Content = new StackLayout {
				Children = {
					new Label {
						Text = "Hello Xamarin Dev Days!",
						HorizontalOptions = LayoutOptions.Center,
						TextColor = Color.Black
					},
					new ImageCarousel (images) {
						HorizontalOptions = LayoutOptions.Center
					},
					new Label {
						Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque in nisi nibh.",
						HorizontalOptions = LayoutOptions.Center,
						TextColor = Color.Black
					}
				},
				Spacing = 30,
				Padding = new Thickness (10, 30, 10, 0),
				BackgroundColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
		}
	}
}
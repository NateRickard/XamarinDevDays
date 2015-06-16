using Xamarin.Forms;

namespace XamarinDevDaysDemo
{
	public class MyCarouselPage : CarouselPage
	{
		public MyCarouselPage ()
		{
			var page1 = new ContentPage {
				Content = new StackLayout { 
					Children = {
						new Label {
							Text = "Hello Xamarin Dev Days!  Page 1",
							HorizontalOptions = LayoutOptions.Center,
							TextColor = Color.Black
						},
						new Image {
							Source = "mickey.png",
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
				}
			};
			
			var page2 = new ContentPage {
				Content = new StackLayout { 
					Children = {
						new Label {
							Text = "Hello Xamarin Dev Days!  Page 2",
							HorizontalOptions = LayoutOptions.Center,
							TextColor = Color.Black
						},
						new Image {
							Source = "goofy.gif",
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
				}
			};
			
			var page3 = new ContentPage {
				Content = new StackLayout { 
					Children = {
						new Label {
							Text = "Hello Xamarin Dev Days!  Page 3",
							HorizontalOptions = LayoutOptions.Center,
							TextColor = Color.Black
						},
						new Image {
							Source = "pluto.jpg",
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
				}
			};
			
			Children.Add (page1);
			Children.Add (page2);
			Children.Add (page3);
		}
	}
}
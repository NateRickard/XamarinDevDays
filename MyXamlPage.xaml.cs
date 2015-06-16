using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace XamarinDevDaysDemo
{
	public partial class MyXamlPage : ContentPage
	{
		public MyXamlPage ()
		{
			InitializeComponent ();
			
			this.BindingContext = new MyXamlPageViewModel ();
		}
	}

	public class MyXamlPageViewModel : INotifyPropertyChanged
	{
		public IEnumerable<Image> Images { get; set; }

		public MyXamlPageViewModel ()
		{
			Images = new [] {
				new Image {
					Source = "mickey.png",
					WidthRequest = 340, 
					HorizontalOptions = LayoutOptions.CenterAndExpand
				},
				new Image {
					Source = "goofy.gif",
					WidthRequest = 340,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				},
				new Image {
					Source = "pluto.jpg",
					WidthRequest = 340,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				}
			};

			waitAndAddImage ();
		}

		async void waitAndAddImage ()
		{
			await Task.Delay (3000);

			Images = new [] {
				new Image {
					Source = "mickey.png",
					WidthRequest = 340, 
					HorizontalOptions = LayoutOptions.CenterAndExpand
				},
				new Image {
					Source = "goofy.gif",
					WidthRequest = 340,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				},
				new Image {
					Source = "pluto.jpg",
					WidthRequest = 340,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				},
				new Image {
					Source = "donald.gif",
					WidthRequest = 340,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				}
			};

			OnPropertyChanged (ImageCarousel.ImagesProperty.PropertyName);
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		protected virtual void OnPropertyChanged (string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this,
					new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}
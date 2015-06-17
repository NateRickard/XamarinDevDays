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
		public IEnumerable<FileImageSource> Images { get; set; }

		public MyXamlPageViewModel ()
		{
			Images = new [] {
				new FileImageSource { File = "mickey.png" },
				new FileImageSource { File = "goofy.gif" },
				new FileImageSource { File = "pluto.jpg" }
			};
			
			waitAndAddImage ();
		}

		async void waitAndAddImage ()
		{
			await Task.Delay (3000);
			
			Images = new [] {
				new FileImageSource { File = "mickey.png" },
				new FileImageSource { File = "goofy.gif" },
				new FileImageSource { File = "pluto.jpg" },
				new FileImageSource { File = "donald.gif" }
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
using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace XamarinDevDaysDemo
{
	public class ImageCarousel : AbsoluteLayout
	{
		//The Bindable Images property, if MVVM/binding context is desired
		public static readonly BindableProperty ImagesProperty = BindableProperty.Create<ImageCarousel, IEnumerable<FileImageSource>> (p => p.Images, default(IEnumerable<FileImageSource>));

		public IEnumerable<FileImageSource> Images {
			get { return (IEnumerable<FileImageSource>)GetValue (ImagesProperty); }
			set { SetValue (ImagesProperty, value); }
		}

		//Our interal list - we'll maintain this when the above Images collection is modified and use this to do indexing, etc. that can't be done on an IEnumerable
		List<Image> images;

		List<Image> ImageList {
			get {
				if (images == null) {
					images = new List<Image> ();
				}
				
				return images;
			}
		}

		public Image CurrentImage { get; private set; }

		public ImageCarousel ()
		{
		}

		public ImageCarousel (IEnumerable<FileImageSource> images)
		{
			//setting this triggers OnPropertyChanged below
			Images = images;
		}

		void addImagesAsChildren ()
		{
			Children.Clear ();
			
			//take the current list of Images and add them as children... this will in turn populate ImageList via OnChildAdded below
			var point = Point.Zero;

			foreach (var imageSource in Images) {
				var image = new Image {
					Source = imageSource
				};
				
				this.Children.Add (image, new Rectangle (point, new Size (1, 1)), AbsoluteLayoutFlags.SizeProportional);
				point = new Point (point.X + image.Width, 0);
			}
		}

		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			base.LayoutChildren (x, y, width, height);
		
			//fix layout issues caused by base behavior, make sure these things are in the right place before swiping begins
			var point = Point.Zero;
		
			foreach (var image in ImageList) {
				image.Layout (new Rectangle (point, image.Bounds.Size));
				point = new Point (point.X + image.Width, 0);
			}
		}

		protected override void OnPropertyChanged (string propertyName = null)
		{
			base.OnPropertyChanged (propertyName);

			//if the Images property has changed, clear our ImageList of images and add all the new images as children
			if (propertyName == ImagesProperty.PropertyName) {
				ImageList.Clear ();
				CurrentImage = null;

				addImagesAsChildren ();
			}
		}

		protected override void OnChildAdded (Element child)
		{
			base.OnChildAdded (child);
		
			//each time a child Image is added, add it to the ImageList
			if (child is Image) {
				ImageList.Add ((Image)child);
		
				//set a CurrentImage if we don't already have one
				if (CurrentImage == null) {
					CurrentImage = (Image)child;
				}
			}
		}

		public void OnSwipeLeft ()
		{
			var imageNumber = ImageList.IndexOf (CurrentImage);
			var nextNumber = imageNumber == ImageList.Count - 1 ? 0 : imageNumber + 1;
			var nextImage = ImageList [nextNumber];

			//make sure this image is in position to be animated in
			nextImage.Layout (new Rectangle (new Point (CurrentImage.Width, 0), CurrentImage.Bounds.Size));

			var current = CurrentImage;

			current.LayoutTo (new Rectangle (-CurrentImage.Width, 0, CurrentImage.Width, CurrentImage.Height));
			CurrentImage = nextImage;
			nextImage.LayoutTo (new Rectangle (0, 0, CurrentImage.Width, CurrentImage.Height));
		}

		public void OnSwipeRight ()
		{
			var imageNumber = ImageList.IndexOf (CurrentImage);
			var nextNumber = imageNumber == 0 ? ImageList.Count - 1 : imageNumber - 1;
			var nextImage = ImageList [nextNumber];

			//make sure this image is in position to be animated in
			nextImage.Layout (new Rectangle (new Point (-CurrentImage.Width, 0), CurrentImage.Bounds.Size));

			var current = CurrentImage;

			current.LayoutTo (new Rectangle (CurrentImage.Width, 0, CurrentImage.Width, CurrentImage.Height));
			CurrentImage = nextImage;
			nextImage.LayoutTo (new Rectangle (0, 0, CurrentImage.Width, CurrentImage.Height));
		}
	}
}
using System;

using Xamarin.Forms;

namespace XamarinDevDaysDemo
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
//			MainPage = new MyCarouselPage ();
//			MainPage = new MyPage ();
			MainPage = new MyXamlPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
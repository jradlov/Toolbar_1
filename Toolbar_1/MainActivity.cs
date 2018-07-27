using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;

/*
Visual Studio 2017:
How to create a simple Single View App with a Toolbar & menu
(that works with Android version 4 & up)

File->New->Project...
Visual C#->Android->Android App -> Single View App
Min Android version: 4.0.3 (Ice Cream sandwich)

- Remove Floating Mail Icon & functionality:
1) MainActivity.cs: delete fab button instantiation & FabOnClick()
2) activity_main.axml: delete <FloatingActionButton> section

- Add more menu items & respond to events:
3) menu_main.axml: duplicate <item> to add more items to the menu.
   In new item, change action_settings to action_about, for example),
	& 100 to 200 (100, 200, 300... = top to bottom order of menu items)
4) strings.xml: add strings for new menu items
	Ex: <string name = "action_about">About</string>
5)	MainActivity.cs: respond to menu events in OnOptionsItemSelected()
	Ex: if(id == Resource.Id.action_settings) Console.WriteLine("Settings");
	    else if(id == Resource.Id.action_about) Console.WriteLine("About");
		 
- Now write your app:		 
6) content_main.axml: replace <TextView> with what your app does...
*/


namespace Toolbar_1
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_main);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
		}

		public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            int id = item.ItemId;
				if(id == Resource.Id.action_settings)
					Toast.MakeText(this, "Settings", ToastLength.Short).Show();
				else if (id == Resource.Id.action_about)
					Toast.MakeText(this, "About", ToastLength.Short).Show();

				return base.OnOptionsItemSelected(item);
        }

	}
}


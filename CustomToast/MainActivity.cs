using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using System;

namespace CustomToast
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true,ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawer1;
        ActionBarDrawerToggle toggle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            drawer1 = FindViewById<DrawerLayout>(Resource.Id.drawer);
            toggle = new ActionBarDrawerToggle(this, drawer1, Resource.String.open, Resource.String.close);
            drawer1.AddDrawerListener(toggle);
            toggle.SyncState();
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.Title = "Application Name";


            //handling button click event
            Button customtoast = FindViewById<Button>(Resource.Id.clickme);
            customtoast.Click += delegate
            {
                //calling the custom toast method on button click
                ShowCustomToast();
            };
            

        }

        //declaring a custom toast method
        void ShowCustomToast()
        {
            var t = Toast.MakeText(this, "fdhdsfhd", ToastLength.Long);
            t.SetGravity(GravityFlags.Bottom | GravityFlags.FillHorizontal,0,0);
            View toastview = LayoutInflater.Inflate(Resource.Layout.custom_toast, null);
            t.View = toastview;
            t.Show();
        }

        //when the actionbar drawer toggle to click
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int i = item.ItemId;

            if(i==Android.Resource.Id.Home)
            {
                //checking if the drawer is already opened
                if(drawer1.IsDrawerOpen(GravityCompat.Start))
                {
                    drawer1.CloseDrawers();
                }
                //otherwise
                else
                {
                    drawer1.OpenDrawer(GravityCompat.Start);
                }
            }
            return base.OnOptionsItemSelected(item);
        }


        //overflow action menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionMenu, menu );
            return base.OnCreateOptionsMenu(menu);
        }
    }
}
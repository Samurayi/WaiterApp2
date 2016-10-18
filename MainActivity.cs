using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WaiterApp
{
    [Activity(Label = "WaiterApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            
            Button tables = FindViewById<Button>(Resource.Id.ToTables);
            Button settings = FindViewById<Button>(Resource.Id.Statistics);
            Button priceList = FindViewById<Button>(Resource.Id.PriceList);

            tables.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(Tables));
                StartActivity(intent);
            };

            priceList.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(PriceList));
                StartActivity(intent);
            };

            settings.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(settings));
                StartActivity(intent);
            };
        }
        
        
    }
}


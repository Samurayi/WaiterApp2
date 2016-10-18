using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.Res;


namespace WaiterApp
{
    [Activity(Label = "PriceList")]
    public class PriceList : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.priceList);


            Button addNew = FindViewById<Button>(Resource.Id.addNew);
            Button mdItem = FindViewById<Button>(Resource.Id.mdItem);
            var listview = FindViewById<ListView>(Resource.Id.itemView);

            //SaveAndLoad.DeleteText("priceList.txt");
            /*ItemPrice kava = new ItemPrice("Kava", 1);
            ItemPrice kavaMleko = new ItemPrice("Kava z mlekom", 1.2);
            ItemPrice kavaSmetana = new ItemPrice("Kava s smetano", 1.4);
            kava.WriteToFile();
            kavaMleko.WriteToFile();
            kavaSmetana.WriteToFile();
            */

            
            listview.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, ItemPrice.PriceListLines("priceList.txt"));

            addNew.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(addNew));
                StartActivity(intent);
            };

            mdItem.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(Modify));
                StartActivity(intent);
            };
        }
        protected override void OnResume()
        {
            base.OnResume();
            Button addNew = FindViewById<Button>(Resource.Id.addNew);
            Button mdItem = FindViewById<Button>(Resource.Id.mdItem);
            var listview = FindViewById<ListView>(Resource.Id.itemView);

            listview.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, ItemPrice.PriceListLines("priceList.txt"));
        }
    }
}
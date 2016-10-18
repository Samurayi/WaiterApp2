using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WaiterApp
{
    [Activity(Label = "Invoice")]
    public class Invoice : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Invoice);

            var text = FindViewById<TextView>(Resource.Id.text);

            string fileName = Intent.GetStringExtra("fileName");
            text.Text = SaveAndLoad.LoadText(fileName);
            
        }
    }
}
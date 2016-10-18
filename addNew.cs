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
    [Activity(Label = "addNew")]
    public class addNew : Activity
    {
        private double price;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddNew);

            var itemBar = FindViewById<EditText>(Resource.Id.itemBar);
            var priceBar = FindViewById<EditText>(Resource.Id.priceBar);
            var saveButton = FindViewById<Button>(Resource.Id.saveButton);

            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            Dialog dialog;
            ItemPrice item;
            saveButton.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    price = double.Parse(priceBar.Text.Replace(',','.'));
                    item = new ItemPrice(itemBar.Text, price);
                    item.WriteToFile();

                    OnBackPressed();
                }
                catch (Exception f)
                {
                    alert.SetMessage("Price bar requires a number or a decimal number separated by a dot or coma.");
                    dialog = alert.Create();
                    dialog.Show();

                }
                
            };
        }
    }
}
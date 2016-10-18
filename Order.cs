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
    [Activity(Label = "Order")]
    public class Order : Activity
    {
        private int tNumber;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.order);

            var createAdd = FindViewById<Button>(Resource.Id.createAdd);
            var itemList = FindViewById<ListView>(Resource.Id.orderView);
            var closeOrder = FindViewById<Button>(Resource.Id.closeOrder);
            var tnText = FindViewById<TextView>(Resource.Id.tableNumber);
            var viewLast = FindViewById<Button>(Resource.Id.viewLast);
            if (tNumber == 0)
            {
                tNumber = Intent.GetIntExtra("tableNumber", 0);
            }


            tnText.Text = "Table number " + tNumber;

           

            createAdd.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(itemChoose));
                intent.PutExtra("tNumber", tNumber);
                StartActivity(intent);
            };

            closeOrder.Click += (object sender, EventArgs e) =>
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Are you sure you want to close this order?");
                builder.SetCancelable(false);
                builder.SetPositiveButton("Print invoice", (s, f) =>
                {
                    PrintInvoice invoice = new PrintInvoice();
                    invoice.Print(ItemPrice.tableFile + tNumber);
                    invoice.Output();
                    SaveAndLoad.DeleteText(ItemPrice.tableFile + tNumber);

                });
                
                builder.SetNegativeButton("Cancel", (s, f) => { });
                builder.Create().Show();
            };
            viewLast.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(Invoice));
                intent.PutExtra("fileName", ItemPrice.tableFile + tNumber + " invoice");
                StartActivity(intent);
            };


        }
        protected override void OnResume()
        {
            base.OnResume();
            var createAdd = FindViewById<Button>(Resource.Id.createAdd);
            var itemList = FindViewById<ListView>(Resource.Id.orderView);
            var closeOrder = FindViewById<Button>(Resource.Id.closeOrder);
            var viewLast = FindViewById<Button>(Resource.Id.viewLast);
            string[] order = ItemPrice.OrderWiev(ItemPrice.tableFile + tNumber);

            itemList.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, order);
            if (itemList.Adapter.Count == 0)
            {
                createAdd.Text = "Create new order";
                closeOrder.Clickable = false;
            }
            else
            {
                createAdd.Text = "Add item";
                closeOrder.Clickable = true;
            }
        }

    }

}
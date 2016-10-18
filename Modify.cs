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
    [Activity(Label = "Modify")]
    public class Modify : ListActivity
    {
        //private List<string> itemList = ItemPrice.PriceListLines("priceList.txt").ToList();
        private string vholeList;
        private string[] itemL = ItemPrice.PriceListLines(ItemPrice.fileName);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            var listModify = FindViewById<ListView>(Resource.Id.listModify);


            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, itemL);
        }
        protected override void OnListItemClick(ListView listModify, View v, int position, long id)
        {
            string t = itemL[position];
            
            char[] a = new char[] { '€', '.', ',', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '?' };
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Delete or modify");
            //builder.SetMessage("Are you sure you want to delete " + t.TrimEnd(a) + "?");
            builder.SetCancelable(false);
            builder.SetPositiveButton("Delete", (s, e) =>
            {
                itemL[position] = null;
                foreach (string b in itemL)
                {
                    if (!string.IsNullOrEmpty(b))
                    {
                        vholeList = vholeList + b + ";";
                    }
                }
                SaveAndLoad.ReplaceText(ItemPrice.fileName, vholeList);
                //ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, itemL);
                this.Recreate();

            });
            builder.SetNeutralButton("Modify", (s, e) =>
             {
                 var intent = new Intent(this, typeof(ModifyItem));
                 intent.PutExtra("item", t);
                 intent.PutExtra("line", position);
                 StartActivity(intent);
             });
            builder.SetNegativeButton("Cancel", (s, e) => { });
            builder.Create().Show();

        }
        protected override void OnResume()
        {
            base.OnResume();
            var listModify = FindViewById<ListView>(Resource.Id.listModify);

            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, itemL);
        }

    }
}
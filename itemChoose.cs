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
    [Activity(Label = "itemChoose")]
    public class itemChoose : ListActivity
    {
        private int tNumber;
        private string[] itemL = ItemPrice.PriceListLines(ItemPrice.fileName);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            tNumber = Intent.GetIntExtra("tNumber", 0);

            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, itemL);

        }

        protected override void OnListItemClick(ListView listModify, View v, int position, long id)
        {
            string t = itemL[position];
            SaveAndLoad.SaveText(ItemPrice.tableFile + tNumber, t + ";");

            OnBackPressed();

        }
    }
}
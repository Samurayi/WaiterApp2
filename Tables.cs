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
     
    [Activity(Label = "Tables")]
    public class Tables : ListActivity
    {
        string[] tableList;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //SetContentView(Resource.Layout.tables);
            var tables = FindViewById<ListView>(Resource.Id.tables);
            tableList = new string[10];
            for(int i = 0; i<10; i++)
            {
                tableList[i] = "Table " + (i + 1).ToString();
            }
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, tableList);

        }
        protected override void OnListItemClick(ListView listModify, View v, int position, long id)
        {

            var intent = new Intent(this, typeof(Order));
            intent.PutExtra("tableNumber", position+1);
            StartActivity(intent);


        }
    }
}
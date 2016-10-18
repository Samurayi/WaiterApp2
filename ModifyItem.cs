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
    [Activity(Label = "ModifyItem")]
    public class ModifyItem : Activity
    {
        private string[] itemList = ItemPrice.PriceListLines(ItemPrice.fileName);
        private string vholeText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.modifyItem);

            string text = Intent.GetStringExtra("item");
            int line = Intent.GetIntExtra("line", 0);

            var modifyText = FindViewById<EditText>(Resource.Id.Modify);
            var saveButton = FindViewById<Button>(Resource.Id.Save);
            modifyText.Text = text;

            saveButton.Click += (object sender, EventArgs e) =>
            {               
                itemList[line] = modifyText.Text;
                foreach(string b in itemList)
                {
                    if (!string.IsNullOrEmpty(b))
                    {
                        vholeText = vholeText + b + ';';
                    }
                }
                SaveAndLoad.ReplaceText(ItemPrice.fileName, vholeText);

                OnBackPressed();
            };

        }
    }
}
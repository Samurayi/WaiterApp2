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

namespace WaiterApp
{
    class ItemPrice
    {
        public static string invoiceFile = "invoiceTable ";
        public static string tableFile = "tableOrder ";
        public static string fileName = "priceList.txt";
        public static string[] itemList;
        private string name;
        private double price;

        
        public ItemPrice(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public string StringOutput()
        {
            return name +" "+ price.ToString() + "€ ;";
            
        }
        public void WriteToFile()
        {
            SaveAndLoad.SaveText(ItemPrice.fileName, StringOutput());
            
        }
        public static string[] PriceListLines(string filename)
        {
            string fileContent = SaveAndLoad.LoadText(filename);
            itemList = fileContent.Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(itemList);
            return itemList;
            
        }
        public static string[] OrderWiev(string filename)
        {
            int countInOrder = 1;
            string fileContent = SaveAndLoad.LoadText(filename);
            itemList = fileContent.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> itemList2 = itemList.ToList();
            List<string> itemList3 = new List<string>();
            
            itemList2.Sort();
            itemList2.Add(" ");
            for (int i = 0; i < itemList2.Count-1; i++)
            {

                if (itemList2[i] == itemList2[i + 1])
                {
                    countInOrder++;
                    
                }
                else
                {
                    itemList3.Add(countInOrder + " " + itemList2[i]);
                    countInOrder = 1;
                }
                
            }
            
            return itemList3.ToArray();
        }
    }
}
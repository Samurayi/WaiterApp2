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
    class PrintInvoice
    {
        public long invNumber;
        public string fileName;
        private List<string> itemList = new List<string>();

        public List<string> Print(string fileName)
        {
            this.fileName = fileName + " invoice";
            SaveAndLoad.DeleteText(this.fileName);
            itemList = ItemPrice.OrderWiev(fileName).ToList();

           
            return itemList;
        }
        public void Output()
        {
            string c = SaveAndLoad.LoadText("InvNumber");
            if(String.IsNullOrEmpty(c))
            {
                invNumber = 10000001;
            }
            else
            {
                invNumber = long.Parse(c);
            }

            invNumber += 1;
            SaveAndLoad.ReplaceText("InvNumber", invNumber.ToString());

            SaveAndLoad.SaveText(fileName, "Bar Dijana d.o.o "+System.Environment.NewLine);
            SaveAndLoad.SaveText(fileName, "Cesta Staneta Žagarja 49, 4000 Kranj "+System.Environment.NewLine);
            SaveAndLoad.SaveText(fileName, "ID za DDV: SI293842734 "+System.Environment.NewLine);
            SaveAndLoad.SaveText(fileName, "-------------------------------------"+ System.Environment.NewLine);
            for(int i = 0; i<itemList.Count;i++)
            {
                SaveAndLoad.SaveText(fileName, itemList[i]+ System.Environment.NewLine);
            }
            SaveAndLoad.SaveText(fileName, "-------------------------------------"+ System.Environment.NewLine);
            SaveAndLoad.SaveText(fileName, "Za plaèilo eur: "+TotalPrice()+ System.Environment.NewLine);
            SaveAndLoad.SaveText(fileName, "Št. raèuna: " + invNumber + System.Environment.NewLine);
        }
        private double TotalPrice()
        {
            List<string> b;
            double a = 0;
            double x = 1;
            List<string> list = itemList;
            double totalPrice = 0;
            for(int i = 0; i<itemList.Count; i++)
            {
                list[i] = list[i].TrimEnd(' ','€');
                x = double.Parse(list[i].Split(' ')[0]);
                b = list[i].Split(' ').ToList();
                a = double.Parse(b[b.Count-1]);
                totalPrice = totalPrice + (x * a);
            }
            return totalPrice;
        }
    }
}
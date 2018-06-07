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

namespace App4
{
    [Activity(Label = "secondActivity")]
    public class secondActivity : Activity
    {
        private ArrayAdapter<string> adapter;              // gloobal krdia isko
        private string disply = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.secondlayout);//phly second layout r second acitvity ka relation bnaya ha 1

            string[] name = { "Ali", "Hassan", "Rizwan", "Adeel", "Farry" }; //second pr 5 types array declare ki ha 2
            ListView emplistview = FindViewById<ListView>(Resource.Id.listView1); //listView ko yha access kia ha 3
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, name);// fifth pr arryadapter ka obj ly k ismy asy kam krna h 5
            emplistview.Adapter = adapter;//fourth pr jsy data source ko lty ty wse ismy isko lia ha 4
            emplistview.ItemClick += Emplistview_ItemClick; // six pr emplistview ka event create kia ha 6



            Button secondButton = FindViewById<Button>(Resource.Id.button1);
            secondButton.Click += SecondButton_Click;

            //ye nichy wali 3 line ak form sy dosry form sy data recieve krny  k lye hain
            string textJoMainSyAyga = Intent.GetStringExtra("text"); // string same honi chaia
            EditText editText = FindViewById<EditText>(Resource.Id.editText1);
            editText.Text = textJoMainSyAyga;
        }

        private void Emplistview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string name = adapter.GetItem(e.Position);  //ye lazzmi krna ha
            //string disply = ""; isko gloobal krdia
            if (name == "Ali")
            {
                disply = "Name: Ali Malik";
            }
            if (name == "Hassan")
            {
                disply = "Name: Hassan Malik";

            }
            if (name == "Rizwan")
            {
                disply = "Name: Rizwan Malik";

            }
            if (name == "Adeel")
            {
                disply = "Name: Adeel Arshad";

            }
            if (name == "Farry")
            {
                disply = "Name: Farrukh Javed";

            }
            MessageBox("Information", disply);
        }

        private void MessageBox(string title, string message)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);  //yha .builder k sath lia ha
            AlertDialog alertDialog = builder.Create(); // yha bger builder k sath obj lia ha

            alertDialog.SetTitle(title);
            alertDialog.SetMessage(message);
            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogInfo);
            alertDialog.SetCancelable(false);
            alertDialog.SetButton("OK", OKBOtton); 
            alertDialog.Show();
        }

        private void OKBOtton(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "Enter " + disply + " Record", ToastLength.Long).Show();
        }

        //goto home wala kam
        private void SecondButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}
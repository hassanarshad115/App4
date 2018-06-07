using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace App4
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/H")]
    public class MainActivity : AppCompatActivity
    {

        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //.axml r .cs ko jorny k lye h
            SetContentView(Resource.Layout.main);


            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            // Get our button from the layout resource,
            // and attach an event to it
            //var clickButton = FindViewById<Button>(Resource.Id.my_button);

            //clickButton.Click += (sender, args) =>
            //  {
            //      clickButton.Text = string.Format("{0} clicks!", count++);
            //  };

            //first button pr click kry tw ye second page pr lyjay
            Button firstButton = FindViewById<Button>(Resource.Id.button1);
            firstButton.Click += FirstButton_Click;

            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EditText editText = FindViewById<EditText>(Resource.Id.editText11);

            if(editText.Text == string.Empty)
            {
                Toast.MakeText(this, "TextBox is Empty", ToastLength.Short).Show();
            }
            else
            {
                
                //ye 3 lines data transfer krny k lye h 
                //Toast.MakeText(this, "Text Successfully Submit", ToastLength.Long).Show();
                Intent intentClass = new Intent(this,typeof( secondActivity));
                intentClass.PutExtra("text", editText.Text);
                StartActivity(intentClass);
            }
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(secondActivity));
        }
    }
}


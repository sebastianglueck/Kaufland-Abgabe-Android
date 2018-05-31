using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace GameOfLife
{
    [Activity(Label = "GameOfLife", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;
        ImageView imageView;
        Button button;
        EditText edit; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Startup);

            // Get our button from the layout resource,
            // and attach an event to it
            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            button = FindViewById<Button>(Resource.Id.Startbutton);
            edit = FindViewById<EditText>(Resource.Id.editText1);

            button.Click +=delegate {

                String text = ((EditText)edit).Text;


                if(text.Equals("")){
                    Toast toast =  Toast.MakeText(this, "Bitte Wert eingeben", ToastLength.Long);
                    toast.Show();
                }else {
                    int size = Int32.Parse(text);
                    if(size>20){
                        Toast toast =  Toast.MakeText(this, "Werte nur bis 20 erlaubt!", ToastLength.Long);
                        toast.Show();
                    }else{
                        LaunchGame(size);
                    }

                   
                }
                
               

            };
        }

        public void LaunchGame(int size){

            Intent intent = new Intent(this, typeof(DrawActivity));
            intent.PutExtra("newMap", size);
            StartActivity(intent);
        }

    }
}


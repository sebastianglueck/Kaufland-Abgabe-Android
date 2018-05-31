using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;


namespace GameOfLife
{
    [Activity(Label = "DrawActivity")]
    public class DrawActivity : Activity
    {

        TextView text;
        Button button;
        Button button2;
        Logic logic;
        int number;
        bool[,] test;
      


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            text = FindViewById<TextView>(Resource.Id.textView1);
            button = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            // Create your application here
            int ActivityKey = Intent.Extras.GetInt("newMap");
            number = ActivityKey;
            test = new bool[ActivityKey, ActivityKey];
            logic = new Logic(ActivityKey, ActivityKey);

            if(number >= 10 && number <= 30){
                text.SetTextSize(global::Android.Util.ComplexUnitType.Dip, 20);
            }else if(number<10){
                text.SetTextSize(global::Android.Util.ComplexUnitType.Dip, 45);
            }


            drawMap(test);
            generate();





            button.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();


            };

            button2.Click += delegate {
                button2.SetText("Nächste Generation", TextView.BufferType.Normal);
                text.SetText("",TextView.BufferType.Normal);
                test=start(test);


            };




        }

        public bool[,] start(bool [,] test){
            drawMap(test);
            test=logic.checkRules(test);
            return test;
        }

        public override void OnBackPressed()
        {
            Finish();
        }









        public void drawMap(bool[,] test)
        {
            text.Append("+");
            for (int x = 0; x < test.GetLength(0) * 2; x++)
            {
                text.Append("-");
            }
            text.Append("+ \n");


            for (int x = 0; x < test.GetLength(0); x++)
            {

                text.Append("|");


                for (int y = 0; y < test.GetLength(1); y++)
                {

                    if (test[x, y])
                    {
                        text.Append("X");

                    }
                    else
                    {
                        text.Append("--");
                    }
                }

                text.Append("| \n");


            }

            text.Append("+");
            for (int x = 0; x < test.GetLength(0) * 2; x++)
            {
                text.Append("-");
            }
            text.Append("+ \n");




        }

        public void generate(){
            double numberofpositions;

            numberofpositions = (number * number) * 0.51;


            for (int x = 0; x < numberofpositions; x++)
            {
                Random rnd = new Random();

                int row = rnd.Next(0,test.GetLength(0));
                int col = rnd.Next(0, test.GetLength(0));

                while (test[row, col])
                {
                    row = rnd.Next(0, test.GetLength(0));
                    col = rnd.Next(0, test.GetLength(0));
                }

                test[row, col] = true;



            }
        }

    }
}



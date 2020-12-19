using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Realms;
using Android.Views;
using Android.Content;
using System.Linq;
using System;
namespace astaadg
{
    [Activity(Label = "ASTAADG", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //VARIABLES FOR USER INPUT

        EditText useremail; 

        EditText pwd;

        Button loginButton; 

        Button registerButton;
        
        Realm realmDB; 

        string storeEmail; //VARIABLES FOR DATABASE

        string storePassword;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            realmDB = Realm.GetInstance(); // DATABASE CONNECTION

            useremail = FindViewById<EditText>(Resource.Id.emailID); // CONNECT EMAIL INPUT WITH VARIABLE

            pwd = FindViewById<EditText>(Resource.Id.passwordID); //CONNECT PASSWORD INPUT WITH VARIABLE

            loginButton = FindViewById<Button>(Resource.Id.login); //CONNECT LOGIN INPUT WITH VARIABLE

            loginButton.Click += checkLogin; //ASSIGN LOGIN FUNCTION

            registerButton = FindViewById<Button>(Resource.Id.registerButton); //CONNECT REGISTRATION BUTTON TO VARIABLE

            registerButton.Click += registerPage; // PERFORM FUNCTION ON CLICK 

        }

        private void checkLogin(object sender, System.EventArgs e)
        {
            storeEmail = useremail.Text; //STORE USER INPUT EMAIL IN DATABASE VARIABLE

            storePassword = pwd.Text; //STORE USER PASSWORD IN DATABASE VARIABLE

            if (storeEmail.Trim() == "")
            {
                Toast.MakeText(this, "PLEASE ENTER YOUR EMAIL TO CONTINUE", ToastLength.Long).Show();
            }

            else if (storePassword.Trim() == "")
            {
                Toast.MakeText(this, "PLEASE ENTER YOUR PASSWORD TO CONTINUE", ToastLength.Long).Show();
            }

            else
            {
                var userinfodbObj = realmDB.All<UserInfoDB>().Where(d => d.email == storeEmail.ToLower() && d.password == storePassword);
                var length = userinfodbObj.Count();

                if (length > 0)
                {
                    Intent newFrameScreen = new Intent(this, typeof(Frame));

                    newFrameScreen.PutExtra("useremail", storeEmail);

                    StartActivity(newFrameScreen);
                }

                else
                {
                    Toast.MakeText(this, "NO USER FOUND! PLEASE REGISTER FIRST", ToastLength.Long).Show();
                }
            }
        }  

          private void registerPage (object sender, System.EventArgs e)
            {
                Intent newRegisterScreen = new Intent(this, typeof(Register));

                StartActivity(newRegisterScreen);
            }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

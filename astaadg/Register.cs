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
using Realms;

namespace astaadg
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {

        EditText username;

        EditText useremail;

        EditText phonenumber;

        EditText userage;

        EditText pwd;

        Button registerButton;

        Button returnButton;

        
        Realm realmDB;
        // STORE VALUES INSIDE DATABASE

        string storeNameinDb; // STORES NAME IN DB
        string storeEmail; // STORES USER EMAIL
        string storePhoneNumber; // STORE PHONE NUMBER 
        int storeAge; // STORE AGE 
        string storePassword; // STORE PASSWORD


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            realmDB = Realm.GetInstance();

            username = FindViewById<EditText>(Resource.Id.nameofuserID); // STORE USER NAME IN DB
            useremail = FindViewById<EditText>(Resource.Id.emailID); // STORE USER EMAIL IN DB
            phonenumber =  FindViewById<EditText>(Resource.Id.phonenumberID); // STORE USER PHONE IN DB
            userage = FindViewById<EditText>(Resource.Id.ageID); // STORE USER AGE IN DB
            pwd  =  FindViewById<EditText>(Resource.Id.passwordID); // STORE USER PASSWORD IN DB

            returnButton = FindViewById<Button>(Resource.Id.returnBtnID);
            returnButton.Click += ReturnBtn_Click;

            registerButton = FindViewById<Button>(Resource.Id.registerBtnID);
            registerButton.Click += registerUser;
        }


        private void registerUser(object sender, EventArgs e)
        {
            storeNameinDb = username.Text;

            storeEmail = useremail.Text;

            storePassword = pwd.Text;

            storePhoneNumber = phonenumber.Text;

            //storeAge = (int)userage;

            if (storeEmail.Trim() == "" || storeEmail.Trim() == " ")
            {
                Toast.MakeText(this, "Please Enter Email!", ToastLength.Long).Show();
            }

            else if (storeNameinDb.Trim() == "" || storeNameinDb.Trim() == " ")
            {
                Toast.MakeText(this, "PLEASE ENTER YOUR USERNAME", ToastLength.Long).Show();
            }

            else if (storePassword.Trim() == "" || storePassword.Trim() == " ")
            {
                Toast.MakeText(this, "PLEASE ENTER YOUR PASSWORD", ToastLength.Long).Show();
            }

            else
            {
                var infoObj = realmDB.All<UserInfoDB>().Where(d => d.email == storeEmail.ToLower());
                var checkInfo = infoObj.Count();

                if (checkInfo > 0)
                {
                    Toast.MakeText(this, "ACCOUNT ALREADY EXIST! PLEASE TRY DIFFERENT EMAIL", ToastLength.Long).Show();
                }

                else
                {
                    UserInfoDB saveUserData = new UserInfoDB();

                    saveUserData.nameofuser = storeNameinDb;

                    saveUserData.email = storeEmail.ToLower();

                    saveUserData.password = storePassword.ToLower();

                    saveUserData.age = storeAge;

                    realmDB.Write(() =>
                    {
                        realmDB.Add(saveUserData);
                    });
                    username.Text = "";
                    useremail.Text = "";
                    userage.Text = "";
                    phonenumber.Text = "";
                    pwd.Text = "";
                    Toast.MakeText(this, "ACCOUNT SUCCESSFULLY SAVED!", ToastLength.Short).Show();
                }
            }
        }
        private void ReturnBtn_Click(object sender, EventArgs e)

        {
            Intent newMainActivityScreen = new Intent(this, typeof(MainActivity));
            StartActivity(newMainActivityScreen);
        }

    }
}
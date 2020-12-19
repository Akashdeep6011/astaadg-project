using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Realms;


namespace astaadg
{
    public class Tab1 : Fragment
    {
        TextView userinfo;
        TextView email;
        TextView phonenumber;
        TextView name;
        UserInfoDB userinfodbObj;
        Activity context;
        Realm realmDB;
        string changeName;
        string changeEmail;
        string changePhone;
        public Tab1(UserInfoDB userInfo)
        {
            this.userinfodbObj = userInfo;
            //this.context = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            realmDB = Realm.GetInstance();
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View myView = inflater.Inflate(Resource.Layout.Tab1, container, false); 


            userinfo = myView.FindViewById<TextView>(Resource.Id.textView1);

            email = myView.FindViewById<TextView>(Resource.Id.emailID);

            phonenumber = myView.FindViewById<TextView>(Resource.Id.phonenumberID);
            name = myView.FindViewById<TextView>(Resource.Id.nameofuserID);


            userinfo.Text = userinfodbObj.nameofuser;
            email.Text = userinfodbObj.email;
            name.Text = userinfodbObj.nameofuser;
            var convertToInt = userinfodbObj.phonenumber.ToString();
            phonenumber.Text = "9086907906";

            return myView;
        }
        private void registerUser(object sender, EventArgs e)
        {
            changeName = name.Text;

            changePhone = phonenumber.Text;

            UserInfoDB saveUserData = new UserInfoDB();

            saveUserData.nameofuser = changeName;


            var toast = Toast.MakeText(context, "CHANGES UPDATED", ToastLength.Short);
            toast.Show();

            realmDB.Write(() =>
            {
                realmDB.Add(saveUserData);
            });
            name.Text = changeName;
           
        }
    }
}
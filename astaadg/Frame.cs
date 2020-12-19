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
    [Activity(Label = "Frame")]
    public class Frame : Activity
    {
        string nameInfo;
        Realm realmDB;
        [Obsolete]
        Fragment[] _FragmentsArray;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FrameLayout);
            realmDB = Realm.GetInstance();
            nameInfo = Intent.GetStringExtra("useremail");
            var userinfodbObj = realmDB.All<UserInfoDB>().Where(d => d.email == nameInfo.ToLower()).First();

            _FragmentsArray = new Fragment[]
            {
                new Tab1(userinfodbObj),

                new Tab2(this),

                new Tab3(this)
            };

            AddTabToActionBar("First Tab");

            AddTabToActionBar("Second Tab");

            AddTabToActionBar("Third Tab");
        }


        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();

            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            this.ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;
            Fragment frag = _FragmentsArray[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }

    }
}
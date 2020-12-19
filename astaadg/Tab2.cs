using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Realms;

namespace astaadg
{
    public class Tab2 : Fragment
    {
        Button saveBtn;
        Button submit;
        ListView listView;
        Spinner spinnerView;       
        Spinner clothingImage;   

        Realm realmDB;             
        MyCustomAdapter myAdapter; 

        //All arrays:
      



        List<MyModel> myOwnList = new List<MyModel>();
        List<int> myitemQuantityList = new List<int>();
        List<ItemImageModel> clothingItemImage = new List<ItemImageModel>();
        private Activity context;

        public Tab2(Activity passedContext)
        {
            this.context = passedContext;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            realmDB = Realm.GetInstance();

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {



            View myView = inflater.Inflate(Resource.Layout.Tab2, container, false); 

            listView = myView.FindViewById<ListView>(Resource.Id.listViewID);
       


            myOwnList = getDataFromRealmDB();  
            myAdapter = new MyCustomAdapter(context, myOwnList); 
            listView.Adapter = myAdapter;

           


            return myView;
        }






      


        public List<MyModel> getDataFromRealmDB()
        {

            List<MyModel> dbRecordList = new List<MyModel>();

            var resultCollection = realmDB.All<UserInfoDB>();


            foreach (UserInfoDB newObj in resultCollection)
            {
                int itemimagefromDB = newObj.itemimage;
                int itemquantityfromDB = newObj.itemquantity;

                MyModel temp = new MyModel(itemimagefromDB, itemquantityfromDB);
                dbRecordList.Add(temp);
            }
            return dbRecordList;
        }
    }
}

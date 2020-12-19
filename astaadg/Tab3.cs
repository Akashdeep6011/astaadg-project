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
    public class Tab3 : Fragment
    {
        Button saveBtn;

        Button submit;

        ListView listView;

        Spinner spinnerView;
        
        Spinner clothingImage;   
        Realm realmDB;              
        MyCustomAdapter myAdapter;  

        int[] clothingItemImage = {
            Resource.Drawable.tsh,
            Resource.Drawable.tshtwo,
            Resource.Drawable.tshfive,
            Resource.Drawable.tshsix,

            Resource.Drawable.tshtre,
            Resource.Drawable.tshfour,
        };    
        int[] itemQuantity = {
            1,
            2,
            3,
            4,
            5,
            6,
            7};   

        int selectedItemImage;
        int selectedItemQuantity;


        List<MyModel> myOwnList = new List<MyModel>();
        List<int> myitemQuantityList = new List<int>();
        List<ItemImageModel> myclothingItemImageList = new List<ItemImageModel>();
        private Activity context;

        public Tab3(Activity passedContext)
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

          

            View myView = inflater.Inflate(Resource.Layout.Tab3, container, false); 

            listView = myView.FindViewById<ListView>(Resource.Id.listViewID);

            spinnerView = myView.FindViewById<Spinner>(Resource.Id.spinnerViewID);

            clothingImage = myView.FindViewById<Spinner>(Resource.Id.groceryImageID);

            submit = myView.FindViewById<Button>(Resource.Id.MyButton);
            submit.Click += delegate {
                AlertDialog.Builder alertDiag = new AlertDialog.Builder(context);
                alertDiag.SetTitle("Confirm ");
                alertDiag.SetMessage("ADD TO LIST");
                alertDiag.SetPositiveButton("ADD", (senderAlert, args) => {
                    int itemImageInfo = selectedItemImage;
                    int itemQuantityInfo = selectedItemQuantity;

                    UserInfoDB newObj = new UserInfoDB();
                    newObj.itemquantity = itemQuantityInfo;
                    newObj.itemimage = itemImageInfo;


                    realmDB.Write(() =>
                    {
                        realmDB.Add(newObj);
                    });


                    myOwnList = getDataFromRealmDB();  
                    myAdapter = new MyCustomAdapter(context, myOwnList); 
                    listView.Adapter = myAdapter;
                    var toast = Toast.MakeText(context, "ADDED SUCCESSFULLY", ToastLength.Short);
                    toast.Show();
                    
                });
                alertDiag.SetNegativeButton("Cancel", (senderAlert, args) => {
                    alertDiag.Dispose();
                });
                Dialog diag = alertDiag.Create();
                diag.Show();
            };
           
            //Set Adapters:
            ArrayAdapter arrayAdapter = new ArrayAdapter(context, Android.Resource.Layout.SimpleExpandableListItem1, itemQuantity);
            spinnerView.Adapter = arrayAdapter;
            spinnerView.ItemSelected += spinner_ItemSelected; 

            myclothingItemImageList = getclothingItemImage();

            ItemImageAdapter itemimageAdapter = new ItemImageAdapter(context, myclothingItemImageList);
            clothingImage.Adapter = itemimageAdapter;
            clothingImage.ItemSelected += clothingImage_ItemSelected;

            return myView;
        }


   
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            int index = e.Position;
            selectedItemQuantity = itemQuantity[index];
        }

        private void clothingImage_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)//For Spinner Item Quantity
        {
            int index = e.Position;

            ItemImageModel ItemImageModel = myclothingItemImageList[index];
            selectedItemImage = ItemImageModel.itemimage;
        }




        public List<ItemImageModel> getclothingItemImage()
        {
            List<ItemImageModel> temp = new List<ItemImageModel>();

            temp.Add(new ItemImageModel(Resource.Drawable.tsh));

            temp.Add(new ItemImageModel(Resource.Drawable.tshfive));

            temp.Add(new ItemImageModel(Resource.Drawable.tshsix));

            temp.Add(new ItemImageModel(Resource.Drawable.tshtwo));

            temp.Add(new ItemImageModel(Resource.Drawable.tshfour));

            temp.Add(new ItemImageModel(Resource.Drawable.tshtre));

            return temp;

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

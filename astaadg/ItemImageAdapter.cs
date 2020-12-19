

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

namespace astaadg { 
    class ItemImageAdapter : BaseAdapter<ItemImageModel>
    {
        Activity context;
        List<ItemImageModel> arrayList;

        public ItemImageAdapter(Activity myContext, List<ItemImageModel> myListItems)
        {
            this.context = myContext;

            this.arrayList = myListItems;
        }

        public override ItemImageModel this[int position]
        {
            get { return arrayList[position]; }
        }

        public override int Count
        {
            get { return arrayList.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ItemImageModel myModelObject = arrayList[position];

            View myView = convertView;

            if (myView == null)
            {
                myView = context.LayoutInflater.Inflate(Resource.Layout.myViewintotheList, null);  
            }


            ImageView myImage = myView.FindViewById<ImageView>(Resource.Id.myImageID);

            myImage.SetImageResource(myModelObject.itemimage);

            return myView;
        }

    }
}

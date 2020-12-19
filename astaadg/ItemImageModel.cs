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

namespace astaadg
{
    public class ItemImageModel

    {
        public int itemimage;


        public ItemImageModel()
        {
        }

        public ItemImageModel(int itemImageInfo)
        {
            this.itemimage = itemImageInfo;
        }

    }
}
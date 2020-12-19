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
    public class MyModel
    {
    
        public int itemimage;
        public int itemquantity;

        public MyModel()
        {
        }


        public MyModel(int Itemimage, int Itemquantity)
        {
      
            this.itemimage = Itemimage;
            this.itemquantity = Itemquantity;
        }  

        public static implicit operator string(MyModel v)
        {
            throw new NotImplementedException();
        }
    }
}

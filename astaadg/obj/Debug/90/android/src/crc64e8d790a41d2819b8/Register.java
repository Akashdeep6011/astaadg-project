package crc64e8d790a41d2819b8;


public class Register
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Katherine_Lopez_Term_Project_V1.Register, Katherine_Lopez_Term_Project_V1", Register.class, __md_methods);
	}


	public Register ()
	{
		super ();
		if (getClass () == Register.class)
			mono.android.TypeManager.Activate ("Katherine_Lopez_Term_Project_V1.Register, Katherine_Lopez_Term_Project_V1", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

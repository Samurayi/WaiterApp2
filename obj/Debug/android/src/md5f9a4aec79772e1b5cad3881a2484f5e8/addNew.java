package md5f9a4aec79772e1b5cad3881a2484f5e8;


public class addNew
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
		mono.android.Runtime.register ("WaiterApp.addNew, WaiterApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", addNew.class, __md_methods);
	}


	public addNew () throws java.lang.Throwable
	{
		super ();
		if (getClass () == addNew.class)
			mono.android.TypeManager.Activate ("WaiterApp.addNew, WaiterApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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

package md5d3266ca695227db39945f1efb2d2b4fa;


public class VideoViewSavedState
	extends android.view.View.BaseSavedState
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler\n" +
			"";
		mono.android.Runtime.register ("Octane.Xam.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", VideoViewSavedState.class, __md_methods);
	}


	public VideoViewSavedState (android.os.Parcel p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == VideoViewSavedState.class)
			mono.android.TypeManager.Activate ("Octane.Xam.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Parcel, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public VideoViewSavedState (android.os.Parcelable p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == VideoViewSavedState.class)
			mono.android.TypeManager.Activate ("Octane.Xam.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", "Android.OS.IParcelable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void writeToParcel (android.os.Parcel p0, int p1)
	{
		n_writeToParcel (p0, p1);
	}

	private native void n_writeToParcel (android.os.Parcel p0, int p1);

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

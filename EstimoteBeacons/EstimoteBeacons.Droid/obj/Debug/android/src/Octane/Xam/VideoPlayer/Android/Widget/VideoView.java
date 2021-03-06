package Octane.Xam.VideoPlayer.Android.Widget;


public class VideoView
	extends android.widget.VideoView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setMediaController:(Landroid/widget/MediaController;)V:GetSetMediaController_Landroid_widget_MediaController_Handler\n" +
			"n_setVideoPath:(Ljava/lang/String;)V:GetSetVideoPath_Ljava_lang_String_Handler\n" +
			"n_setVideoURI:(Landroid/net/Uri;)V:GetSetVideoURI_Landroid_net_Uri_Handler\n" +
			"n_setVideoURI:(Landroid/net/Uri;Ljava/util/Map;)V:GetSetVideoURI_Landroid_net_Uri_Ljava_util_Map_Handler\n" +
			"n_start:()V:GetStartHandler\n" +
			"n_stopPlayback:()V:GetStopPlaybackHandler\n" +
			"n_pause:()V:GetPauseHandler\n" +
			"";
		mono.android.Runtime.register ("Octane.Xam.VideoPlayer.Android.Widget.VideoView, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", VideoView.class, __md_methods);
	}


	public VideoView (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == VideoView.class)
			mono.android.TypeManager.Activate ("Octane.Xam.VideoPlayer.Android.Widget.VideoView, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public VideoView (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == VideoView.class)
			mono.android.TypeManager.Activate ("Octane.Xam.VideoPlayer.Android.Widget.VideoView, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public VideoView (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == VideoView.class)
			mono.android.TypeManager.Activate ("Octane.Xam.VideoPlayer.Android.Widget.VideoView, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public VideoView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3) throws java.lang.Throwable
	{
		super (p0, p1, p2, p3);
		if (getClass () == VideoView.class)
			mono.android.TypeManager.Activate ("Octane.Xam.VideoPlayer.Android.Widget.VideoView, Octane.Xam.VideoPlayer.Android, Version=1.2.3.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void setMediaController (android.widget.MediaController p0)
	{
		n_setMediaController (p0);
	}

	private native void n_setMediaController (android.widget.MediaController p0);


	public void setVideoPath (java.lang.String p0)
	{
		n_setVideoPath (p0);
	}

	private native void n_setVideoPath (java.lang.String p0);


	public void setVideoURI (android.net.Uri p0)
	{
		n_setVideoURI (p0);
	}

	private native void n_setVideoURI (android.net.Uri p0);


	public void setVideoURI (android.net.Uri p0, java.util.Map p1)
	{
		n_setVideoURI (p0, p1);
	}

	private native void n_setVideoURI (android.net.Uri p0, java.util.Map p1);


	public void start ()
	{
		n_start ();
	}

	private native void n_start ();


	public void stopPlayback ()
	{
		n_stopPlayback ();
	}

	private native void n_stopPlayback ();


	public void pause ()
	{
		n_pause ();
	}

	private native void n_pause ();

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

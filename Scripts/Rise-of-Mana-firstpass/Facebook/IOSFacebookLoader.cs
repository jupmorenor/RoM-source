namespace Facebook;

public class IOSFacebookLoader : FB.CompiledFacebookLoader
{
	protected override IFacebook fb => FBComponentFactory.GetComponent<IOSFacebook>();
}

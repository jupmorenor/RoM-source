namespace Facebook;

public class AndroidFacebookLoader : FB.CompiledFacebookLoader
{
	protected override IFacebook fb => FBComponentFactory.GetComponent<AndroidFacebook>();
}

namespace Facebook;

public class EditorFacebookLoader : FB.CompiledFacebookLoader
{
	protected override IFacebook fb => FBComponentFactory.GetComponent<EditorFacebook>();
}

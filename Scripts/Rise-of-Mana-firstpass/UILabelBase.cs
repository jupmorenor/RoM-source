public class UILabelBase : UIWidget
{
	public virtual string text
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	public virtual UIFont font
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool supportEncoding
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual int lineWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public virtual bool multiLine
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool showLastPasswordChar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool password
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual void setText(string t)
	{
	}
}

namespace remindme;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

	private void Switch_Toggled ( object sender, ToggledEventArgs e )
	{
		if(Application.Current.UserAppTheme == AppTheme.Light)
		{
			Application.Current.UserAppTheme = AppTheme.Dark;
		}
		else
		{
			Application.Current.UserAppTheme = AppTheme.Light;
		}
	}
}
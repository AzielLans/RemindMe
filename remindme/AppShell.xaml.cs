﻿namespace remindme;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.NotesPage), typeof(Views.NotesPage));
    }
}

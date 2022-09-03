using remindme.Models;
using System.Globalization;

namespace remindme.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotesPage : ContentPage
{
    public NotesPage()
	{
		InitializeComponent();
        string appDataPath = "/test";
        string randomFileName = $"notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }

    private void LoadNote ( string fileName )
    {
        Note noteModel = new Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            string name = Path.GetFileNameWithoutExtension(fileName);
            noteModel.Name = name;
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Notes = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }

    private void SaveTitle (string fileName, string path)
    {
            if (BindingContext is Note Name)
            {
                string name = NameEditor.Text;
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                var newFilename = string.Format("{1}.txt", fileNameWithoutExtension, name);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(fileName, newFullFilename);
            }
    }

    private async void SaveButton_Clicked ( object sender, EventArgs e )
    {
        Note noteModel = new Note();
        string appDataPath = "/test";
         string randomFileName = "notes.txt";
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);
        try
        {
            SaveTitle(Path.Combine(appDataPath, randomFileName), appDataPath);
        }
        catch (IOException exp)
        {
            await DisplayAlert("Error", exp.Message, "OK");
            Delete();
    }
        await Shell.Current.GoToAsync("..");
    }

    public void Delete()
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }
    }

    private async void DeleteButton_Clicked ( object sender, EventArgs e )
    {
        Delete();

        await Shell.Current.GoToAsync("..");
    }
}
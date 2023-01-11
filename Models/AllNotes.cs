using Java.Security;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Notes.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    public static List<Note> notesToBeAddedd = new List<Note>();

    public AllNotes() =>
        Task.Run(async () =>
        {
            await LoadNotes();
        });

    public async Task LoadNotes()
    {
        Notes.Clear();

        await Task.Delay(2000);
            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Note> notes = Directory.EnumerateFiles(appDataPath, "*.notes.txt")
                .Select(filename => new Note()
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                })
                .OrderBy(note => note.Date);

            notesToBeAddedd = notes.Take(25).ToList();
            foreach (Note note in notesToBeAddedd)
                Notes.Add(note);

        await Task.Delay(2000);


    }


    //public async Task<bool> LoadNotes()
    //{
    //    Notes.Clear();

    //    await Task.Delay(2000);
    //    string appDataPath = FileSystem.AppDataDirectory;

    //    IEnumerable<Note> notes = Directory.EnumerateFiles(appDataPath, "*.notes.txt")
    //        .Select(filename => new Note()
    //        {
    //            Filename = filename,
    //            Text = File.ReadAllText(filename),
    //            Date = File.GetCreationTime(filename)
    //        })
    //        .OrderBy(note => note.Date);


    //    foreach (Note note in notes)
    //        Notes.Add(note);

    //    await Task.Delay(2000);

    //    return true;
    //}
}

using System.Collections.ObjectModel;

namespace Notes.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

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


            foreach (Note note in notes)
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

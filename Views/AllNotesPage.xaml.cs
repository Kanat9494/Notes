namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();

		BindingContext = new Models.AllNotes();
		loader.IsRunning = true;
		loader.IsVisible = true;
		bool isTrue = false;

		//Task.Run(async () =>
		//{
		//	isTrue = await ((Models.AllNotes)BindingContext).LoadNotes();

			
		//}).GetAwaiter().OnCompleted(() =>
		//{
  //          if (isTrue)
		//	{
  //              loader.IsVisible = false;
  //              loader.IsRunning = false;
  //          }
                
  //      });
	}

    protected override void OnAppearing()
    {
        loader.IsVisible = true;
        loader.IsRunning = true;
        bool isLoading = false;
        Task.Run(async () =>
        {
            isLoading = await ((Models.AllNotes)BindingContext).LoadNotes();
        }).GetAwaiter().OnCompleted(() =>
        {
                loader.IsVisible = false;
                loader.IsRunning = false;
        });
    }

    //  protected override async void OnAppearing()
    //  {
    //      //loader.IsVisible = true;
    //      //loader.IsRunning = true;
    //      App.Current.Dispatcher.Dispatch(() =>
    //      {
    //          loader.IsVisible = true;
    //          loader.IsRunning = true;
    //      });

    //      bool isTrue = await((Models.AllNotes)BindingContext).LoadNotes();

    //App.Current.Dispatcher.Dispatch(() =>
    //{
    //		loader.IsVisible = false;
    //		loader.IsRunning = false;
    //});

    //  }

    private async void Add_Clicked(object sender, EventArgs e) =>
		await Shell.Current.GoToAsync(nameof(NotePage));

	private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count != 0)
		{
			var note = (Models.Note)e.CurrentSelection[0];

			await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

			notesCollection.SelectedItem = null;
		}
	}
}
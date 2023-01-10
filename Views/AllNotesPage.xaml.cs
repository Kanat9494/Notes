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

        //Этот вариант работает только если метод LoadNotes возвращает значение
        //Task.Run(async () =>
        //{
        //    isLoading = await ((Models.AllNotes)BindingContext).LoadNotes();
        //}).GetAwaiter().OnCompleted(() =>
        //{
        //    loader.IsVisible = false;
        //    loader.IsRunning = false;
        //});

        //Этот метод работает
        //App.Current.Dispatcher.Dispatch(async () =>
        //{
        //    await ((Models.AllNotes)BindingContext).LoadNotes();
        //});

        //Этот способ тоже работает
        //App.Current.Dispatcher.Dispatch(async () =>
        //{
        //    Task.Run(async () =>
        //    {
        //        await ((Models.AllNotes)BindingContext).LoadNotes();
        //    }).GetAwaiter().OnCompleted(() =>
        //    {
        //        loader.IsRunning = false;
        //        loader.IsVisible = false;
        //    });
        //});

        //Этот способ тоже работает, плюс к тому же он работает с меньшими лагами чем другие
        //App.Current.Dispatcher.Dispatch(() =>
        //{
        //    Task.Run(async () =>
        //    {
        //        await ((Models.AllNotes)BindingContext).LoadNotes();
        //    }).GetAwaiter().OnCompleted(() =>
        //    {
        //        loader.IsRunning = false;
        //        loader.IsVisible = false;
        //    });
        //});

        //Новый способ, тоже работает но есть не точности
        //Task.Run(async () =>
        //{
        //    await ((Models.AllNotes)BindingContext).LoadNotes();
        //}).GetAwaiter().OnCompleted(() =>
        //{
        //    App.Current.Dispatcher.Dispatch(() =>
        //    {
        //        loader.IsVisible = false;
        //        loader.IsRunning = false;
        //    });
        //});

        //Тоже работает
        Task.Run(async () =>
        {
            await ((Models.AllNotes)BindingContext).LoadNotes();
        }).GetAwaiter().OnCompleted(() =>
        {
            loader.IsRunning = false;
            loader.IsVisible = false;
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
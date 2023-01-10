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

        //���� ������� �������� ������ ���� ����� LoadNotes ���������� ��������
        //Task.Run(async () =>
        //{
        //    isLoading = await ((Models.AllNotes)BindingContext).LoadNotes();
        //}).GetAwaiter().OnCompleted(() =>
        //{
        //    loader.IsVisible = false;
        //    loader.IsRunning = false;
        //});

        //���� ����� ��������
        //App.Current.Dispatcher.Dispatch(async () =>
        //{
        //    await ((Models.AllNotes)BindingContext).LoadNotes();
        //});

        //���� ������ ���� ��������
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

        //���� ������ ���� ��������, ���� � ���� �� �� �������� � �������� ������ ��� ������
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

        //����� ������, ���� �������� �� ���� �� ��������
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

        //���� ��������
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
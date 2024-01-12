using CommunityToolkit.Maui.Alerts;
using HeroApp.Models.Entities;
using HeroApp.Repository;

namespace HeroApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{

    #region Properties
    [ObservableProperty]
    string searchText;

    [ObservableProperty]
    ObservableCollection<Heroe> heroes;

    [ObservableProperty]
    int currentPage;

    [ObservableProperty]
    int countPages;

    [ObservableProperty]
    int offSet;

    [ObservableProperty]
    bool previousPageEnabledButton;

    [ObservableProperty]
    bool middlePageEnabled;

    [ObservableProperty]
    bool nextPageEnabled;

    [ObservableProperty]
    bool nextPageEnabledButton;

    [ObservableProperty]
    int previousPageText;

    [ObservableProperty]
    int nextPageText;

    [ObservableProperty]
    int middlePageText;

    [ObservableProperty]
    bool hasHeroes;

    [ObservableProperty]
    bool previousPageActive;

    [ObservableProperty]
    bool nextPageActive;

    [ObservableProperty]
    bool middlePageActive;
    #endregion

    #region Variables
    IHeroeRepository _heroeRepository;
    #endregion
    public HomeViewModel(IHeroeRepository heroeRepository)
    {
        _heroeRepository = heroeRepository;
        _ = GetHeroes();
        OffSet = 0;
        CurrentPage = 1;
        PreviousPageText = CurrentPage;
    }

    public async Task GetHeroes()
    {
        try
        {
            var heroeList = await _heroeRepository.GetHeroes(4, OffSet, SearchText);
            if (heroeList != null && (heroeList.data != null && heroeList.data.results.Any()))
            {
                HasHeroes = true;
                Heroes = new ObservableCollection<Heroe>(heroeList.data.results);
                CountPages = heroeList.data.total / 4;
                CurrentPage = CurrentPage == 0 ? CurrentPage + 1 : CurrentPage;
                OrganizePagination();
                return;
            }
            HasHeroes = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private void OrganizePagination()
    {
        MiddlePageText = CurrentPage + 1;

        PreviousPageText = CurrentPage == 1 ? CurrentPage : MiddlePageText - 1;

        NextPageText = CurrentPage + 2;

        MiddlePageActive = CurrentPage == MiddlePageText;

        PreviousPageActive = CurrentPage == PreviousPageText;

        NextPageActive = CurrentPage == NextPageText;

        if (CurrentPage > 1)
            PreviousPageEnabledButton = true;
        else
            PreviousPageEnabledButton = false;

        if (CountPages > 1 && CurrentPage < CountPages)
            NextPageEnabledButton = true;
        else
            NextPageEnabledButton = false;

        if(NextPageText > CountPages)
            NextPageEnabled = false;
        else
            NextPageEnabled = true;


        if (MiddlePageText > CountPages)
            MiddlePageEnabled = false;
        else
            MiddlePageEnabled = true;
    }


    [RelayCommand]
    public async Task NextPage()
    {
        CurrentPage += 1;
        OffSet +=4;
        await GetHeroes();
    }

    [RelayCommand]
    public async Task PreviousPage()
    {
        if(CurrentPage > 1)
        {
            CurrentPage -= 1;
            OffSet -= 4;
            await GetHeroes();
        }
    }

    public async Task FilterName()
    {
        await GetHeroes();
    }
}

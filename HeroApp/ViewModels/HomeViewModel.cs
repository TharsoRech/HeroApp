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
    bool previousPageEnabled;

    [ObservableProperty]
    bool nextPageEnabled;

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
            if (heroeList != null && (heroeList.Data != null && heroeList.Data.Results.Any()))
            {
                HasHeroes = true;
                Heroes = new ObservableCollection<Heroe>(heroeList.Data.Results);
                CountPages = heroeList.Data.Total;
                CurrentPage = CurrentPage == 0 ? CurrentPage + 1 : CurrentPage;
                MiddlePageText = CurrentPage + 1;
                PreviousPageText = CurrentPage == 1 ? CurrentPage : MiddlePageText - 1;
                NextPageText = CurrentPage + 2;

                MiddlePageActive = CurrentPage == MiddlePageText;

                PreviousPageActive = CurrentPage == PreviousPageText;

                NextPageActive = CurrentPage == NextPageText;

                if (CurrentPage > 1)
                    PreviousPageEnabled = true;
                else
                    PreviousPageEnabled = false;

                if (CountPages > 1 && CurrentPage < CountPages)
                    NextPageEnabled = true;
                else
                    NextPageEnabled = false;
                return;
            }
            HasHeroes = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

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

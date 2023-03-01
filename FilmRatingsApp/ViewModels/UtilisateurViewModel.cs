using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;

namespace FilmRatingsApp.ViewModels;

public class UtilisateurViewModel : ObservableRecipient
{
    private Utilisateur utilisateurSearch;
    private WService service;
    private string searchMail;

    public IRelayCommand BtnSearchUtilisateurCommand
    {
        get;
    }


    public Utilisateur UtilisateurSearch
    {
        get
        {
            return utilisateurSearch;
        }

        set
        {
            utilisateurSearch = value;
            OnPropertyChanged();
        }
    }

    public string SearchMail
    {
        get
        {
            return searchMail;
        }

        set
        {
            searchMail = value;
            OnPropertyChanged();
        }
    }

    public UtilisateurViewModel()
    {
        service = new WService("https://localhost:7274/api/utilisateurs/");
        BtnSearchUtilisateurCommand = new RelayCommand(ActionSetSearch);
        UtilisateurSearch = new Utilisateur();
    }

    public async void ActionSetSearch()
    {
        UtilisateurSearch = await service.GetUtilisateursByMailAsync(SearchMail);
    }
}

using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.ViewModels;

public class UtilisateurViewModel : ObservableObject
{
    private Utilisateur utilisateurSearch;
    private WService service;
    private string searchMail;

    private int nb;


    public int Nb
    {
        get
        {
            return nb;
        }

        set
        {
            nb = value;
            OnPropertyChanged();
        }
    }

    public IRelayCommand BtnSearchUtilisateurCommand
    {
        get;
    }


    public IRelayCommand BtnModifyUtilisateurCommand
    {
        get;
    }


    public IRelayCommand BtnClearUtilisateurCommand
    {
        get;
    }


    public IRelayCommand BtnAddUtilisateurCommand
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
        service = new WService(new Windows.ApplicationModel.Resources.ResourceLoader().GetString("WSUsersLocalUri"));
        GetDataOnLoadAsync();
        BtnSearchUtilisateurCommand = new RelayCommand(ActionSetSearch);
        BtnClearUtilisateurCommand = new RelayCommand(ActionSetClear);
        BtnModifyUtilisateurCommand = new RelayCommand(ActionSetSave);
        UtilisateurSearch = new Utilisateur();
        //test();
    }

    public async void ActionSetSearch()
    {
        UtilisateurSearch = await service.GetUtilisateursByMailAsync("utilisateurs/", SearchMail);
    }

    public async void ActionSetSave()
    {
        await service.PutUtilisateursAsync("utilisateurs/",UtilisateurSearch);
        DisplayshowAsync("Ok", "Modif effectué.");
    }

    public void ActionSetClear()
    {
        UtilisateurSearch = new Utilisateur();
        DisplayshowAsync("Ok", "Vous avez tout cramé et êtes reparti à zéro avec succès.");
    }

    public async void ActionSetAdd()
    {

    }

    public async void test()
    {
        DisplayshowAsync("ok", "ça marche ma couille");
    }

    public async void GetDataOnLoadAsync()
    {
        List<Utilisateur> result = await service.GetUtilisateursAsync("utilisateurs");
        if (result == null)
        {
            throw new ArgumentException("marche pas");
        }
        else
        {
            //DisplayshowAsync("test", result[0].ToString());
        }
    }


    public async void DisplayshowAsync(string title, string desc)
    {
        ContentDialog contentDialog = new ContentDialog
        {
            Title = title,
            Content = desc,
            PrimaryButtonText = "Ok"
        };
        contentDialog.XamlRoot = App.MainRoot.XamlRoot;
        ContentDialogResult result = await contentDialog.ShowAsync();
        }





}
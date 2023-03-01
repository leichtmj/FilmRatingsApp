using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.Services;
public class WService : IWService
{
    HttpClient client = new HttpClient();

    public WService(string url)
    {
        //pour accéder à l'API REST
        client.BaseAddress = new Uri(url); //L’adresse à indiquer devra être celle de votre API, construite de la façon suivante: https://localhost:PORT/api/
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur)
    {
        try
        {
            return await client.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Utilisateur> GetUtilisateursByIdAsync(int id)
    {
        try
        {
            return await client.GetFromJsonAsync<Utilisateur>(string.Concat(client.BaseAddress, $"utilisateurs/getutilisateurbyid/{id}"));
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Utilisateur> GetUtilisateursByMailAsync(string nomControleur, string mail)
    {
        try
        {
            return await client.GetFromJsonAsync<Utilisateur>(string.Concat(client.BaseAddress, nomControleur, $"getutilisateurbyemail/{mail}"));
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> PostUtilisateursAsync(Utilisateur s)
    {
        try
        {
            var response = await client.PostAsJsonAsync("series", s);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteUtilisateursAsync(Utilisateur s)
    {
        try
        {
            var response = await client.DeleteAsync($"series/{s.UtilisateurId}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public async Task<bool> PutUtilisateursAsync(string nomControleur, Utilisateur s)
    {
        try
        {
            var response = await client.PutAsJsonAsync(string.Concat(client.BaseAddress, "utilisateurs", $"/{s.UtilisateurId}"), s);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }


}

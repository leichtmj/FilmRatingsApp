using FilmRatingsApp.Models;

namespace FilmRatingsApp.Services;
public interface IWService
{
    Task<bool> DeleteUtilisateursAsync(Utilisateur s);
    Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur);
    Task<Utilisateur> GetUtilisateursByIdAsync(int id);
    Task<bool> PostUtilisateursAsync(Utilisateur s);
    Task<bool> PutUtilisateursAsync(string c, Utilisateur s);
}
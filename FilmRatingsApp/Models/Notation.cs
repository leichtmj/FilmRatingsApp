

namespace FilmRatingsApp.Models
{

    public class Notation
    {
        public int UtilisateurId { get; set; }

        public int FilmId { get; set; }

        public int Note { get; set; }

        public virtual Film FilmNote { get; set; }

        public virtual Utilisateur UtilisateurNotant { get; set; }
    }
}

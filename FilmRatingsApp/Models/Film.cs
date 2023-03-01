namespace FilmRatingsApp.Models
{
    public class Film
    {

        public int FilmId { get; set; }

        public string Titre { get; set; }

        public string Resume { get; set; }

        public DateTime DateSortie { get; set; }

        public decimal Duree { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<Notation> NotesFilm { get; } = new List<Notation>();
    }
}

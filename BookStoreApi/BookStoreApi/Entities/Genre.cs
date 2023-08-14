using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true; //Kategorileri açıp kapayabilmek için

        public ICollection<Book> Books { get; set; } = new List<Book>(); // Collection navigation property
    }
}

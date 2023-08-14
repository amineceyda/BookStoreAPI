using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<Book> Books { get; set; } // Collection navigation property
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Produto
    {
        [Column("idProduto")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public integer idProduto {get; set;}

        [Column]
    }
}
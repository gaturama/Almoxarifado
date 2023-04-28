using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ProdutoModels
    {
        [Column("idProduto")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto {get; set;}

        [Column("nome")]

        public string nome{get; set;}

        [Column("preco")]
        public string preco{get; set;}

        public ProdutoModels(string nome, string preco)
        {
            this.nome = nome;
            this.preco = preco;
        }
    }
}
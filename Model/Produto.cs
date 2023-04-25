using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ProdutoModels
    {
        [Column("idProduto")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto {get; set;}

        [Column("Nome")]

        public string nome{get; set;}

        [Column("Preço")]
        public string preco{get; set;}

        public ProdutoModels(int idProduto, string nome, string preco)
        {
            this.idProduto = idProduto;
            this.nome = nome;
            this.preco = preco;
        }
    }
}
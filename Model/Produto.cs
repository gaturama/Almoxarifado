using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Produto
    {
        [Column("idProduto")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto {get; set;}

        [Column("Nome")]

        public string nome{get; set;}

        [Column("Preço")]
        public string preco{get; set;}

        public Produto(int idProduto, string nome, string preco)
        {
            this.idProduto = idProduto;
            this.nome = nome;
            this.preco = preco;
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SaldoModels
    {
        [Column("idSaldo")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSaldo { get; set; }

        [Column("idProduto")]

        public int idProduto  { get; set; }

        [Column("idAlmoxarifado")]
        public int idAlmoxarifado{ get; set; }

        [Column("quantidade")]
        public int qtd { get; set; }

        public SaldoModels(int idProduto, int idAlmoxarifado, int qtd)
        {
            this.idProduto = idProduto;
            this.idAlmoxarifado = idAlmoxarifado;
            this.qtd = qtd;
        }
    }
}
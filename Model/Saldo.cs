using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SaldoModels
    {
        [Column("idSaldo")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSaldo { get; set; }

        [Column("Nome")]

        public string nome { get; set; }

        [Column("Almoxarifado")]
        public string almoxarifado{ get; set; }

        [Column("Quantidade")]
        public string qtd { get; set; }

        public SaldoModels(string nome, string almoxarifado, string qtd)
        {
            this.nome = nome;
            this.almoxarifado = almoxarifado;
            this.qtd = qtd;
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Almoxarifado
    {
        [Column("idAlmoxarifado")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAlmoxarifado {get; set;}

        [Column("nomeProduto")]
        public string nomeProduto{get; set;}   

        public Almoxarifado(string nomeProduto)
        {
            this.nomeProduto = nomeProduto;
        }
    }
}
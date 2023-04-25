using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class AlmoxarifadoModels
    {

        [Column("idAlmoxarifado")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAlmoxarifado {get; set;}

        [Column("Nome")]
        public string nome{get; set;}   

        public AlmoxarifadoModels(int idAlmoxarifado, string nome)
        {
            this.idAlmoxarifado = idAlmoxarifado;
            this.nome = nome;
        }
    }
}
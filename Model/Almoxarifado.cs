using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Almoxarifado
    {
        [Column("idAlmoxarifado")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAlmoxarifado {get; set;}

        [Column("idAlmoxarifado")]
        public string nome{get; set;}   

        [Column("nome")]
        public Almoxarifado(int idAlmoxarifado, string nome)
        {
            this.idAlmoxarifado = idAlmoxarifado;
            this.nome = nome;
        }
    }
}
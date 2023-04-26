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

        public AlmoxarifadoModels(string nome)
        {
            this.nome = nome;
        }

        internal void RefreshList()
        {
            throw new NotImplementedException();
        }
    }
}
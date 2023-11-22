using System.ComponentModel.DataAnnotations;

namespace API_CRUDMONGO.Models
{
    public class Departamento
    {
        public int _id { get; set; }

        [Required(ErrorMessage ="* Obligatorio")]
        public string descripcion { get; set;}
    }
}

namespace API_CRUDMONGO.Models
{
    public class SettingsDataBase
    {
        public string ConnectionStrings { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DBEmpleados { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;

        public string DptoCollectionName { get; set; } = null!;


    }
}

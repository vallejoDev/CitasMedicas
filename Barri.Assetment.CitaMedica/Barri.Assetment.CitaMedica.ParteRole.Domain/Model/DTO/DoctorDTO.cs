namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO
{
    public class DoctorDTO : IPerson
    {
        public int IdParteRole { get; set; }
        public int IdTipoParteRole { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}

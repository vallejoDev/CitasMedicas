namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Model
{
    public interface IPerson
    {
        int IdParteRole { get; set; }
        int IdTipoParteRole { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
    }
}

namespace Jobsy.UserAuthentication.Domain.Model.DTO;

public class CrearMensajeDto
{
    public int EmisorId { get; set; }
    public int ReceptorId { get; set; }
    public string Contenido { get; set; }
}

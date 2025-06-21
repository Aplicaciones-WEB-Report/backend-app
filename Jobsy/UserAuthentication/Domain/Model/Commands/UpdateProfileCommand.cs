using Jobsy.UserAuthentication.Domain.Model.ValueObjects;

namespace Jobsy.UserAuthentication.Domain.Model.Commands;

public record UpdateProfileCommand (string Descripcion, string Url_Foto)
{
    
}
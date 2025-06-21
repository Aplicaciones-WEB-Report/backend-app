using Jobsy.UserAuthentication.Domain.Model.ValueObjects;
using MediatR;

namespace Jobsy.UserAuthentication.Domain.Model.Commands;

public record RegisterUserCommand (string Nombre, string Apellido, int Edad, string Correo, string Contrasenia, Rol rol) : IRequest<int>
{
    
}
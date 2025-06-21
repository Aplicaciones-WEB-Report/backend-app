using Jobsy.Shared.Infrastructure.Persistencia.Configuration;
using Jobsy.UserAuthentication.Domain.Exception;
using Jobsy.UserAuthentication.Domain.Model.Aggregates;
using Jobsy.UserAuthentication.Domain.Model.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jobsy.UserAuthentication.Application.CommandServices;

public class RegisterUserService : IRequestHandler<RegisterUserCommand, int>
{
    private readonly AppDbContext _context;

    public RegisterUserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // Validación si el correo ya existe
        var existingUser = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Correo == request.Correo, cancellationToken);

        if (existingUser != null)
            throw new EmailAlreadyExistsException(request.Correo);
        
        // Crear nuevo usuario
        var nuevoUsuario = new User
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Edad = request.Edad,
            Correo = request.Correo,
            Contrasenia = request.Contrasenia,
            rol = request.rol
        };

        _context.Usuarios.Add(nuevoUsuario);
        await _context.SaveChangesAsync(cancellationToken);

        return nuevoUsuario.Id_Usuario;
    }
}


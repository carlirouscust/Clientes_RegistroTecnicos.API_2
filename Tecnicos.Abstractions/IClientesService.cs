using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Domain.DTO;
namespace Tecnicos.Abstractions;

public interface IClientesService
{
    Task<bool> Guardar(ClientesDto clientes);
    Task<bool> Eliminar(int id);
    Task<ClientesDto> Buscar(int id);
    Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio);
    Task<bool> NombreExiste(string? Nombre = null);
    Task<bool> Existe(int clientesID);
}

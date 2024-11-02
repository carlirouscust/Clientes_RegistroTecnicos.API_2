using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tecnicos.Data.Context;
using Tecnicos.Data.Models;
using Tecnicos.Domain.DTO;
using Tecnicos.Abstractions;


namespace Tecnicos.Services;

public class ClientesService(IDbContextFactory<TecnicosContext> DbFactory) : IClientesService 
{
    public async Task<bool> Existe(int clientesID)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes
            .AnyAsync(T => T.ClientesID == clientesID);
    }

    public async Task<bool> NombreExiste(string? Nombre = null)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        return await _context.Clientes
            .AnyAsync(T => T.Nombre == Nombre);
    }


    public async Task<bool> Insertar(ClientesDto clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Add(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(ClientesDto clientes)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        _context.Update(clientes);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(ClientesDto clientes)
    {
        if (!await NombreExiste(clientes.Nombre))
            return await Insertar(clientes);
        else
            return await Modificar(clientes);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var clientes = await _context.Clientes.
            Where(T => T.ClientesID == id).ExecuteDeleteAsync();
        return clientes > 0;
    }

    public async Task<ClientesDto?> Buscar(int id)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var cliente = await _context.Clientes
            .AsNoTracking()
            .Where(t => t.ClientesID == id)
            .Select(c => new ClientesDto
            {
                ClientesID = c.ClientesID,
                Nombre = c.Nombre,
                WhatsApp = c.WhatsApp
            })
            .FirstOrDefaultAsync();
        return cliente;
    }

    public async Task<List<ClientesDto>> Listar(Expression<Func<ClientesDto, bool>> criterio)
    {
        await using var _context = await DbFactory.CreateDbContextAsync();
        var clientes = await _context.Clientes
            .AsNoTracking()
            .Select(c => new ClientesDto
            {
                ClientesID = c.ClientesID,
                Nombre = c.Nombre,
                WhatsApp = c.WhatsApp,
            })
            .ToListAsync();

        return clientes.AsQueryable().Where(criterio).ToList();
    }

}

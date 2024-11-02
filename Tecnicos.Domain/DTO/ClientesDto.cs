using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Domain.DTO;

public class ClientesDto
{
    public int ClientesID { get; set; }

    public string? Nombre { get; set; }

    public string? WhatsApp { get; set; }
}

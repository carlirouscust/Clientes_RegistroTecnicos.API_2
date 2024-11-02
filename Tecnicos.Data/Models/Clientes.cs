using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicos.Data.Models;

public class Clientes
{
    [Key]
    public int ClientesID { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? WhatsApp { get; set; }
}

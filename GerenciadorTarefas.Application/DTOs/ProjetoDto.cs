using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefas.Application.DTOs
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public required string NomeProjeto { get; set; }
    }
}

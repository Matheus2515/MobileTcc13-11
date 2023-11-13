using MaseratiTCC.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaseratiTCC.Models
{
    public class Usuario
    {
        public long Id { get; set; }

        public long Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string Senha { get; set; }

        public byte[]? Foto { get; set; }

        public TipoClasseUsuario TipoUsuario { get; set; }

        public byte[]? Senha_hash { get; set; }

        public byte[]? Senha_salt { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public List<Agendamento> Agendamentos { get; set; }

        public List<Estabelecimento> Estabelecimentos { get; set; }
    }
}

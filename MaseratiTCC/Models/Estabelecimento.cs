using MaseratiTCC.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaseratiTCC.Models
{
    public class Estabelecimento
    {
        public long Id { get; set; }

        public string Cnpj { get; set; }

        public string Nome_est { get; set; }

        public string Local_est { get; set; }

        public int Numero_est { get; set; }

        public long UsuarioId { get; set; }

        public TipoClasseUsuario TipoUsuario { get; set; }

        public List<Agendamento> Agendamentos { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}

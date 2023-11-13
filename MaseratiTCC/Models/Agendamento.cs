using MaseratiTCC.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaseratiTCC.Models
{
    public class Agendamento
    {
        public long Id { get; set; }
        public DateTime Hora_ag { get; set; }
        public string Local_ag { get; set; }
        public DateTime data_ag { get; set; }
        public long UsuarioId { get; set; }
        public long EstabelecimentoId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
        [JsonIgnore]
        public Estabelecimento Estabelecimentos { get; set; }

        public FormasDePagamento FormasDePagamento { get; set; }
    }
}

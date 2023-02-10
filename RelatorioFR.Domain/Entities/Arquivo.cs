using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioFR.Core.Domain.Entities
{
    public class Arquivo
    {
        public Guid ArquivoId { get; set; }
        public string NomeOriginalArquivo { get; set; }
        public string ExtensaoArquivo { get; set; }
        public string CaminhoArquivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid IdUsuarioCadastrado { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }
    }
}

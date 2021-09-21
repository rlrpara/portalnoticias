using System;

namespace PortalNoticias.Services.ViewModels
{
    public class EntityBase
    {
        public int Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Removido { get; set; }
    }
}

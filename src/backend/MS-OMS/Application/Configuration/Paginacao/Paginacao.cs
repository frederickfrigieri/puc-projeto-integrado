using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application._Configuration.Paginacao
{
    [DataContract]
    public class Paginacao<T>
    {
        [DataMember]
        public IEnumerable<T> Itens { get; set; }
        [DataMember]
        public int TotalRegistros { get; set; }
        [DataMember]

        public int Pagina { get; }
        public int Offset { get; }
        public int Next { get; }

        public Paginacao(int pagina, int registrosPorPagina = 15)
        {
            Pagina = pagina <= 0 ? pagina = 1 : pagina;
            Offset = registrosPorPagina * (pagina - 1);
            Next = registrosPorPagina;
        }
    }
}

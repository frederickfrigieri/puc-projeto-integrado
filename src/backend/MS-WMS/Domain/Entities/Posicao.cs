using Domain._SeedWork;

namespace Domain.Entities
{
    public class Posicao : Entity, IAggregateRoot
    {
        internal Posicao(int numero, string letra)
        {
            Numero = numero;
            Letra = letra;
        }

        private Posicao() { }

        public int Numero { get; private set; }
        public string Letra { get; set; }
    }
}

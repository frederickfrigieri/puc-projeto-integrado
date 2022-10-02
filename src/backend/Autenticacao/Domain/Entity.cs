using System;

namespace Domain
{
    public class Entity
    {
        public DateTime DataCadastro { get; private set; }
        public int Id { get; private set; }

        protected Entity()
        {
            DataCadastro = DateTime.Now;
        }
    }
}

using System;

namespace DevIO.Business.Core.Models
{
    public abstract class Entity
    {
        //Classe base das Entidades
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}

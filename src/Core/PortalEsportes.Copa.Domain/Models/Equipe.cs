using System;

namespace PortalEsportes.Copa.Domain.Models
{
    public class Equipe
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public int Gols { get; private set; }

        public Equipe() {}
        public Equipe(Guid id, string nome, string sigla, int gols)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            Gols = gols;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Equipe;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 911) + Id.GetHashCode();
        }
    }
}

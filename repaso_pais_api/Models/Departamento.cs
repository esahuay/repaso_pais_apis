using System;
using System.Collections.Generic;

namespace repaso_pais_api.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Municipios = new HashSet<Municipio>();
            Tablapais = new HashSet<Tablapai>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Municipio> Municipios { get; set; }
        public virtual ICollection<Tablapai> Tablapais { get; set; }
    }
}

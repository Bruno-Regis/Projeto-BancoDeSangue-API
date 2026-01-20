using BancoDeSangue.Core.Entities;
using BancoDeSangue.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeSangue.Application.Models.InputModels
{
    public class CreateEstoqueSangueInputModel
    {
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRH { get; set; }
        public int QuantidadeMl { get; set; }

        public EstoqueSangue ToEntity()
            => new EstoqueSangue(TipoSanguineo, FatorRH, QuantidadeMl);   
    }
}

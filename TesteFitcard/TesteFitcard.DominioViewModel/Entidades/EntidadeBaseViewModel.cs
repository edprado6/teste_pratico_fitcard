﻿
using System;

namespace TesteFitcard.DominioViewModel.Entidades
{
    /// <summary>
    /// Entidade que possui atributos comuns a diversas outras entidades.
    /// </summary>
    public class EntidadeBaseViewModel
    {
        public string Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public bool Excluido { get; set; }
        public bool Ativo { get; set; }
    }
}

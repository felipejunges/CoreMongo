using System;

namespace CoreMongo.Models.Portocred
{
    public class RoboEnelPropostaResponse
    {
        public string Nome { get; set; }
        public string Concessionaria { get; set; }
        public string RegiaoAtendimento { get; set; }
        public DateTime? DataProximaLeitura { get; set; }
        public DateTime? DataUltimoVencimento { get; set; }
        public DateTime? DataEmissaoFatura { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string NomeMae { get; set; }
    }
}
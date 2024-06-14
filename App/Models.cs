using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Main
    {
       
    }
    
    public class Ano
    {
        public Ano()
        {
            Dias = new List<Dia>();
            GenerateValues();
        }
        
        public List<Dia> Dias {  get; set; }

        private void GenerateValues()
        {

            var dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            for (int i = 1; i <= 365; i++) 
            {
                Dias.Add(new Dia(dataInicial.AddDays(i)));
            }
        }

        public Dia GetFaturamentoMaximo()
        {
            return Dias.OrderByDescending(d => d.Faturamento.Valor).FirstOrDefault();
        }
        public Dia GetFaturamentoMinimo()
        {
            return Dias.OrderByDescending(d => d.Faturamento.Valor).LastOrDefault();
        }

        public int GetQtdFaturamentoAcimaMedia()
        {
            var media = GetMedia();
            return Dias.Where(d => d.Faturamento.Valor > media).Count();
        }

        public decimal GetMedia()
        {
            var qtDiasUteis = Dias.Where(d => d.DiaUtil).Count();
            var soma = Dias.Where(d => d.DiaUtil).Sum(d => d.Faturamento.Valor);
            return soma/qtDiasUteis;
        }



    }
    public class Dia
    {
        public Dia(DateTime diaReferencia)
        {
            DiaReferencia = diaReferencia;
            DiaUtil = true;
            Random random = new Random();
            Faturamento = new Faturamento((decimal) random.NextDouble() * 1000);
            if(diaReferencia.DayOfWeek == DayOfWeek.Saturday || diaReferencia.DayOfWeek == DayOfWeek.Sunday)
            {
                
                DiaUtil = false;
            }
            else
            {
                //probabilidade arbitrátia de um dia ser feriado
                var probabilidade = 0.1;
                var valorGerado = random.NextDouble();
                if(valorGerado <= probabilidade)
                {
                    DiaUtil = false;
                } 
            }
        }
        public string ToString()
        {
            return $"{DiaReferencia} - {DiaUtil} - {Faturamento.Valor}";
        }
        public DateTime DiaReferencia { get; set; }
        public Faturamento Faturamento { get; set; }
        public bool DiaUtil { get; set; }
    }

    public class Faturamento
    {
        public Faturamento(decimal valor)
        {
            Valor = valor;
        }
        public decimal Valor { get; set; }
    }

}

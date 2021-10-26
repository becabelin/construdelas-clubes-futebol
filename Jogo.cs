using System;
using System.Collections.Generic;
using System.Text;

namespace Clubes_Futebol
{
    class Jogo
    {
        public Clube Time1 { get; set; }
        public Clube Time2 { get; set; }
        public int ResultadoTime1 { get; set; }
        public int ResultadoTime2 { get; set; }

        public string Vencedor()
        {
            if (ResultadoTime1 == ResultadoTime2) return "O resultado foi: empate";
            return $"O ganhador do jogo foi o time { ((ResultadoTime1 > ResultadoTime2) ? Time1.Nome : Time2.Nome)}";
        }
    }
}

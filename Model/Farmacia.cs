using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_farmacias.Model
{
    public class Farmacia
    {
        public int Id {get;set;}
        public string? Nome {get;set;}
        public int NIF {get;set;}
        
        public int N_de_telefone{get;set;}
        public  DateTime HoraDeabertura{get;set;}
        public  DateTime HoraDeEncerramento{get;set;}



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministradorDeTareas
{
    class Interrupcion
    {
        public string nombre;
        public int tiempo;
        public float consumoRamMegas;
        public float consumoCpu;
        public int consumoHdd;

        public Interrupcion(string nombre, int tiempo, float consumoRamMegas, float consumoCpu, int consumoHdd)
        {
            this.nombre = nombre;
            this.tiempo = tiempo;
            this.consumoRamMegas = consumoRamMegas;
            this.consumoCpu = consumoCpu;
            this.consumoHdd = consumoHdd;
        }
    }
}

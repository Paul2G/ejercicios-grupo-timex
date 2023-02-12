using System;

namespace ejercicios_grupo_timex
{
    public class Employee
    {
        public int IdRegistro { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaDeRegistroEnSistema { get; set;}

        public Employee(){  }

        public Employee(int IdRegistro, string Nombre, string Apellidos, DateTime FechaNacimiento, DateTime FechaDeRegistroEnSistema){
            this.IdRegistro = IdRegistro;
            this.Nombre = Nombre; 
            this.Apellidos = Apellidos;
            this.FechaNacimiento = FechaNacimiento;
            this.FechaDeRegistroEnSistema = FechaDeRegistroEnSistema;
        }

        public Employee(string Nombre, string Apellidos, DateTime FechaNacimiento){
            this.IdRegistro = IdRegistro;
            this.Nombre = Nombre; 
            this.Apellidos = Apellidos;
            this.FechaNacimiento = FechaNacimiento;
            this.FechaDeRegistroEnSistema = FechaDeRegistroEnSistema;
        }

        public override string ToString(){
            return "{ IdRegistro: "+this.IdRegistro+", Nombre: "+this.Nombre+", Apellidos: "+this.Apellidos+", FechaNacimiento: "+this.FechaNacimiento.ToString()+", FechaRegistroEnSistema: "+this.FechaDeRegistroEnSistema.ToString()+" }";
        }
    }
}

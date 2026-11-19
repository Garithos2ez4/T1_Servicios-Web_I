namespace DSWI_T1_01.ViewModels
{
    public class BecaViewModel
    {
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Asistencia { get; set; }
        public double Promedio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int PorcentajeBeca { get; set; }
        public bool Calculado { get; set; }
    }
}
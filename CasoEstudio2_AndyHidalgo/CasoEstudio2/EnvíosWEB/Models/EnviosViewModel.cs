namespace EnvíosWEB.Models
{
    public class EnviosViewModel
    {
        public int Id { get; set; }
        public string Destinatario { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public double Distancia { get; set; }
        public double Peso { get; set; }
        public string Estado { get; set; } = string.Empty;
        public double Costo { get; set; }
        public string Urgencia { get; set; } = string.Empty;
        public bool EsUrgente { get; set; }
    }
}
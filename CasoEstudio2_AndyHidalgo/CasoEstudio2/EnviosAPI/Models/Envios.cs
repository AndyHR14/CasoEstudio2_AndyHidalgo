namespace EnviosAPI.Models
{
    public enum EnviosState { Pendiente, EnTránsito, Entregado }
    public enum UrgenciaEnvio { Normal, Urgente }
    public class Envios
    {
        public int Id { get; set; }
        public string Destinatario { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public double Distancia { get; set; }
        public double Peso { get; set; }
        public EnviosState Estado { get; set; }
        public UrgenciaEnvio Urgencia { get; set; }
        public double Costo { get; set; }
    }
}

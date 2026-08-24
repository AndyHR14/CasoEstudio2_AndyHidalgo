namespace EnviosAPI.DTOs
{
        public record EnviosDTO(int Id, string Destinatario, string Direccion, double Distancia, double Peso, string Estado, string Urgencia, double Costo);
}

namespace EnviosAPI.DTOs
{
    public record CreateEnviosDTO(string Destinatario, string Direccion, double Distancia, double Peso, bool EsUrgente);
}

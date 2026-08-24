namespace CostosAPI.Services
{
    public interface ICostoService
    {
        double CalcularCosto(double peso, double distancia, bool esUrgente);
    }
}
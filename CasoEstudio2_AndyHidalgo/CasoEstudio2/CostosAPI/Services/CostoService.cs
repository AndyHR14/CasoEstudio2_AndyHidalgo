namespace CostosAPI.Services
{
    public class CostoService : ICostoService
    {
        public double CalcularCosto(double peso, double distancia, bool esUrgente)
        {
            if (peso <= 0 || distancia <= 0)
                throw new ArgumentException("Valores no permitidos");

            double costo = (peso * 2) + (distancia * 0.5);

            if (peso > 10)
                costo += 5.0;

            if (distancia > 100)
                costo += 10.0;

            if (esUrgente)
                costo *= 1.5;

            if (costo < 0) costo = 0;

            return costo;
        }
    }
}
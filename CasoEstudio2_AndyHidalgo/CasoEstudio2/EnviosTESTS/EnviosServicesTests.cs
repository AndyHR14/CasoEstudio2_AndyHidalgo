using CostosAPI.Services;
using Xunit;

namespace EnviosTESTS
{
    public class EnviosServicesTests
    {
        private readonly ICostoService _service;

        public EnviosServicesTests()
        {
            _service = new CostoService();
        }

        /* Escenarios Positivos */

        [Fact]
        public void CalcularCostoPesoYDistanciaNormales()
        {
            var resultado = _service.CalcularCosto(5, 50, false);
            Assert.Equal(35.0, resultado);
        }

        [Fact]
        public void CalcularCostoConRecargoPeso()
        {
            var resultado = _service.CalcularCosto(15, 50, false);
            Assert.Equal(60.0, resultado);
        }

        [Fact]
        public void CalcularCostoConRecargoDistancia()
        {
            var resultado = _service.CalcularCosto(5, 150, false);
            Assert.Equal(95.0, resultado);
        }

        [Fact]
        public void CalcularCostoUrgente()
        {
            var resultado = _service.CalcularCosto(5, 50, true);
            Assert.Equal(52.5, resultado);
        }

        [Fact]
        public void CalcularCostoTodosLosRecargos()
        {
            var resultado = _service.CalcularCosto(15, 150, true);
            Assert.Equal(180.0, resultado);
        }

        /* Escenarios Negativos */

        [Fact]
        public void CalcularCostoPesoCero()
        {
            Assert.Throws<ArgumentException>(() => _service.CalcularCosto(0, 50, false));
        }

        [Fact]
        public void CalcularCostoPesoNegativo()
        {
            Assert.Throws<ArgumentException>(() => _service.CalcularCosto(-5, 50, false));
        }

        [Fact]
        public void CalcularCostoDistanciaCero()
        {
            Assert.Throws<ArgumentException>(() => _service.CalcularCosto(5, 0, false));
        }

        [Fact]
        public void CalcularCostoDistanciaNegativa()
        {
            Assert.Throws<ArgumentException>(() => _service.CalcularCosto(5, -10, false));
        }
    }
}
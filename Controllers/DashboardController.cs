using Microsoft.AspNetCore.Mvc;
using DashboardDemo.Models;

namespace DashboardDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly Random _random = new();

        [HttpGet("empresas")]
        public ActionResult<List<Empresa>> GetEmpresas()
        {
            var empresas = new List<Empresa>
            {
                new() { SeccionID = 1, Nombre = "Constructora ABC" },
                new() { SeccionID = 2, Nombre = "Minera XYZ" },
                new() { SeccionID = 3, Nombre = "Petrolífera DEF" },
                new() { SeccionID = 4, Nombre = "Manufactura GHI" }
            };

            return Ok(empresas);
        }

        [HttpGet("semanas/{empresaId}")]
        public ActionResult<List<Semana>> GetSemanasPorEmpresa(int empresaId)
        {
            var semanas = new List<Semana>();
            for (int i = 1; i <= 20; i++)
            {
                semanas.Add(new Semana
                {
                    SemanaID = i,
                    Descripcion = $"Semana {i:D2}"
                });
            }

            return Ok(semanas);
        }

        [HttpGet("data")]
        public ActionResult<DashboardData> GetDashboardData(int empresaId, [FromQuery] List<int> semanas)
        {
            if (semanas == null || !semanas.Any())
                return BadRequest("Debe seleccionar al menos una semana.");

            var data = GenerateFakeDashboardData(semanas);
            return Ok(data);
        }

        [HttpGet("pages-data")]
        public ActionResult<DashboardPagesData> GetDashboardPagesData(int empresaId, string semanas)
        {
            var semanasList = (semanas ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s, out var n) ? n : (int?)null)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();

            if (!semanasList.Any())
                return BadRequest("Debe seleccionar al menos una semana.");

            var data = GenerateFakePagesData(semanasList);
            return Ok(data);
        }

        private DashboardData GenerateFakeDashboardData(List<int> semanas)
        {
            var data = new DashboardData();

            // Tendencia Semanal
            foreach (var semanaId in semanas.OrderBy(s => s))
            {
                var cartillas = _random.Next(15, 45);
                var observador = _random.Next(8, 20);
                var totalConductas = _random.Next(80, 200);
                var seguras = _random.Next(60, (int)(totalConductas * 0.8));
                var riesgosas = totalConductas - seguras;

                data.TendenciaSemanal.Add(new TendenciaSemanal
                {
                    Semana = $"Semana {semanaId:D2}",
                    Cartillas = cartillas,
                    Observadores = observador,
                    TotalConductas = totalConductas,
                    Seguras = seguras,
                    Riesgosas = riesgosas,
                    PorcentajeSeguras = Math.Round((double)seguras / totalConductas * 100, 2),
                    PorcentajeRiesgosas = Math.Round((double)riesgosas / totalConductas * 100, 2)
                });
            }

            // Cumplimiento Cartillas
            var observadores = new[] { "Juan Pérez", "María García", "Carlos López", "Ana Martínez", "Luis González" };
            foreach (var obs in observadores)
            {
                var programadas = _random.Next(8, 15);
                var reportadas = _random.Next(5, programadas + 2);
                data.CumplimientoCartillas.Add(new CumplimientoCartilla
                {
                    Observador = obs,
                    Reportadas = reportadas,
                    Programadas = programadas,
                    Cumplimiento = Math.Round((double)reportadas / programadas * 100, 2)
                });
            }

            // Cumplimiento Jefes
            var jefes = new[] { "Jefe Roberto Silva", "Supervisor Ana Torres", "Coordinador Miguel Ruiz" };
            foreach (var jefe in jefes)
            {
                var programadas = _random.Next(6, 12);
                var reportadas = _random.Next(4, programadas + 1);
                data.CumplimientoCartillasJefes.Add(new CumplimientoCartilla
                {
                    Observador = jefe,
                    Reportadas = reportadas,
                    Programadas = programadas,
                    Cumplimiento = Math.Round((double)reportadas / programadas * 100, 2)
                });
            }

            // Barreras Conductuales
            var barreras = new[] { "Distracción", "Prisa", "Fatiga", "Falta de Comunicación", "Procedimiento Incorrecto" };
            foreach (var barrera in barreras)
            {
                data.BarrerasConductuales.Add(new BarreraConductual
                {
                    Nombre = barrera,
                    Frecuencia = _random.Next(5, 25)
                });
            }

            // PCEL Data
            var pcels = new[] { "Capacitación", "Equipos", "Liderazgo", "Procedimientos", "Supervisión" };
            foreach (var pcel in pcels)
            {
                data.PcelData.Add(new PcelData
                {
                    Nombre = pcel,
                    Frecuencia = _random.Next(3, 20)
                });
            }

            // KPIs
            data.Kpi = new KpiData
            {
                Cartillas = data.TendenciaSemanal.Sum(t => t.Cartillas),
                Semanas = semanas.Count,
                Observadores = observadores.Length + jefes.Length,
                Seguro = Math.Round(data.TendenciaSemanal.Average(t => t.PorcentajeSeguras), 2),
                Riesgo = Math.Round(data.TendenciaSemanal.Average(t => t.PorcentajeRiesgosas), 2)
            };

            // Pie Horario
            var horarios = new[] { "Mañana", "Tarde", "Noche", "Madrugada" };
            foreach (var horario in horarios)
            {
                data.PieHorario.Add(new PieData
                {
                    Nombre = horario,
                    Porcentaje = Math.Round(_random.NextDouble() * 40 + 10, 2)
                });
            }

            // Pie Frente
            var frentes = new[] { "Área A", "Área B", "Área C", "Área D" };
            foreach (var frente in frentes)
            {
                data.PieFrente.Add(new PieData
                {
                    Nombre = frente,
                    Porcentaje = Math.Round(_random.NextDouble() * 35 + 15, 2)
                });
            }

            return data;
        }

        private DashboardPagesData GenerateFakePagesData(List<int> semanas)
        {
            var data = new DashboardPagesData();

            // Categorías
            var categorias = new[] { "EPP", "Posición del Cuerpo", "Herramientas", "Procedimientos", "Comunicación" };
            data.Categorias = categorias.ToList();

            // Áreas
            var areas = new[] { "Construcción", "Mantenimiento", "Producción", "Logística", "Administración" };
            data.Areas = areas.ToList();

            // Tendencia por Categoría
            foreach (var categoria in categorias)
            {
                var seguras = _random.NextDouble() * 40 + 50; // 50-90%
                data.TendenciaSemanal.Add(new TendenciaCategoria
                {
                    Categoria = categoria,
                    PorcentajeSeguras = Math.Round(seguras, 2),
                    PorcentajeRiesgosas = Math.Round(100 - seguras, 2)
                });
            }

            // Barreras por Barrera
            var barreras = new[] { "Distracción", "Prisa", "Fatiga", "Falta de Comunicación" };
            foreach (var barrera in barreras)
            {
                var items = new List<ItemFrecuencia>();
                for (int i = 1; i <= 3; i++)
                {
                    items.Add(new ItemFrecuencia
                    {
                        Item = $"Item {i} - {barrera}",
                        Frecuencia = _random.Next(2, 10)
                    });
                }

                data.BarrerasConductualesPorBarrera.Add(new BarreraEjeX
                {
                    Barrera = barrera,
                    Frecuencia = items.Sum(i => i.Frecuencia),
                    Items = items
                });
            }

            // Items por Categoría
            foreach (var categoria in categorias)
            {
                var items = new List<ItemCategoria>();
                for (int i = 1; i <= 5; i++)
                {
                    items.Add(new ItemCategoria
                    {
                        Descripcion = $"{categoria} - Item {i}",
                        Estado = _random.NextDouble() > 0.3 ? "Seguro" : "Riesgo"
                    });
                }
                data.ItemsPorCategoria[categoria] = items;
            }

            // Área Riesgo Data
            foreach (var area in areas)
            {
                foreach (var categoria in categorias)
                {
                    for (int i = 0; i < _random.Next(2, 5); i++)
                    {
                        data.AreaRiesgoData.Add(new AreaRiesgoItem
                        {
                            Area = area,
                            Categoria = categoria,
                            Estado = _random.NextDouble() > 0.4 ? "Seguro" : "Riesgo",
                            Barrera = barreras[_random.Next(barreras.Length)],
                            Descripcion = $"Descripción {i + 1} para {categoria} en {area}"
                        });
                    }
                }
            }

            return data;
        }
    }
}
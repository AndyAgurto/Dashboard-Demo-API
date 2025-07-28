namespace DashboardDemo.Models
{
    public class DashboardData
    {
        public List<TendenciaSemanal> TendenciaSemanal { get; set; } = new();
        public List<CumplimientoCartilla> CumplimientoCartillas { get; set; } = new();
        public List<CumplimientoCartilla> CumplimientoCartillasJefes { get; set; } = new();
        public List<BarreraConductual> BarrerasConductuales { get; set; } = new();
        public List<PcelData> PcelData { get; set; } = new();
        public KpiData Kpi { get; set; } = new();
        public List<PieData> PieHorario { get; set; } = new();
        public List<PieData> PieFrente { get; set; } = new();
    }

    public class TendenciaSemanal
    {
        public string Semana { get; set; } = string.Empty;
        public int Cartillas { get; set; }
        public int Observadores { get; set; }
        public int TotalConductas { get; set; }
        public int Seguras { get; set; }
        public int Riesgosas { get; set; }
        public double PorcentajeSeguras { get; set; }
        public double PorcentajeRiesgosas { get; set; }
    }

    public class CumplimientoCartilla
    {
        public string Observador { get; set; } = string.Empty;
        public int Reportadas { get; set; }
        public int Programadas { get; set; }
        public double Cumplimiento { get; set; }
    }

    public class BarreraConductual
    {
        public string Nombre { get; set; } = string.Empty;
        public int Frecuencia { get; set; }
    }

    public class PcelData
    {
        public string Nombre { get; set; } = string.Empty;
        public int Frecuencia { get; set; }
    }

    public class KpiData
    {
        public int Cartillas { get; set; }
        public int Semanas { get; set; }
        public int Observadores { get; set; }
        public double Seguro { get; set; }
        public double Riesgo { get; set; }
    }

    public class PieData
    {
        public string Nombre { get; set; } = string.Empty;
        public double Porcentaje { get; set; }
    }

    public class DashboardPagesData
    {
        public List<TendenciaCategoria> TendenciaSemanal { get; set; } = new();
        public List<BarreraEjeX> BarrerasConductualesPorBarrera { get; set; } = new();
        public List<string> Areas { get; set; } = new();
        public List<string> Categorias { get; set; } = new();
        public Dictionary<string, List<ItemCategoria>> ItemsPorCategoria { get; set; } = new();
        public List<AreaRiesgoItem> AreaRiesgoData { get; set; } = new();
    }

    public class TendenciaCategoria
    {
        public string Categoria { get; set; } = string.Empty;
        public double PorcentajeSeguras { get; set; }
        public double PorcentajeRiesgosas { get; set; }
    }

    public class BarreraEjeX
    {
        public string Barrera { get; set; } = string.Empty;
        public int Frecuencia { get; set; }
        public List<ItemFrecuencia> Items { get; set; } = new();
    }

    public class ItemFrecuencia
    {
        public string Item { get; set; } = string.Empty;
        public int Frecuencia { get; set; }
    }

    public class ItemCategoria
    {
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

    public class AreaRiesgoItem
    {
        public string Area { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Barrera { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }

    public class Empresa
    {
        public int SeccionID { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class Semana
    {
        public int SemanaID { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}

namespace ConsoleSubteEstadisticas
{
    public class SubteStatus
    {
        public string Linea { get; set; }

        public SubteDetalle Detalle { get; set; }

    }

    public class SubteDetalle
    {
        public string Status { get; set; }

        public string Text { get; set; }
    }
}

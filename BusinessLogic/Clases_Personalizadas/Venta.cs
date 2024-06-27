namespace BusinessLogic.Clases_Personalizadas
{
    public class Venta
    {
        public string ID { get; set; }
        public decimal IMPORTE_TOTAL { get; set; }
        public int CANT_PRODUCTOS { get; set; }
        public System.DateTime FECHA { get; set; }
        public string ID_USUARIO { get; set; }
        public bool ESTATUS { get; set; }
        public System.Collections.Generic.List<SubVenta> SUB_VENTAS { get; set; }

        public string NOMBRE_USUARIO { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;

namespace XMART_Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class VentasController : ControllerBase
    {
        [System.Web.Http.HttpGet]
        public IEnumerable<object> ObtenerListaAutoComplete()
        {
            try
            {
                var _respuesta = new BusinessLogic.Metodos.Apis().ObtenerVentasSimple();
                return _respuesta;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}

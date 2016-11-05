using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace Universe.Controllers
{
    public class homeController : ApiController
    {

        // POST: api/home
        // public JObject Post([FromBody]string valueToUppercase)
        [HttpPost]
      //  [ActionName("word")]
        public HttpResponseMessage word()

        {
            var valueToUppercase = "hola1";

            //Validamos que no contenga numero u otros caracteres
            bool isString = Regex.IsMatch(valueToUppercase, @"^[a-zA-Z]+$"); //devuelve true si solo encuentra letras.
            
            if (!string.IsNullOrEmpty(valueToUppercase))
            {
                // retornamos error 500 si no contiene solamente letras el parametro.
                if (!isString) return Request.CreateResponse(HttpStatusCode.InternalServerError);

                //var json = JObject.Parse("{'code':'00', 'description':'OK', 'data':'" + valueToUppercase.ToUpper() + "'}");
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent("{'code':'00', 'description':'OK', 'data':'" + valueToUppercase.ToUpper() + "'}", System.Text.Encoding.UTF8, "application/json");
                return response;
                //return JObject.Parse("{'code':'00', 'description':'OK', 'data':'" + valueToUppercase.ToUpper() + "'}");
            }
            else
            {
                //error 400
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                
                //error 500
                //return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        public HttpResponseMessage Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                DateTime hora = new DateTime();
                DateTime.TryParse(id, CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AssumeUniversal, out hora);

                if (hora > DateTime.MinValue)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("{'code':'00', 'description':'OK', 'data':'" + hora + "'}", System.Text.Encoding.UTF8, "application/json");
                    return response;

                }
                else return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
            return Request.CreateResponse(HttpStatusCode.BadRequest);
            
        }



    }
}

/*
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;

namespace ApiWeb.Controllers
{
    public class HomeController : ApiController
    {
        // GET api/home/5
        public JObject Get(string id)
        {
            DateTime hora = new DateTime();
            DateTime.TryParse(id, CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out hora);

            if (hora > DateTime.MinValue) return JObject.Parse("{'code':'00', 'description':'OK', 'data':'" + hora + "'}");

            return JObject.Parse("{'code':'" + HttpStatusCode.InternalServerError + "', 'description':'OK', 'data':'" + hora + "'}");
        }

        // POST api/home
        public JObject Post([FromBody]string value)
        {
            if (!string.IsNullOrEmpty(value) && !value.All(char.IsDigit)) return JObject.Parse("{'code':'00', 'description':'OK', 'data':'" + value.ToUpper() + "'}");

            return JObject.Parse("{'code':" + HttpStatusCode.BadRequest + ", 'description':'Error', 'data':'Error con convert" + value + "'}"); ;
        }
    }
}
*/

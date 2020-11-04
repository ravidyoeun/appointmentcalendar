using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appointmentcalendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace appointmentcalendar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private readonly string ApiKey = "NBGNHPIEO33SYGCBOEM443XP7RWDAVSY";

        private readonly ILogger<WeatherForecastController> _logger;

        public WebhookController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpPost]
        public ActionResult<WebhookPayload> InsertDataFromCalendly(WebhookPayload payload)
        {
            var client = new RestClient("https://www.bshpersona.com/personaAPI/data/LeadSubmitData");
            // need to transform the requestObj
            var requestObj = new
            {
                userID = string.Empty,
                promoID = "192",
                sessionID = string.Empty,
                firstName = payload.payload.invitee.name,
                lastName = payload.payload.invitee.last_name,
                email = payload.payload.invitee.email,
                phone = payload.payload.questions_and_answers.Where(e => e.question.Equals("Phone", StringComparison.OrdinalIgnoreCase)).Select(y => y.answer).FirstOrDefault(),
                zipCode = payload.payload.questions_and_answers.Where(e => e.question.Equals("Postal Code", StringComparison.OrdinalIgnoreCase)).Select(y => y.answer).FirstOrDefault(),
            };
            var payLoad = CommonUtils.Functions.JSONtoStringConvertMethod(requestObj);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", payLoad, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return payload;
        }


    }
}

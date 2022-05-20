using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oghabian.Controllers
{
    public class OrderController : Controller
    {
        string authority;
        //public IActionResult Payment()
        //{


        //    try
        //    {
        //        RequestParameters Parameters = new RequestParameters(merchant, amount, description, callbackurl, "", "");
        //        var client = new RestClient(URLs.requestUrl);
        //        Method method = Method.Post;
        //        var request = new RestRequest("", method);
        //        request.AddHeader("accept", "application/json");
        //        request.AddHeader("content-type", "application/json");
        //        request.AddJsonBody(Parameters);
        //        var requestresponse = client.ExecuteAsync(request);
        //        JObject jo = JObject.Parse(requestresponse.Result.Content);
        //        string errorscode = jo["errors"].ToString();
        //        JObject jodata = JObject.Parse(requestresponse.Result.Content);
        //        string dataauth = jodata["data"].ToString();
        //        if (dataauth != "[]")
        //        {
        //            authority = jodata["data"]["authority"].ToString();
        //            string gatewayUrl = URLs.gateWayUrl + authority;
        //            return Redirect(gatewayUrl);
        //        }
        //        else
        //        {
        //            return BadRequest("error " + errorscode);
        //        }


        //    }

        //    catch (Exception ex)
        //    {
        //        //    throw new Exception(ex.Message);


        //    }
        //    return null;
        //}

        //public IActionResult VerifyPayment()
        //{

        //    // string authorityverify;

        //    try
        //    {
        //        VerifyParameters parameters = new VerifyParameters();


        //        if (HttpContext.Request.Query["Authority"] != "")
        //        {
        //            authority = HttpContext.Request.Query["Authority"];
        //        }

        //        parameters.authority = authority;
        //        parameters.amount = amount;
        //        parameters.merchant_id = merchant;


        //        var client = new RestClient(URLs.verifyUrl);
        //        Method method = Method.Post;
        //        var request = new RestRequest("", method);

        //        request.AddHeader("accept", "application/json");

        //        request.AddHeader("content-type", "application/json");
        //        request.AddJsonBody(parameters);

        //        var response = client.ExecuteAsync(request);


        //        JObject jodata = JObject.Parse(response.Result.Content);

        //        string data = jodata["data"].ToString();

        //        JObject jo = JObject.Parse(response.Result.Content);

        //        string errors = jo["errors"].ToString();

        //        if (data != "[]")
        //        {
        //            string refid = jodata["data"]["ref_id"].ToString();

        //            ViewBag.code = refid;

        //            return View();
        //        }
        //        else if (errors != "[]")
        //        {

        //            string errorscode = jo["errors"]["code"].ToString();

        //            return BadRequest($"error code {errorscode}");

        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //    return NotFound();
        //}

        //public async Task<IActionResult> PaymenBytHttpClient()
        //{


        //    try
        //    {

        //        using (var client = new HttpClient())
        //        {
        //            RequestParameters parameters = new RequestParameters(merchant, amount, description, callbackurl, "", "");

        //            var json = JsonConvert.SerializeObject(parameters);

        //            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        //            HttpResponseMessage response = await client.PostAsync(URLs.requestUrl, content);

        //            string responseBody = await response.Content.ReadAsStringAsync();

        //            JObject jo = JObject.Parse(responseBody);
        //            string errorscode = jo["errors"].ToString();

        //            JObject jodata = JObject.Parse(responseBody);
        //            string dataauth = jodata["data"].ToString();


        //            if (dataauth != "[]")
        //            {


        //                authority = jodata["data"]["authority"].ToString();

        //                string gatewayUrl = URLs.gateWayUrl + authority;

        //                return Redirect(gatewayUrl);

        //            }
        //            else
        //            {

        //                return BadRequest("error " + errorscode);


        //            }

        //        }


        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);


        //    }
        //    return NotFound();
        //}

        //public async Task<IActionResult> VerifyByHttpClient()
        //{
        //    try
        //    {

        //        VerifyParameters parameters = new VerifyParameters();


        //        if (HttpContext.Request.Query["Authority"] != "")
        //        {
        //            authority = HttpContext.Request.Query["Authority"];
        //        }

        //        parameters.authority = authority;

        //        parameters.amount = amount;

        //        parameters.merchant_id = merchant;


        //        using (HttpClient client = new HttpClient())
        //        {

        //            var json = JsonConvert.SerializeObject(parameters);

        //            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        //            HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);

        //            string responseBody = await response.Content.ReadAsStringAsync();

        //            JObject jodata = JObject.Parse(responseBody);

        //            string data = jodata["data"].ToString();

        //            JObject jo = JObject.Parse(responseBody);

        //            string errors = jo["errors"].ToString();

        //            if (data != "[]")
        //            {
        //                string refid = jodata["data"]["ref_id"].ToString();

        //                ViewBag.code = refid;

        //                return View();
        //            }
        //            else if (errors != "[]")
        //            {

        //                string errorscode = jo["errors"]["code"].ToString();

        //                return BadRequest($"error code {errorscode}");

        //            }
        //        }



        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return NotFound();
        //}
    }
}

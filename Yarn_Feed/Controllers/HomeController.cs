using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestClient.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Yarn_Feed.Models;

namespace Yarn_Feed.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string currentToken = "1eKyKhrGpPfwG6zyV8WxNQe3Ij5r9ecPmw9FKoLHSq4.E1tt5CPa2aI4C8XjcVCPjb1j42vO0R-EphAlWO6jyKY";
        string authURL = "https://www.ravelry.com";
        string accessTokenURL = "https://www.ravelry.com/oauth2/token";
        string scope = "offline";
        string clientId = "4fd8d5f73981b822d5c51a634e441d28";
        string clientSecret = "QPNGys9Ld1Y4T/gtW5c/pHQXnzNiK0iifW39IyDD";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            //PostShop shopFound = null;
            PostProject projectFound = null;
            CurrentUser currentUser;
            ApiToken apiToken;
            string errorString;

            //try
            //{
            //    using (var httpclient = new HttpClient())
            //    {
            //        using (var request = new HttpRequestMessage(new HttpMethod("get"), "https://api.ravelry.com/shops/2588.json?include=brands+ad"))
            //        {
            //            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("read-eacbe5950cc441073c7d5fbb94aac112:q1tdrhdrfmcnyc9rcmacyh6hhzd+jievluuy+cjj"));
            //            request.Headers.TryAddWithoutValidation("authorization", $"basic {base64authorization}");

            //            var response = await httpclient.SendAsync(request);
            //            string result = await response.Content.ReadAsStringAsync();
            //            shopFound = JsonConvert.DeserializeObject<PostShop>(result);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    errorString = $"There was a error getting our Shop: {ex.Message}";
            //}


            //POST Request to get the access Token
            ////try
            ////{
            ////    using (var httpClient = new HttpClient())
            ////    {
            ////        using (var request = new HttpRequestMessage(new HttpMethod("POST"), accessTokenURL))
            ////        {
            ////            request.Headers.TryAddWithoutValidation("Accept", "application/json");
            ////            request.Headers.TryAddWithoutValidation("Accept-Language", "en_US");
            ////            request.Headers.TryAddWithoutValidation("Host", "www.ravelry.com");

            ////            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret));
            ////            request.Headers.TryAddWithoutValidation("Authorization", "Basic " + base64authorization);

            ////            request.Content = new StringContent("grant_type=client_credentials");
            ////            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

            ////            var response = await httpClient.SendAsync(request);
            ////            string result = await response.Content.ReadAsStringAsync();
            ////            apiToken = JsonConvert.DeserializeObject<ApiToken>(result);
            ////            currentToken = apiToken.access_token;
            ////        }
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    errorString = $"There was a error getting our Shop: {ex.Message}";
            ////}

            //////GET Request using the Access Token
            ////try
            ////{
            ////    using (var httpClient = new HttpClient())
            ////    {
            ////        using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/current_user.json"))
            ////        {
            ////            request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + currentToken);

            ////            var response = await httpClient.SendAsync(request);
            ////            string result = await response.Content.ReadAsStringAsync();
            ////            currentUser = JsonConvert.DeserializeObject<CurrentUser>(result);
            ////        }
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    errorString = $"There was a error getting our Shop: {ex.Message}";
            ////}



            //PostStash postStash = null;
            //using (var httpClient = new HttpClient())
            //{
            //    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.ravelry.com/people/zacb/stash/18830802.json"))
            //    {
            //        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + currentToken);

            //        var response = await httpClient.SendAsync(request);
            //        string result = await response.Content.ReadAsStringAsync();
            //        //postStash = JsonConvert.DeserializeObject<PostStash>(result);
            //    }
            //}

            return View();
        }

        //public async Task<string> GetAPI(string apiPath)
        //{

        //    var baseUri = new Uri("https://www.ravelry.com");
        //    //var encodedConsumerKey = HttpUtility.UrlEncode("111111111111");
        //    //var encodedConsumerKeySecret = HttpUtility.UrlEncode("222222222222");
        //    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret));

        //    var requestToken = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(baseUri, "oauth2/token"),
        //        Content = new StringContent("grant_type=client_credentials")
        //    };

        //    requestToken.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };
        //    requestToken.Headers.TryAddWithoutValidation("Authorization", String.Format("Basic {0}", base64authorization));

        //    var bearerResult = await SendAsync(requestToken);
        //    var bearerData = await bearerResult.Content.ReadAsStringAsync();
        //    var bearerToken = JObject.Parse(bearerData)["access_token"].ToString();

        //    var requestData = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(baseUri, apiPath),
        //    };
        //    requestData.Headers.TryAddWithoutValidation("Authorization", String.Format("Bearer {0}", bearerToken));

        //    var results = await SendAsync(requestData);
        //    return await results.Content.ReadAsStringAsync();

        //}

        //{\"access_token\":\"gDG5cCb4EkU-Tpnc43827-MRmNfGbYH4JDha8PZi9lk.MvLCqSc7weQL1MdIpOF5rp1iOZIZrBpL9sf3Mo78vic\",\"expires_in\":3599,\"scope\":\"\",\"token_type\":\"bearer\"}


        //string clientId = "a1s2d3f4g4h5j6k7l8m9n1b2v3c4";
        //string clientSecret = "z1x2c3v4b4n5m6l1k2j3h4g5f6d7s8";
        //string apikey = "o1i2u3y4t5r6e7w8q9a1s2d3f4g5h6j6k7l8";
        //string createNewUserJson;
        //string searchUserJson;
        //string accessToken;
        //EmployeeRegisterationResponse registerUserResponse = null;
        //EmployeeSearchResponse empSearchResponse = null;
        //GetSecurityQuestionsResponse getSecurityQueResponse = null;
        //GetCountryNamesResponse getCountryResponse = null;


        //public async void InvokeMethod()
        //{
        //    Task<string> getAccessToken = GenerateAccessToken();
        //    accessToken = await getAccessToken;

        //    Task<EmployeeRegisterationResponse> registerResponse = EmployeeRegistration(accessToken);
        //    registerUserResponse = await registerResponse;

        //    Task<EmployeeSearchResponse> employeeSearchResponse = EmployeeSearch(accessToken);
        //    empSearchResponse = await employeeSearchResponse;

        //    Task<GetSecurityQuestionsResponse> getSecurityResponse = GetSecretQuestions(accessToken);
        //    getSecurityQueResponse = await getSecurityResponse;

        //    Task<GetCountryNamesResponse> getCountryNamesResponse = GetCountryNames(accessToken);
        //    getCountryResponse = await getCountryNamesResponse;
        //}


        //public async Task<string> GenerateAccessToken()
        //{
        //    AccessTokenResponse token = null;

        //    try
        //    {
        //        HttpClient client = HeadersForAccessTokenGenerate();
        //        string body = "grant_type=client_credentials&scope=public";
        //        client.BaseAddress = new Uri(accessTokenURL);
        //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
        //        request.Content = new StringContent(body,
        //                                            Encoding.UTF8,
        //                                            "application/x-www-form-urlencoded");//CONTENT-TYPE header  

        //        List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

        //        postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
        //        postData.Add(new KeyValuePair<string, string>("scope", "public"));

        //        request.Content = new FormUrlEncodedContent(postData);
        //        HttpResponseMessage tokenResponse = client.PostAsync(baseUrl, new FormUrlEncodedContent(postData)).Result;

        //        //var token = tokenResponse.Content.ReadAsStringAsync().Result;    
        //        token = await tokenResponse.Content.ReadAsAsync<AccessTokenResponse>(new[] { new JsonMediaTypeFormatter() });
        //    }


        //    catch (HttpRequestException ex)
        //    {
        //        throw ex;
        //    }
        //    return token != null ? token.AccessToken : null;

        //}




        //private HttpClient HeadersForAccessTokenGenerate()
        //{
        //    HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
        //    HttpClient client = new HttpClient(handler);
        //    try
        //    {
        //        client.BaseAddress = new Uri(baseUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        //        client.DefaultRequestHeaders.Add("apikey", apikey);
        //        client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(
        //                 System.Text.ASCIIEncoding.ASCII.GetBytes(
        //                    $"{clientId}:{clientSecret}")));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return client;
        //}




        //public static async Task<string> GetAuthorizeToken()
        //{
        //    // Initialization.  
        //    string responseObj = string.Empty;

        //    // Posting.  
        //    using (var client = new HttpClient())
        //    {
        //        // Setting Base address.  
        //        client.BaseAddress = new Uri("http://localhost:3097/");

        //        // Setting content type.  
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // Initialization.  
        //        HttpResponseMessage response = new HttpResponseMessage();
        //        List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();

        //        // Convert Request Params to Key Value Pair.  

        //        // URL Request parameters.  
        //        HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

        //        // HTTP POST  
        //        response = await client.PostAsync("Token", requestParams).ConfigureAwait(false);

        //        // Verification  
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Reading Response.  

        //        }
        //    }

        //    return responseObj;
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

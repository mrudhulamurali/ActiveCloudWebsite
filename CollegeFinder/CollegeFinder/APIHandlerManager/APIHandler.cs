using CollegeFinder.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CollegeFinder.APIHandlerManager
{    public class APIHandler
    {
        static string BASE_URL = "https://api.data.gov/ed/collegescorecard/v1/";
        static string API_KEY = "WT8A0ycSKdLnYBeaxSvr4V8JknT6S7OCTg4d28qH"; //Add your API key here inside ""

        HttpClient httpClient;
        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public Rootobject GetCollegeDetails(int collegeid)
        {

            string COLLEGE_SCORECARD_API_PATH = BASE_URL + "schools.json?id=" + collegeid.ToString() +
                "&keys_nested=true&fields=id,school.name,school.city,school.state,latest.admissions.admission_rate.overall," +
                "latest.admissions.sat_scores.average.overall,school.accreditor,school.school_url";

            string collDetail = "";

            Rootobject college = null;

            httpClient.BaseAddress = new Uri(COLLEGE_SCORECARD_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            //try
            //{
            HttpResponseMessage response = httpClient.GetAsync(COLLEGE_SCORECARD_API_PATH).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                collDetail = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            //Clipboard.SetText(collDetail);

            if (!collDetail.Equals(""))
            {
                // JsonConvert is part of the NewtonSoft.Json Nuget package
                college = JsonConvert.DeserializeObject<Rootobject>(collDetail);
            }
            return college;
        }

        public Rootobject popularcollegelist()
        {
            string COLLEGE_SCORECARD_API_PATH = BASE_URL +
            "schools.json?latest.admissions.admission_rate.overall__range=0.972..0.99&keys_nested=true&fields=id," +
            "school.name,school.state,school.city,latest.admissions.admission_rate.overall&page=1";
            string collDetail = "";

            Rootobject college1 = null;

            httpClient.BaseAddress = new Uri(COLLEGE_SCORECARD_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            //try
            //{
            HttpResponseMessage response = httpClient.GetAsync(COLLEGE_SCORECARD_API_PATH).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                collDetail = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            //Clipboard.SetText(collDetail);

            if (!collDetail.Equals(""))
            {
                // JsonConvert is part of the NewtonSoft.Json Nuget package
                college1 = JsonConvert.DeserializeObject<Rootobject>(collDetail);
            }
            return college1;
        }
    }
}

using System;
using Microsoft.AspNetCore.Http;

namespace DatiingApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");   
            response.Headers.Add("Access-Control-Allow-Origin", "*"); 
        }
    

        public static int GetAge(this DateTime dateTime)
        {
             var ageS = DateTime.Today.Year - dateTime.Year;
             if(dateTime.AddYears(ageS) > DateTime.Today)
                ageS--;
            
            return ageS;

        }
    }
}
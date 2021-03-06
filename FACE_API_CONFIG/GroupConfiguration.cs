﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FACE_API_CONFIG
{
    class GroupConfiguration
    {
        public static string APIkey = ConfigurationManager.AppSettings["APIkey"];


 
        /// <summary>
        /// Create a new person group with specified personGroupId, name and user-provided userData. 
        /// </summary>
        /// <param name="personGroupId">Person group display name.The maximum length is 128.</param>
        /// <param name="groupInfo">User-provided data attached to the person group.The size limit is 16KB.</param>
        public static async void CreateGroup(string personGroupId, string groupInfo)
        {

            var client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", APIkey);

            // Assemble the URI for the REST API Call.
            string uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/" + personGroupId;

            // Form Json string to be sended 
            string json = "{\"name\":\"" + personGroupId + "\", \"userData\":\"" + groupInfo + "\"}";
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Execute the REST API call.
            HttpResponseMessage response = await client.PutAsync(uri, content);

            // Display the Response status. 200 is ok
            Console.WriteLine("Response status: " + response.StatusCode);

        }


        /// <summary>
        /// Delete an existing person group. Persisted face images of all people in the person group will also be deleted.
        /// </summary>
        /// <param name="personGroupId">The personGroupId of the person group to be deleted.</param>
        public static async void DeleteGroup(string personGroupId)
        {

            var client = new HttpClient();
            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", APIkey);
            // Assemble the URI for the REST API Call.
            string uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/" + personGroupId;
            // Execute the REST API call.
            HttpResponseMessage response = await client.DeleteAsync(uri);
            // Display the Response status. 200 is ok
            Console.WriteLine("Response status: " + response.StatusCode);


        }
    }
}

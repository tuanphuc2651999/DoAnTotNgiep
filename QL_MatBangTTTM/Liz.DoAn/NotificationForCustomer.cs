﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Liz.DoAn
{
    public class NotificationForCustomer
    {
        public class Notification
        {
            public string title { get; set; }
            public string body { get; set; }
            public string mutable_content { get; set; }
            public string sound { get; set; }
        }

        public class Root
        {
            public string to { get; set; }
            public Notification notification { get; set; }
        }

        string url = "https://fcm.googleapis.com/fcm/send";
        public string ThongBaoChoKhachHang()
        {
            Root r = new Root
            {
                to = "fFJR9fIHxno:APA91bEAIMu58g79c337nsL41w-tkNFoiFNEYlJeegZ3UTPWGEt_zs1AhIK2j-hkivLhNP4lVyTgq-mCrj0IP6Z1qwOH7ZI6c3o5-_Drr3RGxbRn3TTAPXJ5imCYDHOdQPHIEunnhx7X",
                notification = new Notification
                {
                    title = "test",
                    body = "đây là body",
                    mutable_content = "True",
                    sound = "Tri-tone"
                }

            };
            string json = JsonConvert.SerializeObject(r);

            IRestClient url = new RestClient("https://fcm.googleapis.com/");

            IRestRequest api = new RestRequest("fcm/send", Method.POST);

            api.AddHeader("Content-Type", "application/json");
            api.AddHeader("Authorization", "key=AAAAZ9ltHxE:APA91bGydUPOIgdntAMfffeTaqhVKnag4pcBlyE3No83y2bS75lCC5EyYpmfU794waIXq_Ft4zj85D0DJlxisIXOtouc6xDQJp51vdF0Pg8jOmsBlMVIE8l9VnfmvgZFw6w9ngSQc5Fz");

            api.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse res = url.Execute(api);

            string a = res.Content;
            return res.Content;
        }
    }
}

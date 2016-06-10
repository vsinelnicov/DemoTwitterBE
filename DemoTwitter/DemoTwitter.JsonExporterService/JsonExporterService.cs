using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;

namespace DemoTwitter.JsonExporterService
{


    public class JsonExporterService : IJsonExporterService
    {

        private readonly ITweetBL tweetBL;

        public JsonExporterService(ITweetBL tweetBL)
        {
            this.tweetBL = tweetBL;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string GetAllTweets()
        {
            var allTweets = tweetBL.GetAll();
            string output = new JavaScriptSerializer().Serialize(allTweets);
            return output;
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

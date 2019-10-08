using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;
using System.Data.Linq;

namespace MapsRouteLocator.Business
{
    public class GoogleLocationsDataProvider : ILocationsDataProvider
    {
        private readonly ILocationsQueryProvider googleLocationsQueryProvider;
        public GoogleLocationsDataProvider(ILocationsQueryProvider googleLocationsQueryProvider)
        {
            this.googleLocationsQueryProvider = googleLocationsQueryProvider;
        }

        public IEnumerable<LocationData> GetLocationsList(string prefix)
        {
            var queryString = this.googleLocationsQueryProvider.GetLocationsQuery(prefix);

            DataSet ds = new DataSet();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);
            WebResponse response = request.GetResponse();
            try
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));
            }
            catch (Exception ex)
            {
            }
            finally
            {
                response.Close();
            }

            var status = ds.Tables["FindPlaceFromTextResponse"].Rows[0]["status"];
            var candidates = ds.Tables["candidates"];

            if (status.ToString().ToLower() != "ok")
            {
                return null;
            }

            if (candidates.Rows.Count == 0)
            {
                return null;
            }

            var results = candidates.AsEnumerable().Select(x => new LocationData() {Name = x.Field<string>("name")});

            return results;
        }
    }
}

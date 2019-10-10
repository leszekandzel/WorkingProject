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
using log4net;

namespace MapsRouteLocator.Business
{
    public class GoogleLocationsDataProvider : ILocationsDataProvider
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GoogleLocationsDataProvider));
        private readonly ILocationsQueryProvider googleLocationsQueryProvider;
        public GoogleLocationsDataProvider(ILocationsQueryProvider googleLocationsQueryProvider)
        {

            this.googleLocationsQueryProvider = googleLocationsQueryProvider;
        }

        // Having more time I would redesign it. There is an option to get JSon format. I would have to try it somehow...
        public async Task<IEnumerable<LocationData>> GetLocationsListAsync(string prefix)
        {
            var queryString = this.googleLocationsQueryProvider.GetLocationsQuery(prefix);

            var ds = new DataSet();

            HttpWebRequest request;
            WebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(queryString);
                response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                var dataStream = response.GetResponseStream();
                
                var reader = new StreamReader(dataStream);
                var responsereader = reader.ReadToEnd();
                ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));
            }
            catch (Exception ex)
            {
                log.Error("GoogleLocationsDataProvider could not fetch data from google maps api", ex);
            }
            finally
            {
                if(response != null)
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

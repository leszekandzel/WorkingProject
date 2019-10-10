using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class GoogleRoutesExistenceValidator : IRoutesExistenceValidator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GoogleRoutesExistenceValidator));
        private readonly IRoutesExistanceQueryProvider googleRoutesExistenceQueryProvider;

        public GoogleRoutesExistenceValidator(IRoutesExistanceQueryProvider googleRoutesExistenceQueryProvider)
        {
            this.googleRoutesExistenceQueryProvider = googleRoutesExistenceQueryProvider;
        }

            // Having more time I would redesign it. There is an option to get JSon format. I would have to try it somehow...
            public async Task<bool> ValidateRouteFound(RouteCalculationRequestData routeCalculationRequestData)
            {
                var queryString = this.googleRoutesExistenceQueryProvider.GetRoutesQuery(routeCalculationRequestData);

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
                    response?.Close();
                }

                var status = ds.Tables["DirectionsResponse"].Rows[0]["status"];

                return status.ToString().ToUpper() != "NOT_FOUND";
            }
    }
}

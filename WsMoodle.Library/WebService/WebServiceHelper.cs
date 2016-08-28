// <copyright file="WebServiceHelper.cs" company="SmartIT Technologies LLC.">
// Copyright SmartIT Technologies LLC. Todos os direitos reservados.
// </copyright>
// <author>Eduardo Claudio Nicacio</author>
// <date>23/04/2015</date>

namespace WsMoodle.Library.WebService
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Web.Services.Protocols;

    /// <summary>
    /// Webservice auxiliary methods.
    /// </summary>
    /// <typeparam name="TWS">Type WebService. See also <seealso cref="SoapHttpClientProtocol"/>.</typeparam>
    public class WebServiceHelper<TWS> where TWS : SoapHttpClientProtocol, new()
    {
        #region Private attributes

        /// <summary>
        /// Does it use Proxy?
        /// </summary>
        private readonly string useProxy = ConfigurationManager.AppSettings["UseProxy"];

        /// <summary>
        /// Proxy username.
        /// </summary>
        private readonly string username = ConfigurationManager.AppSettings["ProxyUsername"];

        /// <summary>
        /// Proxy password.
        /// </summary>
        private readonly string password = ConfigurationManager.AppSettings["ProxyPassword"];

        /// <summary>
        /// Proxy domain.
        /// </summary>
        private readonly string domain = ConfigurationManager.AppSettings["ProxyDomain"];

        /// <summary>
        /// Proxy address.
        /// </summary>
        private readonly string proxy = ConfigurationManager.AppSettings["ProxyUrl"];

        /// <summary>
        /// Webservice address.
        /// </summary>
        private readonly string webServiceUrl = ConfigurationManager.AppSettings["WebserviceUrl"];

        /// <summary>
        /// Does it move forward in case of error.
        /// </summary>
        private readonly string expectContinue = ConfigurationManager.AppSettings["ExpectContinue"];

        /// <summary>
        /// Proxy port.
        /// </summary>
        private readonly int port = int.Parse(ConfigurationManager.AppSettings["Port"]);

        /// <summary>
        /// See <seealso cref="SoapHttpClientProtocol"/>.
        /// </summary>
        private readonly TWS tws;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceHelper" /> class.
        /// </summary>
        public WebServiceHelper()
        {
            try
            {
                // Creates a new instance
                tws = new TWS();

                if (useProxy.ToUpperInvariant().Equals("TRUE"))
                {
                    // Creates a new Network Credential
                    NetworkCredential nc = new NetworkCredential(username, password, domain);

                    // Creates a new Webproxy
                    WebProxy wp = new WebProxy(proxy, port);

                    // Sets the WebProxy network credentials
                    wp.Credentials = nc;

                    // Sets the proxy
                    tws.Proxy = wp;
                }

                ServicePointManager.Expect100Continue = !"FALSE".Equals(expectContinue.ToUpperInvariant());

                tws.Url = webServiceUrl;
            }
            catch (UriFormatException ufe)
            {
                throw new UriFormatException("WebServiceHelper Error: " + ufe.Message);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("WebServiceHelper Error: " + ioe.Message);
            }
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the Service.
        /// </summary>
        public TWS Service
        {
            get { return tws; }
        }

        #endregion
    }
}
using Blog.Core;
using Blog.Core.Data.Services.Security;
using Blog.Core.Data.Services.Usuario;
using Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Web.Framework
{
    /// <summary>
    /// Work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        #region Const

        private const string CustomerCookieName = "Blog.customer";

        #endregion

        #region Fields

        private readonly HttpContextBase _httpContext;

        private Usuarios _cachedCustomer;
        private Usuarios _originalCustomerIfImpersonated;
        private IUsuarioService _usuarioService;
        private IAuthenticationService _authenticationService;

        #endregion

        #region Ctor

        public WebWorkContext(HttpContextBase httpContext,
            IUsuarioService usuarioService,
            IAuthenticationService authenticationService)
        {
            this._httpContext = httpContext;
            this._authenticationService = authenticationService;
            this._usuarioService = usuarioService;
        }

        #endregion

        #region Utilities

        protected virtual HttpCookie GetCustomerCookie()
        {
            if (_httpContext == null || _httpContext.Request == null)
                return null;

            return _httpContext.Request.Cookies[CustomerCookieName];
        }

        protected virtual void SetCustomerCookie(Guid customerGuid)
        {
            if (_httpContext != null && _httpContext.Response != null)
            {
                var cookie = new HttpCookie(CustomerCookieName);
                cookie.HttpOnly = true;
                cookie.Value = customerGuid.ToString();
                if (customerGuid == Guid.Empty)
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24 * 365; //TODO make configurable
                    cookie.Expires = DateTime.Now.AddHours(cookieExpires);
                }

                _httpContext.Response.Cookies.Remove(CustomerCookieName);
                _httpContext.Response.Cookies.Add(cookie);
            }
        }

    
  
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        public virtual Usuarios CurrentUsuario
        {
            get
            {
                if (_cachedCustomer != null)
                    return _cachedCustomer;

                Usuarios customer = null;
                if (_httpContext == null || _httpContext is FakeHttpContext)
                {
                    //check whether request is made by a background task
                    //in this case return built-in customer record for background task
                    customer = _usuarioService.GetUsuarioBySistema("BackgroundTask");
                }

                //check whether request is made by a search engine
                //in this case return built-in customer record for search engines 
                //or comment the following two lines of code in order to disable this functionality
               

                //registered user
                if (customer == null ||  !customer.ativo.Value)
                {
                    customer = _authenticationService.GetAuthenticatedCustomer();
                }

                //impersonate user if required (currently used for 'phone order' support)
                //if (customer != null &&  customer.ativo.Value)
                //{
                //    var impersonatedCustomerId = customer.GetAttribute<int?>(SystemCustomerAttributeNames.ImpersonatedCustomerId);
                //    if (impersonatedCustomerId.HasValue && impersonatedCustomerId.Value > 0)
                //    {
                //        var impersonatedCustomer = _usuarioService.GetUsuarioById(impersonatedCustomerId.Value);
                //        if (impersonatedCustomer != null && impersonatedCustomer.ativo.Value)
                //        {
                //            //set impersonated customer
                //            _originalCustomerIfImpersonated = customer;
                //            customer = impersonatedCustomer;
                //        }
                //    }
                //}

                //load guest customer
                if (customer == null || !customer.ativo.Value)
                {
                    var customerCookie = GetCustomerCookie();
                    if (customerCookie != null && !String.IsNullOrEmpty(customerCookie.Value))
                    {
                        Guid customerGuid;
                        if (Guid.TryParse(customerCookie.Value, out customerGuid))
                        {
                            var customerByCookie = _usuarioService.GetUsuarioByGuid(customerGuid);
                            if (customerByCookie != null)
                                customer = customerByCookie;
                        }
                    }
                }



                //validation
                if(customer !=null)
                if ( customer.ativo.Value)
                {
                    SetCustomerCookie(customer.UsuarioGuid);
                    _cachedCustomer = customer;
                }

                return _cachedCustomer;
            }
            set
            {
                SetCustomerCookie(value.UsuarioGuid);
                _cachedCustomer = value;
            }
        }

        /// <summary>
        /// Gets or sets the original customer (in case the current one is impersonated)
        /// </summary>
        public virtual Usuarios OriginalCustomerIfImpersonated
        {
            get
            {
                return _originalCustomerIfImpersonated;
            }
        }
        
        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        public virtual bool IsAdmin { get; set; }

       

        #endregion
    }
}

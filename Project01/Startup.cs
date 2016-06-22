//Using statements
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

//required for startup
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Project01.Startup))]

namespace Project01
{
    public class Startup
    {
        /**
        * <summary>
        * This method is called when the webpage is called up, it creates a cookie for the users session
        * </summary>
        * 
        * @method Configuration
        * @param {IAppBuilder} app
        * @returns {void}
        */
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login.aspx")
            });
        }
    }
}

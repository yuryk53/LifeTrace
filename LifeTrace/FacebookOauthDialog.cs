/*
    This program is just a diary application.
    Copyright (C) 2016-2017  Yurii Bilyk

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Facebook;
using System.Dynamic;
using System.Configuration;

namespace LifeTrace
{
    public partial class FacebookOauthDialog : Form
    {
        FacebookClient _fb = new FacebookClient();
        public FacebookOAuthResult FacebookOAuthResult { get; set; }

        public FacebookOauthDialog()
        {
            InitializeComponent();

            var appSettings = ConfigurationManager.AppSettings;
            Uri loginUrl = GenerateLoginUrl(appId: appSettings["fbAppId"],
                                            extendedPermissions: appSettings["user_posts"]);

            webBrowser.Navigate(loginUrl.AbsoluteUri);
        }

        private Uri GenerateLoginUrl(string appId, string extendedPermissions)
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = appId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";

            // The requested response: an access token (token), an authorization code (code), or both (code token).
            parameters.response_type = "token";

            // list of additional display modes can be found at http://developers.facebook.com/docs/reference/dialogs/#display
            parameters.display = "popup";

            // add the 'scope' parameter only if we have extendedPermissions.
            if (!string.IsNullOrWhiteSpace(extendedPermissions))
                parameters.scope = extendedPermissions;

            // when the Form is loaded navigate to the login url.
            return _fb.GetLoginUrl(parameters);
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // whenever the browser navigates to a new url, try parsing the url.
            // the url may be the result of OAuth 2.0 authentication.

            FacebookOAuthResult oauthResult;
            if (_fb.TryParseOAuthCallbackUrl(e.Url, out oauthResult))
            {
                // The url is the result of OAuth 2.0 authentication
                this.FacebookOAuthResult = oauthResult;
                DialogResult = this.FacebookOAuthResult.IsSuccess ? DialogResult.OK : DialogResult.No;
                if(DialogResult==DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                // The url is NOT the result of OAuth 2.0 authentication.
                this.FacebookOAuthResult = null;
            }
        }
    }
}

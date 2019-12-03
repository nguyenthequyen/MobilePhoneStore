using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Web.ViewModels
{
    public class LoginViewModel: LoginInputModel
    {
        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalLogin { get; set; } = true;
        //public LoginResolutionPolicy LoginResolutionPolicy { get; set; } = LoginResolutionPolicy.Email;
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
    }
}

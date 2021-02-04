using Microsoft.AspNetCore.Components;
using MiniBlog.Client.Services;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ILoginService LoginService { get; set; }

        protected LoginDetails LoginDetails { get; set; } = new LoginDetails();
        protected bool ShowLoginFailed { get; set; }

        protected async Task Login()
        {
            await LoginService.Login(LoginDetails);

            if (LoginService.IsLoggedIn)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                ShowLoginFailed = true;
            }
        }
    }
}

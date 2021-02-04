using Microsoft.AspNetCore.Components;
using MiniBlog.Client.Services;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        public ILoginService LoginService { get; set; }

        public LoginDetails LoginDetails { get; set; } = new LoginDetails();

        public async Task Login()
        {
            await LoginService.Login(LoginDetails);
        }

        public async Task Logout()
        {
            await LoginService.Logout();
        }
    }
}

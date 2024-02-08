using Microsoft.AspNetCore.Mvc;

namespace Config_to_EntityFrameworkCore.Controllers
{
    public class HomeController:Controller
    {
        //=========================================================================
        //========================== Section = Envirment ==========================
        //=========================================================================
        #region Envirment
        //Enirment are used in Working ,with  Program (startup) file
        //===== 1. Developement Enirment =========
        //This environment is where software developers write, test, and debug code. It is often a local setup on developers' machines or a dedicated development server. In this environment, developers have the flexibility to experiment, make changes, and troubleshoot without affecting the actual users or the live system

        //===== 2. Staging Enirment =========
        //The staging environment is used as a pre-production environment that closely resembles the production environment. It serves as a testing ground where the application is deployed before being released to production. 

        //===== 3. Production Enirment =========
        //The production environment is where the application is deployed and made available to end-users.
        #endregion



        //=========================================================================
        //========================== Section = Configuration (Importent) ==========================
        //=========================================================================

        //___ By Program.cs ___
        #region Configuration_in_ProgramFile
        //Please go to program file
        #endregion

        //___ by controller DI ___
        #region Configuration_byController
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //__________ 1st way _________
            ViewBag.MyKey1 = _configuration["MyKey"];

            //__________ 2nd way _________
            ViewBag.MyKey2 = _configuration.GetValue<string>("MyKey");

            //__________ 3rd way _________
            ViewBag.MyKey3 = _configuration.GetValue("MyKeyss", "Pakistan");

            return View();
        }
        #endregion

    }
}

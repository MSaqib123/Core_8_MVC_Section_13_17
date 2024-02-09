using Config_to_EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        #region Configuration
        //=================
        //---- class 1 ----
        //=================
        //Please go to program file


        //=================
        //---- class 2 ----
        //=================
        #region class2   GetValue with Controller
        //by controller DI
        //private readonly IConfiguration _configuration;
        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    //__________ 1st way _________
        //    ViewBag.MyKey1 = _configuration["MyKey"];

        //    //__________ 2nd way _________
        //    ViewBag.MyKey2 = _configuration.GetValue<string>("MyKey");

        //    //__________ 3rd way _________
        //    ViewBag.MyKey3 = _configuration.GetValue("MyKeyss", "Pakistan");

        //    return View();
        //}

        #endregion


        //=================
        //---- class 3 ------
        //=================
        #region Class 3  (Herarchical Config Values)
        //private readonly IConfiguration _configuration;
        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    //__________ 1st way Herarchical _________
        //    ViewBag.MyKey1 = _configuration["Herarchial:Key1"];
        //    ViewBag.MyKey2 = _configuration.GetValue<string>("Herarchial:Key2");
        //    ViewBag.MyKey3 = _configuration.GetValue("Herarchial:Key3", "India Lost");

        //    //__________ 2nd way Herarchical _________
        //    ViewBag.MyKey4 = _configuration.GetSection("Herarchial")["Key1"];

        //    //__________ 3rd way Herarchical _________
        //    IConfiguration config = _configuration.GetSection("Herarchial");
        //    ViewBag.MyKey5 = config["Key2"];

        //    return View();
        //}
        #endregion


        //===================
        //---- class 4 ------
        //===================
        #region Class 4  (Getting appsetting by Model (Options Pattern)) very importent
        //private readonly IConfiguration _configuration;
        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    //__________ 1st way push json to model _________
        //    ModelBaseJson json = _configuration.GetSection("ModelBaseJson").Get<ModelBaseJson>();
        //    ViewBag.Key1 = json.Key1;
        //    ViewBag.SecrtKey2 = json.SecrtKey2;
        //    ViewBag.logicKey3 = json.logicKey3;
        //    ViewBag.valueKey4 = json.valueKey4;

        //    //__________ 2nd way push json to model _________
        //    ModelBaseJson json2ndWay = new ModelBaseJson();
        //    _configuration.GetSection("ModelBaseJson").Bind(json2ndWay);

        //    ViewBag.cKey1 = json2ndWay.Key1;
        //    ViewBag.cSecrtKey2 = json2ndWay.SecrtKey2;
        //    ViewBag.clogicKey3 = json2ndWay.logicKey3;
        //    ViewBag.cvalueKey4 = json2ndWay.valueKey4;

        //    return View();
        //}
        #endregion


        //=================
        //---- class 5 ------ Using Registered Services Values
        //=================
        #region (Configuration Service) Injecting directly to ProgramFile and bind
        //
        //private readonly ModelBaseJson _jsonValue;
        //public HomeController(IOptions<ModelBaseJson> jsonValue)
        //{
        //    _jsonValue = jsonValue.Value;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    //__________ 1st way push json to model _________
        //    ViewBag.Key1 = _jsonValue.Key1;
        //    ViewBag.SecrtKey2 = _jsonValue.SecrtKey2;
        //    ViewBag.logicKey3 = _jsonValue.logicKey3;
        //    ViewBag.valueKey4 = _jsonValue.valueKey4;

        //    return View();
        //}
        #endregion


        //===================
        //---- class 6 ------
        //===================
        #region Enviroment_Specific_configuration
        //_______ Note Enviremnt base Service Like ________
        //1. ager Envirment=Development ha to ----> to Development ke Configration work kraa ge
        //2. ager Envirmet = staging ha .......
        //3. ager Envirment = Production .....

        //=== chenge envirm from launchsettting.json ===
        //private readonly ModelBaseJson _jsonValue;
        //public HomeController(IOptions<ModelBaseJson> jsonValue)
        //{
        //    _jsonValue = jsonValue.Value;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    //__________ 1st way push json to model _________
        //    ViewBag.Key1 = _jsonValue.Key1;
        //    ViewBag.SecrtKey2 = _jsonValue.SecrtKey2;
        //    ViewBag.logicKey3 = _jsonValue.logicKey3;
        //    ViewBag.valueKey4 = _jsonValue.valueKey4;

        //    return View();
        //}
        #endregion


        //===================
        //---- class 7 ------
        //===================
        #region Secret Manager
        //Our key are Secret thing so  we make these in SecretManger

        //1. dotnet user-secrets init
        //2. dotnet user-secrets set "Key" "value"
        //3. dotnet user-secrets list

        //These file is create in  --=> Computer  C://User
        //Right click on project  click on  ((_Manager User SEcrets_))

        //--- 1. Issue  ----
        //for live  Deplyment this thing will not work for this .  Azure to buy.

        //private readonly ModelBaseJson _jsonValue;
        //public HomeController(IOptions<ModelBaseJson> jsonValue)
        //{
        //    _jsonValue = jsonValue.Value;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    ViewBag.Key1 = _jsonValue.UserSecret;
        //    return View();
        //}
        #endregion


        //===================
        //---- class 8 ------
        //===================
        #region Enviorment Variable for Configuration Keyss
        //in Secret Manager we can set  Configuartion in  External File
        //in Production Envirment The key will not work for 

        //______ Steps _______
        //1. Open Developer PowerSheel
        //2. $Env:ParentKey__ChildKey="value"
        //3. dotnet run --no-launch-profile

        //private readonly ModelBaseJson _jsonValue;
        //public HomeController(IOptions<ModelBaseJson> jsonValue)
        //{
        //    _jsonValue = jsonValue.Value;
        //}
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    ViewBag.Key1 = _jsonValue.Key1;
        //    return View();
        //}
        #endregion


        //===================
        //---- class 9 ------
        //===================
        #region Creating Differnt  Configuration Setting Files
        //In larger Project we seprate the Configuration setting 
        //____ steps _____
        //1. Create  Json File with Desired name
        //2. Registed and Add   New JSon File as Configuration in Program.cs

        private readonly ModelBaseJson _jsonValue;
        public HomeController(IOptions<ModelBaseJson> jsonValue)
        {
            _jsonValue = jsonValue.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Key1 = _jsonValue.Key1;
            ViewBag.SecrtKey2 = _jsonValue.SecrtKey2;
            ViewBag.logicKey3 = _jsonValue.logicKey3;
            return View();
        }
        #endregion

        #endregion
    }
}

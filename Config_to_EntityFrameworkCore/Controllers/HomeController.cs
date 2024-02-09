﻿using Config_to_EntityFrameworkCore.Models;
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


        //=================
        //---- class 4 ------
        //=================
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
        //---- class 5 ------
        //=================
        #region Injecting directly to ProgramFile and bind
        //
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
        #endregion
    }
}

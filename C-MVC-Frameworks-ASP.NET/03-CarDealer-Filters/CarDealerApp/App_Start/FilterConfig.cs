﻿namespace CarDealerApp
{
    using System.Web.Mvc;
    using Filters;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogAttribute());
            filters.Add(new TimerAttribute());
        }
    }
}
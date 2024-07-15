﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BootstrapBlazor.Server.Controllers;

/// <summary>
/// 文化 Controller
/// </summary>
[Route("[controller]/[action]")]
public class CultureController : Controller
{
    /// <summary>
    /// 设置文化方法
    /// </summary>
    /// <param name="culture"></param>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public IActionResult SetCulture(string culture, string redirectUri)
    {
        if (string.IsNullOrEmpty(culture))
        {
            HttpContext.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
        }
        else
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.Now.AddYears(1)
                });
        }

        return LocalRedirect(redirectUri);
    }

    /// <summary>
    /// 重置文化方法
    /// </summary>
    /// <param name="redirectUri"></param>
    /// <returns></returns>
    public IActionResult ResetCulture(string redirectUri)
    {
        HttpContext.Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);

        return LocalRedirect(redirectUri);
    }
}
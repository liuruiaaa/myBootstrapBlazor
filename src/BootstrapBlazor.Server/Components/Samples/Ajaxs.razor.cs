﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// Ajax 组件代码
/// </summary>
public partial class Ajaxs
{
    [Inject]
    [NotNull]
    private IStringLocalizer<Ajaxs>? Localizer { get; set; }

    [Inject]
    [NotNull]
    private AjaxService? AjaxService { get; set; }

    [Inject]
    [NotNull]
    private SwalService? SwalService { get; set; }

    private string? ResultMessage { get; set; }

    private Task Success() => ProcessResponse("admin", "123456");

    private Task Fail() => ProcessResponse("admin", "123");

    private async Task ProcessResponse(string userName, string password)
    {
        var option = new AjaxOption()
        {
            Url = "/api/Login",
            Data = new User() { UserName = userName, Password = password }
        };
        var result = await AjaxService.InvokeAsync(option);
        if (result == null)
        {
            ResultMessage = "Login failed";
        }
        else
        {
            if (200 == result.RootElement.GetProperty("code").GetInt32())
            {
                await SwalService.Show(new SwalOption() { Content = "Login success！", Category = SwalCategory.Success });
            }
            else
            {
                await SwalService.Show(new SwalOption() { Content = $"Login failed: {result.RootElement.GetProperty("message").GetString()}", Category = SwalCategory.Error });
            }
        }
    }

    class User
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }
    }

    private Task Goto() => AjaxService.Goto("/introduction");

    private Task GotoSelf() => AjaxService.Goto("/ajax");

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private List<MethodItem> GetMethods() =>
    [
        new()
        {
            Name = "InvokeAsync",
            Description = Localizer["InvokeAsync"],
            Parameters = "AjaxOption",
            ReturnValue = "string"
        },
        new()
        {
            Name = "Goto",
            Description = Localizer["GoTo"],
            Parameters = "string",
            ReturnValue = " — "
        }
    ];
}

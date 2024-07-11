// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Maui.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MenuItem = BootstrapBlazor.Components.MenuItem;



namespace BootstrapBlazor.Maui.Components.Layout;

/// <summary>
/// 
/// </summary>
public sealed partial class MainLayout 
{
    private bool UseTabSet { get; set; } = false; //这是设置标签页的，要注意

    private string Theme { get; set; } = "";

    private bool IsOpen { get; set; }

    private bool IsFixedHeader { get; set; } = false;

    private bool IsFixedFooter { get; set; } = true;

    private bool IsFullSide { get; set; } = true;

    private bool ShowFooter { get; set; } = true;
    private bool ShowGoto { get; set; } = false;

    private List<MenuItem>? Menus { get; set; }

    private readonly MenuService menuService;



    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();
        //Menus = GetIconSideMenuItems();
        //menuService.Menus = GetIconSideMenuItems();
        MenuService.OnMenuUpdated += HandleMenuUpdated;
    }



    private void HandleMenuUpdated()
    {
        // 通知Blazor需要重新渲染组件A
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        // 在组件销毁时取消订阅，防止内存泄漏
        MenuService.OnMenuUpdated -= HandleMenuUpdated;
    }

    private static List<MenuItem> GetIconSideMenuItems()
    {
        var menus = new List<MenuItem>
        {
            new() { Text = "Chat", Icon = "fa-solid fa-fw fa-home", Url = "/Chat" },
            new() { Text = "Chat2", Icon = "fa-solid fa-fw fa-home", Url = "/Chat2" },
            new() { Text = "Index", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
            new() { Text = "Counter", Icon = "fa-solid fa-fw fa-check-square", Url = "counter" },
            new() { Text = "FetchData", Icon = "fa-solid fa-fw fa-database", Url = "fetchdata" },
            new() { Text = "Table", Icon = "fa-solid fa-fw fa-table", Url = "table" },
            new() { Text = "名册", Icon = "fa-solid fa-fw fa-users", Url = "users" },

            new() { Text = "Chat", Icon = "fa-solid fa-fw fa-home", Url = "/Chat" },
            new() { Text = "Chat2", Icon = "fa-solid fa-fw fa-home", Url = "/Chat2" },
            new() { Text = "Index", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
            new() { Text = "Counter", Icon = "fa-solid fa-fw fa-check-square", Url = "counter" },
            new() { Text = "FetchData", Icon = "fa-solid fa-fw fa-database", Url = "fetchdata" },
            new() { Text = "Table", Icon = "fa-solid fa-fw fa-table", Url = "table" },
            new() { Text = "名册", Icon = "fa-solid fa-fw fa-users", Url = "users" },

        };

        return menus;
    }

 
}

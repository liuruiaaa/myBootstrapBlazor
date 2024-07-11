// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapBlazor.Maui.Data;
using Microsoft.AspNetCore.Components.Routing;
using MenuItem = BootstrapBlazor.Components.MenuItem;

namespace BootstrapBlazor.Maui.Data;
 internal class MenuService
{

    // 定义一个静态事件
    public static event Action? OnMenuUpdated;

    public static List<MenuItem> Menus = GetIconSideMenuItems();

    //private List<MenuItem>? Menus { get; set; }

    public static List<MenuItem> GetMenus()
    {
        return Menus;
    }

    static public void UpdateMenus(List<MenuItem> menus)
    {

        Menus = menus;
        NotifyMenuUpdated(); // 添加菜单后，通知事件的订阅者
    }

    static public void UpdateMenu(MenuItem menus)
    {
        Menus.Add(menus);
        NotifyMenuUpdated(); // 添加菜单后，通知事件的订阅者
    }

    // 触发OnMenuUpdated事件的方法
    private static void NotifyMenuUpdated()
    {
        OnMenuUpdated?.Invoke();
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
            new() { Text = "名册", Icon = "fa-solid fa-fw fa-users", Url = "foos" },

        };

        return menus;
    }


}

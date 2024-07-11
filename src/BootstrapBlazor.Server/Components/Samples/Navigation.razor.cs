﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components.Routing;

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// navigation
/// </summary>
public sealed partial class Navigation
{
    private IEnumerable<NavLink> Items => GetItems();

    private List<NavLink> GetItems()
    {
        var ret = new List<NavLink>();
        var link = new NavLink();
        var parameters = new Dictionary<string, object?>()
        {
            ["href"] = WebsiteOption.CurrentValue.AdminUrl,
            ["class"] = "nav-link nav-item",
            ["target"] = "_blank",
            ["ChildContent"] = new RenderFragment(builder =>
            {
                builder.AddContent(0, "BootstrapAdmin");
            })
        };
        link.SetParametersAsync(ParameterView.FromDictionary(parameters));
        ret.Add(link);
        return ret;
    }

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private AttributeItem[] GetAttributes() =>
    [
        new()
        {
            Name = "ChildContent",
            Description = Localizer["NavsChildContent"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new() {
            Name = "Alignment",
            Description = Localizer["NavsAlignment"],
            Type = "Alignment",
            ValueList = "Left|Center|Right",
            DefaultValue = " — "
        },
        new() {
            Name = "IsVertical",
            Description = Localizer["NavsIsVertical"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new() {
            Name = "IsPills",
            Description = Localizer["NavsIsPills"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new() {
            Name = "IsFill",
            Description = Localizer["NavsIsFill"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new() {
            Name = "IsJustified",
            Description = Localizer["NavsIsJustified"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        }
    ];
}

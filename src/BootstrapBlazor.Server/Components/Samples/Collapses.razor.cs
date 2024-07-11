﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// Collapses
/// </summary>
public sealed partial class Collapses
{
    [NotNull]
    private ConsoleLogger? NormalLogger { get; set; }

    private Task OnChanged(CollapseItem item)
    {
        NormalLogger.Log($"{item.Text}: {item.IsCollapsed}");
        return Task.CompletedTask;
    }

    private bool State { get; set; }

    private void OnToggle()
    {
        State = !State;
    }

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private AttributeItem[] GetAttributes() =>
    [
        new()
        {
            Name = "CollapseItems",
            Description = Localizer["CollapseItems"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "IsAccordion",
            Description = Localizer["IsAccordion"],
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "false"
        },
        new()
        {
            Name = "OnCollapseChanged",
            Description = Localizer["OnCollapseChanged"],
            Type = "Func<CollapseItem, Task>",
            ValueList = " — ",
            DefaultValue = " — "
        }
    ];
}

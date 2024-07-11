﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// Tags
/// </summary>
public sealed partial class Tags
{
    [NotNull]
    private ConsoleLogger? Logger { get; set; }

    private Task DismissClick()
    {
        Logger.Log($"Tag Dismissed");
        return Task.CompletedTask;
    }

    /// <summary>
    /// 获得事件方法
    /// </summary>
    /// <returns></returns>
    private EventItem[] GetEvents() =>
    [
        new()
        {
            Name = "OnDismiss",
            Description = Localizer["TagsOnDismiss"],
            Type ="EventCallback<MouseEventArgs>"
        }
    ];

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private AttributeItem[] GetAttributes() =>
    [
        new()
        {
            Name = "ChildContent",
            Description = Localizer["TagsChildContent"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "Class",
            Description = Localizer["TagsClass"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "Color",
            Description = Localizer["TagsColor"],
            Type = "Color",
            ValueList = "Primary / Secondary / Success / Danger / Warning / Info / Dark",
            DefaultValue = "Primary"
        },
        new()
        {
            Name = "Icon",
            Description = Localizer["TagsIcon"],
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "ShowDismiss",
            Description = Localizer["TagsShowDismiss"],
            Type = "boolean",
            ValueList = " — ",
            DefaultValue = "false"
        }
    ];
}

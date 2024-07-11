﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// Dividers 组件示例文档
/// </summary>
public sealed partial class Dividers
{
    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private AttributeItem[] GetAttributes() =>
    [
            new() {
                Name = "Text",
                Description = Localizer["Desc1"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new() {
                Name = "Icon",
                Description = Localizer["Desc2"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new() {
                Name = "Alignment",
                Description = Localizer["Desc3"],
                Type = "Aligment",
                ValueList = "Left|Center|Right|Top|Bottom",
                DefaultValue = "Center"
            },
            new() {
                Name = "IsVertical",
                Description = Localizer["Desc4"],
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new() {
                Name = "ChildContent",
                Description = Localizer["Desc5"],
                Type = "RenderFragment",
                ValueList = " — ",
                DefaultValue = " — "
            }
    ];
}

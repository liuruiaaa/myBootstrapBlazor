﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// Loader 示例代码
/// </summary>
public partial class Splittings
{
    private int _columns = 30;

    private static AttributeItem[] GetAttributes() =>
    [
        new()
        {
            Name = "Text",
            Description = "display text",
            Type = "string",
            ValueList = " — ",
            DefaultValue = "Loading ..."
        },
        new()
        {
            Name = "Columns",
            Description = "Progress bar segmentation granularity",
            Type = "int",
            ValueList = " — ",
            DefaultValue = "10"
        },
        new()
        {
            Name = "Color",
            Description = "the color of progress",
            Type = "Enum",
            ValueList = " — ",
            DefaultValue = "Primary"
        },
        new()
        {
            Name = "ShowLoadingText",
            Description = "Whether show the text of loading",
            Type = "bool",
            ValueList = "true|false",
            DefaultValue = "true"
        },
        new()
        {
            Name = "Repeat",
            Description = "Is repeat the animation",
            Type = "int",
            ValueList = ">= -1",
            DefaultValue = "-1"
        }
    ];
}

﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Server.Components.Samples.Table;

/// <summary>
/// 表头固定示例代码
/// </summary>
public partial class TablesFixedHeader
{
    /// <summary>
    /// Foo 类为Demo测试用，如有需要请自行下载源码查阅
    /// Foo class is used for Demo test, please download the source code if necessary
    /// https://gitee.com/LongbowEnterprise/BootstrapBlazor/blob/main/src/BootstrapBlazor.Server/Data/Foo.cs
    /// </summary>
    [NotNull]
    private List<Foo>? Items { get; set; }

    private int Height { get; set; } = 300;

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        Items = Foo.GenerateFoo(FooLocalizer);
    }

    private async Task OnClickDialog()
    {
        var op = new DialogOption
        {
            Class = "dialog-table",
            Title = Localizer["DialogTitle"],
            BodyTemplate = RenderTable()
        };

        await DialogService.Show(op);
    }
}

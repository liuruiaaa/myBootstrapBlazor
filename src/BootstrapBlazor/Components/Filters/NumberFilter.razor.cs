﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.Extensions.Localization;

namespace BootstrapBlazor.Components;

/// <summary>
/// 数字类型过滤条件
/// </summary>
public partial class NumberFilter<TType>
{
    private TType? Value1 { get; set; }

    private FilterAction Action1 { get; set; } = FilterAction.GreaterThanOrEqual;

    private TType? Value2 { get; set; }

    private FilterAction Action2 { get; set; } = FilterAction.LessThanOrEqual;

    [Inject]
    [NotNull]
    private IStringLocalizer<TableFilter>? Localizer { get; set; }

    /// <summary>
    /// 获得/设置 步长 默认 0.01
    /// </summary>
    [Parameter]
    public string Step { get; set; } = "0.01";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Items ??= new SelectedItem[]
        {
            new SelectedItem("GreaterThanOrEqual", Localizer["GreaterThanOrEqual"].Value),
            new SelectedItem("LessThanOrEqual", Localizer["LessThanOrEqual"].Value),
            new SelectedItem("GreaterThan", Localizer["GreaterThan"].Value),
            new SelectedItem("LessThan", Localizer["LessThan"].Value),
            new SelectedItem("Equal", Localizer["Equal"].Value),
            new SelectedItem("NotEqual", Localizer["NotEqual"].Value)
        };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void Reset()
    {
        Value1 = default;
        Value2 = default;
        Action1 = FilterAction.GreaterThanOrEqual;
        Action2 = FilterAction.LessThanOrEqual;
        Count = 0;
        Logic = FilterLogic.And;
        StateHasChanged();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns></returns>
    public override FilterKeyValueAction GetFilterConditions()
    {
        var filter = new FilterKeyValueAction() { Filters = [] };
        if (Value1 != null)
        {
            filter.Filters.Add(new FilterKeyValueAction()
            {
                FieldKey = FieldKey,
                FieldValue = Value1,
                FilterAction = Action1
            });
        }

        if (Count > 0 && Value2 != null)
        {
            filter.Filters.Add(new FilterKeyValueAction()
            {
                FieldKey = FieldKey,
                FieldValue = Value2,
                FilterAction = Action2,
            });
            filter.FilterLogic = Logic;
        }
        return filter;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override async Task SetFilterConditionsAsync(FilterKeyValueAction filter)
    {
        var first = filter.Filters?.FirstOrDefault() ?? filter;
        if (first.FieldValue is TType value)
        {
            Value1 = value;
        }
        else
        {
            Value1 = default;
        }
        Action1 = first.FilterAction;

        if (filter.Filters != null && filter.Filters.Count == 2)
        {
            Count = 1;
            FilterKeyValueAction second = filter.Filters[1];
            if (second.FieldValue is TType value2)
            {
                Value2 = value2;
            }
            else
            {
                Value2 = default;
            }
            Action2 = second.FilterAction;
            Logic = filter.FilterLogic;
        }
        await base.SetFilterConditionsAsync(filter);
    }
}

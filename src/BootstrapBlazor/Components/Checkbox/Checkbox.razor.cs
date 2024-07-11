﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System.Globalization;

namespace BootstrapBlazor.Components;

/// <summary>
/// Checkbox 组件
/// </summary>
[BootstrapModuleAutoLoader(ModuleName = "utility", AutoInvokeInit = false, AutoInvokeDispose = false)]
public partial class Checkbox<TValue> : ValidateBase<TValue>
{
    /// <summary>
    /// 获得 class 样式集合
    /// </summary>
    private string? ClassString => CssBuilder.Default("form-check")
        .AddClass("is-label", IsShowAfterLabel)
        .AddClass("is-checked", State == CheckboxState.Checked && !IsBoolean)
        .AddClass("is-indeterminate", State == CheckboxState.Indeterminate)
        .AddClass($"form-check-{Color.ToDescriptionString()}", Color != Color.None)
        .AddClass($"form-check-{Size.ToDescriptionString()}", Size != Size.None)
        .AddClass("disabled", IsDisabled)
        .AddClass(ValidCss)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private bool IsShowAfterLabel => ShowAfterLabel && !string.IsNullOrEmpty(DisplayText);

    /// <summary>
    /// Input 元素样式
    /// </summary>
    protected string? InputClassString => CssBuilder.Default("form-check-input")
        .AddClass($"border-{Color.ToDescriptionString()}", Color != Color.None)
        .AddClass("disabled", IsDisabled)
        .Build();

    /// <summary>
    /// Check 状态字符串
    /// </summary>
    protected string? CheckedString => State switch
    {
        CheckboxState.Checked => "checked",
        _ => null
    };

    /// <summary>
    /// 判断双向绑定类型是否为 boolean 类型
    /// </summary>
    private bool IsBoolean { get; set; }

    /// <summary>
    /// 获得/设置 按钮颜色 默认为 None 未设置
    /// </summary>
    [Parameter]
    public Color Color { get; set; }

    /// <summary>
    /// 获得/设置 Size 大小 默认为 None
    /// </summary>
    [Parameter]
    public Size Size { get; set; }

    /// <summary>
    /// 获得/设置 是否显示 Checkbox 后置 label 文字 默认为 false
    /// </summary>
    [Parameter]
    public bool ShowAfterLabel { get; set; }

    /// <summary>
    /// 获得/设置 选择框状态
    /// </summary>
    [Parameter]
    public CheckboxState State { get; set; }

    /// <summary>
    /// State 状态改变回调方法
    /// </summary>
    /// <value></value>
    [Parameter]
    public EventCallback<CheckboxState> StateChanged { get; set; }

    /// <summary>
    /// 获得/设置 选择框状态改变时回调此方法
    /// </summary>
    [Parameter]
    public Func<CheckboxState, TValue, Task>? OnStateChanged { get; set; }

    /// <summary>
    /// 获得/设置 是否事件冒泡 默认为 false
    /// </summary>
    [Parameter]
    public bool StopPropagation { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        IsBoolean = (Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue)) == typeof(bool);
    }

    /// <summary>
    /// OnParametersSet 方法
    /// </summary>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (ShowAfterLabel)
        {
            ShowLabel = false;
        }

        if (IsBoolean && Value != null && State != CheckboxState.Indeterminate && BindConverter.TryConvertToBool(Value, CultureInfo.InvariantCulture, out var v))
        {
            State = v ? CheckboxState.Checked : CheckboxState.UnChecked;
        }
    }

    /// <summary>
    /// OnAfterRender 方法
    /// </summary>
    /// <param name="firstRender"></param>
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        _paddingStateChanged = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        await InvokeVoidAsync("setIndeterminate", Id, State == CheckboxState.Indeterminate);
    }

    /// <summary>
    /// 点击选择框方法
    /// </summary>
    private async Task OnToggleClick()
    {
        if (!IsDisabled)
        {
            _paddingStateChanged = true;
            await InternalStateChanged(State == CheckboxState.Checked ? CheckboxState.UnChecked : CheckboxState.Checked);
        }
    }

    /// <summary>
    /// 此变量为了提高性能，避免循环更新
    /// </summary>
    private bool _paddingStateChanged;

    private async Task InternalStateChanged(CheckboxState state)
    {
        if (_paddingStateChanged)
        {
            if (IsBoolean)
            {
                CurrentValue = (TValue)(object)(state == CheckboxState.Checked);
            }

            if (State != state)
            {
                State = state;
                if (StateChanged.HasDelegate)
                {
                    await StateChanged.InvokeAsync(State);
                }

                if (OnStateChanged != null)
                {
                    await OnStateChanged.Invoke(State, Value);
                }
            }
        }
    }

    /// <summary>
    /// 设置 复选框状态方法
    /// </summary>
    /// <param name="state"></param>
    public virtual async Task SetState(CheckboxState state)
    {
        if (!_paddingStateChanged)
        {
            _paddingStateChanged = true;

            await InternalStateChanged(state);
            StateHasChanged();
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="disposing"></param>
    /// <returns></returns>
    protected override async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing && Module != null)
        {
            await Module.DisposeAsync();
            Module = null;
        }
        await base.DisposeAsync(disposing);
    }
}

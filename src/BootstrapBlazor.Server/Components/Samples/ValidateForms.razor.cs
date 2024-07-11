﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Concurrent;

namespace BootstrapBlazor.Server.Components.Samples;

/// <summary>
/// ValidateForms
/// </summary>
public partial class ValidateForms
{
    [NotNull]
    private Foo? Model1 { get; set; }

    [NotNull]
    private ConsoleLogger? Logger1 { get; set; }

    private async Task OnInvalidSubmit1(EditContext context)
    {
        await Task.Delay(1000);
        Logger1.Log(Localizer["OnInvalidSubmitLog"]);
    }

    private async Task OnValidSubmit1(EditContext context)
    {
        await Task.Delay(1000);
        Logger1.Log(Localizer["OnValidSubmitLog"]);
    }

    private void OnFiledChanged(string field, object? value)
    {
        Logger1.Log($"{field}:{value}");
    }

    /// <summary>
    /// OnInitializedAsync 方法
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        CustomerRules.Add(new FormItemValidator(new EmailAddressAttribute()));

        // 切换线程 模拟异步通过 WEBAPI 加载数据
        await Task.Yield();

        Model1 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model2 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model3 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model4 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model7 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model8 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model9 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };
        Model10 = new Foo { Name = "Name", Education = EnumEducation.Primary, DateTime = DateTime.Now };

        // 初始化参数
        Hobbies2 = Foo.GenerateHobbies(LocalizerFoo);
        Hobbies3 = Foo.GenerateHobbies(LocalizerFoo);
        Hobbies4 = Foo.GenerateHobbies(LocalizerFoo);
        Hobbies7 = Foo.GenerateHobbies(LocalizerFoo);

        ComplexModel = new ComplexFoo()
        {
            Dummy = new Dummy1() { Dummy2 = new Dummy2() },
        };
    }

    [NotNull]
    private Foo? Model2 { get; set; }

    [NotNull]
    private IEnumerable<SelectedItem>? Hobbies2 { get; set; }

    [NotNull]
    private ConsoleLogger? Logger2 { get; set; }

    private async Task OnValidSubmit2(EditContext context)
    {
        Logger2.Log(Localizer["OnValidSubmitStartingLog"]);
        await Task.Delay(3000);
        Logger2.Log(Localizer["OnValidSubmitDoneLog"]);
    }

    private Task OnInvalidSubmit2(EditContext context)
    {
        Logger2.Log(Localizer["OnInvalidSubmitCallBackLog"]);
        return Task.CompletedTask;
    }

    [NotNull]
    private Foo? Model3 { get; set; }

    [NotNull]
    private IEnumerable<SelectedItem>? Hobbies3 { get; set; }

    [NotNull]
    private ValidateForm? FooForm { get; set; }

    private Task OnValidSetError(EditContext context)
    {
        FooForm.SetError<Foo>(f => f.Name, Localizer["DatabaseExistLog"]);
        return Task.CompletedTask;
    }

    [NotNull]
    private Foo? Model4 { get; set; }

    [NotNull]
    private IEnumerable<SelectedItem>? Hobbies4 { get; set; }

    [NotNull]
    private ConsoleLogger? Logger4 { get; set; }

    private Task OnInvalidSubmitAddress(EditContext context)
    {
        Logger4.Log(Localizer["OnInvalidSubmitCallBackLog"]);
        return Task.CompletedTask;
    }

    [NotNull]
    private ConsoleLogger? Logger5 { get; set; }

    [NotNull]
    private ValidateForm? ComplexForm { get; set; }

    [NotNull]
    private ComplexFoo? ComplexModel { get; set; }

    private ConcurrentDictionary<FieldIdentifier, object?> GetValueChangedFieldCollection() => ComplexForm?.ValueChangedFields ?? new ConcurrentDictionary<FieldIdentifier, object?>();

    private class ComplexFoo : Foo
    {
        [NotNull]
        public Dummy1? Dummy { get; set; }
    }

    private class Dummy1
    {
        [NotNull]
        public Dummy2? Dummy2 { get; set; }
    }

    private class Dummy2
    {
        [Required]
        public string? Name { get; set; }
    }

    private Task OnInvalidComplexModel(EditContext context)
    {
        Logger5.Log(Localizer["OnInvalidSubmitCallBackLog"]);
        return Task.CompletedTask;
    }

    private Task OnValidComplexModel(EditContext context)
    {
        Logger5.Log(Localizer["OnValidSubmitCallBackLog"]);
        ComplexForm.SetError("Dummy.Dummy2.Name", Localizer["DatabaseExistLog"]);
        return Task.CompletedTask;
    }

    private bool ShowAddress { get; set; }

    [NotNull]
    private ConsoleLogger? Logger6 { get; set; }

    private Foo DynamicModel { get; set; } = new Foo();

    private Task OnInvalidDynamicModel(EditContext context)
    {
        Logger6.Log(Localizer["OnInvalidSubmitCallBackLog"]);
        return Task.CompletedTask;
    }

    private Task OnValidDynamicModel(EditContext context)
    {
        Logger6.Log(Localizer["OnValidSubmitCallBackLog"]);
        return Task.CompletedTask;
    }

    private void OnValidateChange()
    {
        ShowAddress = true;
    }

    private void OnValidateReset()
    {
        ShowAddress = false;
    }

    [NotNull]
    private Foo? Model7 { get; set; }

    [NotNull]
    private IEnumerable<SelectedItem>? Hobbies7 { get; set; }

    private List<IValidator> CustomerRules { get; } = [];

    [NotNull]
    private Foo? Model8 { get; set; }

    [NotNull]
    private Foo? Model9 { get; set; }

    [NotNull]
    private ValidateForm? ValidatorForm { get; set; }

    private Task OnValidator()
    {
        ValidatorForm.Validate();
        return Task.CompletedTask;
    }

    [NotNull]
    private Foo? Model10 { get; set; }

    #region 参数说明
    private AttributeItem[] GetAttributes() =>
    [
        new()
        {
            Name = "Model",
            Description = Localizer["Model"],
            Type = "object",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "ValidateAllProperties",
            Description = Localizer["ValidateAllProperties"],
            Type = "bool",
            ValueList = "true/false",
            DefaultValue = "false"
        },
        new()
        {
            Name = nameof(ValidateForm.DisableAutoSubmitFormByEnter),
            Description = Localizer[nameof(ValidateForm.DisableAutoSubmitFormByEnter)],
            Type = "bool",
            ValueList = "true/false",
            DefaultValue = "false"
        },
        new()
        {
            Name = "ShowRequiredMark",
            Description = Localizer["ShowRequiredMark"],
            Type = "bool",
            ValueList = "true/false",
            DefaultValue = "true"
        },
        new()
        {
            Name = "ShowLabelTooltip",
            Description = Localizer["ShowLabelTooltip"],
            Type = "bool?",
            ValueList = "true/false/null",
            DefaultValue = "null"
        },
        new()
        {
            Name = "ChildContent",
            Description = Localizer["ChildContent"],
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "OnValidSubmit",
            Description = Localizer["OnValidSubmit"],
            Type = "EventCallback<EditContext>",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "OnInvalidSubmit",
            Description = Localizer["OnInvalidSubmit"],
            Type = "EventCallback<EditContext>",
            ValueList = " — ",
            DefaultValue = " — "
        }
    ];

    /// <summary>
    /// 获得事件方法
    /// </summary>
    /// <returns></returns>
    private MethodItem[] GetMethods() =>
    [
        new()
        {
            Name = "SetError",
            Description = Localizer["SetError"],
            Parameters = "PropertyName, ErrorMessage",
            ReturnValue = " — "
        },
        new()
        {
            Name = "Validate",
            Description = Localizer["Validate"],
            Parameters = " — ",
            ReturnValue = "boolean"
        }
    ];
    #endregion
}

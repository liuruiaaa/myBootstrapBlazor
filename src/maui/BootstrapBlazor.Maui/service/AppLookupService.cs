﻿// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using BootstrapBlazor.Components;
namespace BootstrapBlazor.Maui.service;

/// <summary>
/// 数据注入服务实现类
/// </summary>
public class AppLookupService : ILookupService
{
    private IServiceProvider Provider { get; }
    private DataService DataService { get; }

    public AppLookupService(IServiceProvider provider, DataService dataService)
    {
        Provider = provider;
        DataService = dataService;
    }

    public IEnumerable<SelectedItem>? GetItemsByKey(string? key)
    {
        IEnumerable<SelectedItem>? items = null;
        if (key == "Users")
        {
            items = DataService.GetUsers()?.Select(a => new SelectedItem()
            {
                Value = a.UserID.ToString(),
                Text = a.FullName ?? "*",
                GroupName = a.Type?.ToString() ?? "",
            });
        }
        return items;
    }

    public IEnumerable<SelectedItem>? GetItemsByKey(string? key, object? data)
    {
        return GetItemsByKey(key);
    }
}

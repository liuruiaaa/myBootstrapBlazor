﻿// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using BootstrapBlazor.Components;
using BootstrapBlazor.Maui.Common.Tool;
using BootstrapBlazor.Maui.Data;
using BootstrapBlazor.Maui.Models;
namespace BootstrapBlazor.Maui.service;

public partial class DataService
{
    IFreeSql Fsql { get; set; }
    States? States { get; set; }
    public SysInfo? SysInfo { get; set; }

    PasswordHasher Hasher { get; set; } = new PasswordHasher();

    public DataService(IFreeSql fsql, States? states)
    {
        this.Fsql = fsql;
        this.States = states;
        //InitDatas();
    }



    public async Task<List<string?>?> GetPhotosAsync(string? ProjectID = null)
    {
        return await Fsql.Select<Photos>()
            .WhereIf(ProjectID != null, a => a.ProjectID == ProjectID)
            .Where(a => a.PhotoPath != null)
            .ToListAsync(a => a.PhotoPath);

    }

    public async Task<List<string?>?> SavePhotoAsync(Geolocationitem? model, string? imageUrl, string? ProjectID = null)
    {
        if (imageUrl == null)
        {
            return null;
        }
        var item = new Photos
        {
            ProjectID = ProjectID,
            PhotoPath = imageUrl,
            Operator = States?.User?.UserID,
            Longitude = model?.Longitude,
            Latitude = model?.Latitude,
        };

        var res = Fsql.Insert(item).ExecuteAffrows();
        if (res == 0)
        {
            return null;
        }
        return await GetPhotosAsync();
    }


    public async Task<int> SaveProjectPhotosAsync(List<string>? imageUrls, string? ProjectID = null)
    {
        if (imageUrls == null || !imageUrls.Any())
        {
            return 0;
        }
        var items = new List<Photos>();
        imageUrls.ForEach(imageUrl => items.Add(new Photos
        {
            ProjectID = ProjectID,
            PhotoPath = imageUrl,
            Operator = States?.User?.UserID,
        })
        );

        var res = await Fsql.Insert(items).ExecuteAffrowsAsync();
        return res;
    }
}

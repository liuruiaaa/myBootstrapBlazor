// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using FreeSql;
using System.Linq.Expressions;

using BootstrapBlazor.Maui.Models;
namespace BootstrapBlazor.Maui.service;

/// <summary>
/// BootstrapBlazor 服务扩展类
/// </summary>
public static class TableDataServiceCollectionExtensions
{
    /// <summary>
    /// 增加 PetaPoco 数据库操作服务
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddTableDataService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IDataService<>), typeof(TableDataService<>));
        return services;
    }
}

/// <summary>
/// 演示网站示例数据注入服务实现类
/// </summary>
internal class TableDataService<TModel> : DataServiceBase<TModel> where TModel : class, new()
{
    private readonly IFreeSql _fsql;
    private readonly IBaseRepository<TModel> _repository;


    public TableDataService(IFreeSql fsql)
    {
        this._fsql = fsql;
        // 假设TModel类对应了数据库中的一个表
        this._repository = _fsql.GetRepository<TModel>();
    }




    /// <summary>
    /// 查询操作方法
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions options)
    {

  
/*            _fsql.Select<Foo>()
            .WhereIf(ProjectID != null, a => a.ProjectID == ProjectID)
            .Where(a => a.PhotoPath != null)
            .ToListAsync(a => a.PhotoPath);*/
          //  Items = Foo.GenerateFoo(Localizer).Cast<TModel>().ToList();
        


        var isSearched = false;
        var isFiltered = options.Filters.Any();
        var isSorted = !string.IsNullOrEmpty(options.SortName);
        var itemsQueryable = _repository.Select;

        // 可以在这里添加搜索、过滤和排序的代码
        // 例如，以下代码示例展示如何执行基本的搜索操作
        if (options.Searches.Any())
        {
            foreach (var search in options.Searches)
            {
                    var parameter = Expression.Parameter(typeof(Foo), "e");
                    var property = Expression.Property(parameter, "Name");
                    var constant = Expression.Constant(options.SearchText);
                    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                    var containsExpression = Expression.Call(property, containsMethod, constant);
                    var lambda = Expression.Lambda<Func<Foo, bool>>(containsExpression, parameter);
                    itemsQueryable = itemsQueryable.Where(lambda);   
            }
            isSearched = true;
        }else {
            itemsQueryable.ToList();
        }

        var total = itemsQueryable.Count();
        var items = itemsQueryable.Page(options.PageIndex, options.PageItems).ToList();

        return Task.FromResult(new QueryData<TModel>()
        {
            Items = items,
            TotalCount =  (int)total,
            IsFiltered = isFiltered,
            IsSorted = isSorted,
            IsSearch = isSearched
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="changedType"></param>
    /// <returns></returns>
    public override async Task<bool> SaveAsync(TModel model, ItemChangedType changedType)
    {
        switch (changedType)
        {
            case ItemChangedType.Add:
                await _repository.InsertAsync(model);
                return true;
            case ItemChangedType.Update:
                await _repository.UpdateAsync(model);
                return true;
/*            case ItemChangedType.Update:
                await _repository.DeleteAsync(model);*/
/*                return true;*/
            default:
                return false;
        }
    }

    // 重写DeleteAsync以支持使用FreeSql删除数据
    public override async Task<bool> DeleteAsync(IEnumerable<TModel> models)
    {
        await _repository.DeleteAsync(models);
        return true;
    }
}

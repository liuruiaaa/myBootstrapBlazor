// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Maui.Components.Layout;
using BootstrapBlazor.Maui.Data;
using BootstrapBlazor.Maui.service;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Extensions.Logging;
using Windows.Storage;

namespace BootstrapBlazor.Maui;

/// <summary>
/// 
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<WeatherForecastService>();
/*       builder.Services.AddFreeSql(builder =>
        {

            builder.UseAutoSyncStructure(true) // 自动同步实体结构到数据库
               .UseConnectionString(FreeSql.DataType.Sqlite, "Data Source=C:\\sql3\\test.db;");


            *//*            //demo演示的是Sqlite驱动,FreeSql支持多种数据库，MySql/SqlServer/PostgreSQL/Oracle/Sqlite/Firebird/达梦/神通/人大金仓/翰高/华为GaussDB/MsAccess
                        option.UseConnectionString(FreeSql.DataType.Sqlite, "Data Source=C:\\sql3\\test.db;")  //也可以写到配置文件中
                             .UseAutoSyncStructure(true)//开发环境:自动同步实体
                             .UseNoneCommandParameter(true)
                             .UseMonitorCommand(cmd => System.Console.WriteLine(cmd.CommandText)) //调试sql语句输出
                        ;*//*



        });*/


        // 增加 BootstrapBlazor 组件服务
        builder.Services.AddBootstrapBlazor();
        // 增加 Table 数据服务DEMO操作类
        //builder.Services.AddTableDemoDataService();

        // 增加 Table 数据库连接
         builder.Services.AddSharedExtensions();
        // 增加 Table 数据服务实体操作类
        builder.Services.AddTableDataService();


        // 配置日志器
        builder.Logging.AddDebug(); // 添加调试日志提供者
        builder.Logging.SetMinimumLevel(LogLevel.Trace); // 设置最小日志级别
        builder.Services.AddScoped<MenuService>(); //把导航的注入一下
        return builder.Build();


        /*        builder.Services.AddFreeSql(opt =>
                {
                    var dbpath =  "C: \\hybrid.db";
                    opt.UseConnectionString(FreeSql.DataType.Sqlite, dbpath);
                });*/

    }
}

// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using BootstrapBlazor.Components;
using Densen.DataAcces.FreeSql;
using System.Globalization;
using BootstrapBlazor.WebAPI.Services;
using DocumentFormat.OpenXml.Office.Word;
using BootstrapBlazor.Maui.Data;


#if WINDOWS
using Windows.Storage;
#endif


namespace BootstrapBlazor.Maui.service;


/// <summary>
/// 服务扩展类
/// </summary>
public static class SharedServiceCollectionExtensions
{

    /// <summary>
    /// 服务扩展类,<para></para>
    /// 包含各平台差异实现
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSharedExtensions(this IServiceCollection services)
    {
        var UploadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uploads");
        if (!Directory.Exists(UploadPath)) Directory.CreateDirectory(UploadPath);

        var cultureInfo = new CultureInfo("zh-CN");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        services.AddScoped<States>();
        services.AddScoped<DataService>();
//添加FreeSql服务

#if WINDOWS
var dbpath =  Path.Combine(ApplicationData.Current.LocalFolder.Path, "hybrid.db");  //"C: \\hybrid2.d";
#elif ANDROID || IOS || MACCATALYST
        string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "hybrid.db");
#else
        string dbpath = "hybrid.db";
#endif

       // var connstr = $"data source=1.2.3.4;port=3306;user id=root;password=root; initial catalog=hybrid;charset=utf8; sslmode=none;min pool size=1";
        // string connstr = $"server=127.0.0.1;port=3306;user id=root;password=root; database=hybrid;charset=utf8; SslMode=None;min pool size=1";

        //System.Diagnostics.Debug.WriteLine("=============》数据库地址：" + dbpath);

        services.AddFreeSql(option =>
        {
            option
                 //#if DEBUG
                 .UseConnectionString(FreeSql.DataType.Sqlite, $"Data Source=C:\\sql3\\test.db;")
                 .UseAutoSyncStructure(true)
                 //调试sql语句输出
                 .UseMonitorCommand(cmd => System.Console.WriteLine(cmd.CommandText + Environment.NewLine))
                 //#else
                 //.UseConnectionString(FreeSql.DataType.MySql, connstr, typeof(FreeSql.MySql.MySqlProvider<>))
                 //#endif
                 .UseNoneCommandParameter(true)
                 .UseMonitorCommand(cmd =>  System.Diagnostics.Debug.WriteLine("=============》sql：" + cmd.CommandText) ); //调试sql语句输出
          
        }, configEntityPropertyImage: true);

        //全功能版
        services.AddScoped(typeof(FreeSqlDataService<>));
        services.AddDensenExtensions();
        services.ConfigureJsonLocalizationOptions(op =>
        {
            // 忽略文化信息丢失日志
            op.IgnoreLocalizerMissing = true;

        });

        services.AddScoped<ILookupService, AppLookupService>();
        services.AddScoped<ICookie, CookieService>();
        services.AddScoped<IStorage, StorageService>();
        return services;
    }

}


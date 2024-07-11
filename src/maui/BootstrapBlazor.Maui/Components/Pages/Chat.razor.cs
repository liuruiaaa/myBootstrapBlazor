// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BootstrapBlazor.Maui.Data;
using BootstrapBlazor.Components;
using System.Text;
using BootstrapBlazor.Maui.Components.Layout;
using Microsoft.Extensions.Logging;

namespace BootstrapBlazor.Maui.Components.Pages;
public partial class Chat 
{

    //这个Inject 是在依赖注入
    [Inject, NotNull] internal MenuService? MenuService { get; set; }

    [NotNull] private ConsoleLogger? NormalLogger { get; set; }


    async private void ButtonClickC(MouseEventArgs e)
    {
        try
        {

            using (HttpClient client = new HttpClient())
            {
                // 设定要GET的URL。
                string url = "http://127.0.0.1:8885/shangpiao/testset/test";
          
                // 发起GET请求。
                HttpResponseMessage response = await client.PostAsync(url, null);

                // 检查响应是否成功，并获取响应内容。
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // 处理响应内容，比如将其解析为JSON对象、显示在UI上等。
                    System.Diagnostics.Debug.WriteLine("=============》button："+ responseContent);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("=============》button：请求失败！");
                }
            }
        }
        catch (HttpRequestException httpRequestException)
        {
            // 捕捉到的是与请求相关的异常
            System.Diagnostics.Debug.WriteLine($"=============》请求异常: {httpRequestException.Message}");
        }
        catch (Exception ex)
        {
            // 捕捉其他所有的异常
            System.Diagnostics.Debug.WriteLine($"=============》发生异常: {ex.Message}");
        }
        finally
        {
            // 不论成功还是失败，都会执行的代码块
            // 比如，你可以在这里关闭HttpClient连接，尽管它在using语句中已被自动处理
            System.Diagnostics.Debug.WriteLine("=============》请求完成");
        }
    }




    /*    private string messageInput;
        private List<string> messages = new List<string>();

        private void ButtonClick(MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageInput))
            {
                messages.Add(messageInput);
                messageInput = string.Empty; // 清空输入
                StateHasChanged(); // 更新UI
            }

            NormalLogger.Log($"Button Clicked: {messageInput}");
            System.Diagnostics.Debug.WriteLine("=============》button：");
        }*/


    /// <summary>
    ///
    /// </summary>
    /// <param name="e"></param>
    /*   private void ButtonClick(MouseEventArgs e)
       {
           NormalLogger.Log($"Button Clicked");
           System.Diagnostics.Debug.WriteLine("=============》button：");
       }*/


    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private AttributeItem[] GetAttributes() =>
    [
        new()
        {
            Name = "ChildContent",
            Description = "子组件",
            Type = "RenderFragment",
            ValueList = " — ",
            DefaultValue = " — "
        },
        new()
        {
            Name = "Height",
            Description = "组件高度",
            Type = "string",
            ValueList = " — ",
            DefaultValue = " — "
        }
    ];
}

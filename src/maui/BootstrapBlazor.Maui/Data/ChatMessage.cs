// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor.Maui.Data;
internal class ChatMessage
{
    public string Text { get; set; }
    public string Position { get; set; } // "left" 或 "right"
    public static int counter { get; set; } //计算到多少了
    public string AudioUrl { get; set; } //语音



    public static List<ChatMessage> GenerateMessagesInRange(int start, int end)
    {
        
        var items = new List<ChatMessage>();
        if (start == 0)
        {
            for (int i = start; i < end; i++)
            {
                counter++;
                items.Add(new ChatMessage { Text = $"消息 {i + 1} 第几次 {counter}", Position = i % 2 == 0 ? "left" : "right" });
                System.Diagnostics.Debug.WriteLine($"消息 {i + 1} 第几次 {counter}");
            }
        }
        return items;
    }
}

// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System.Text;
using System.Net.WebSockets;
using Newtonsoft.Json;

namespace BootstrapBlazor.Maui.Utills;

public partial class WebSocket
{
    private static readonly Uri uri = new Uri("ws://127.0.0.1:8889/webSocket"); // 替换成你的 WebSocket 地址
    private static ClientWebSocket clientWebSocket; 

    //Send() 方法用于从控制台读取输入并发送到 WebSocket 服务器。
    // 
    public static async Task Send(String messages)
    {
        
        try
        {
            // 构造 JSON 消息
            var jsonMessage = new
            {
                uid = "111",
                touid = "222",
                message = messages
            };
            string jsonString = JsonConvert.SerializeObject(jsonMessage); // Install - Package Newtonsoft.Json  加了这个库的在程序包管理那里
            if (clientWebSocket == null || clientWebSocket.State != WebSocketState.Open) {
                clientWebSocket = new ClientWebSocket();
                clientWebSocket.ConnectAsync(uri, new CancellationToken()).Wait();
            }
            ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(jsonString)); // 将消息转换为 UTF-8 编码的字节数组
            await clientWebSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, new CancellationToken()); // 异步发送消息到 WebSocket 服务器
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Send failed: {ex.Message}"); // 处理发送消息时可能抛出的异常
            System.Diagnostics.Debug.WriteLine($"Send failed: {ex.Message}");
        }
    }

    //Receive() 方法用于接收来自 WebSocket 服务器的消息并在控制台上显示。
    public static async Task Receive()
    {
        try
        {
            byte[] receiveBuffer = new byte[1024];
            while (clientWebSocket == null || clientWebSocket.State == WebSocketState.Open)
            {
                var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), new CancellationToken());
                string message = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count).TrimEnd('\0');
               // Console.WriteLine($"收到消息：{message}");
                System.Diagnostics.Debug.WriteLine($"收到消息：{message}");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"接收消息失败：{ex.Message}");
            Console.WriteLine($"接收消息失败：{ex.Message}");
        }
    }

}

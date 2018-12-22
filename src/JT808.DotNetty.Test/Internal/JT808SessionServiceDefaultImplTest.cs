﻿using JT808.DotNetty.Internal;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using JT808.Protocol;
using JT808.Protocol.Extensions;
using System.Threading;
using Xunit;
using JT808.DotNetty.Interfaces;

namespace JT808.DotNetty.Test.Internal
{
    public class JT808SessionServiceDefaultImplTest : TestBase
    {
        static IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6565);

        [Fact]
        public void Test1()
        {
            IJT808SessionService jT808SessionServiceDefaultImpl = ServiceProvider.GetService<IJT808SessionService>();
            JT808SimpleTcpClient SimpleTcpClient1 = new JT808SimpleTcpClient(endPoint);
            JT808SimpleTcpClient SimpleTcpClient2 = new JT808SimpleTcpClient(endPoint);
            JT808SimpleTcpClient SimpleTcpClient3 = new JT808SimpleTcpClient(endPoint);
            JT808SimpleTcpClient SimpleTcpClient4 = new JT808SimpleTcpClient(endPoint);
            JT808SimpleTcpClient SimpleTcpClient5 = new JT808SimpleTcpClient(endPoint);
            // 心跳会话包
            JT808Package jT808Package1 = JT808.Protocol.Enums.JT808MsgId.终端心跳.Create("123456789001");
            SimpleTcpClient1.WriteAsync(JT808Serializer.Serialize(jT808Package1));

            // 心跳会话包
            JT808Package jT808Package2 = JT808.Protocol.Enums.JT808MsgId.终端心跳.Create("123456789002");
            SimpleTcpClient2.WriteAsync(JT808Serializer.Serialize(jT808Package2));

            // 心跳会话包
            JT808Package jT808Package3 = JT808.Protocol.Enums.JT808MsgId.终端心跳.Create("123456789003");
            SimpleTcpClient3.WriteAsync(JT808Serializer.Serialize(jT808Package3));

            // 心跳会话包
            JT808Package jT808Package4 = JT808.Protocol.Enums.JT808MsgId.终端心跳.Create("123456789004");
            SimpleTcpClient4.WriteAsync(JT808Serializer.Serialize(jT808Package4));

            // 心跳会话包
            JT808Package jT808Package5 = JT808.Protocol.Enums.JT808MsgId.终端心跳.Create("123456789005");
            SimpleTcpClient5.WriteAsync(JT808Serializer.Serialize(jT808Package5));
            Thread.Sleep(1000);
            var result = jT808SessionServiceDefaultImpl.GetAll();

            var result1 = jT808SessionServiceDefaultImpl.GetAll();

            Thread.Sleep(10000);

            SimpleTcpClient1.Down();
            SimpleTcpClient2.Down();
            SimpleTcpClient3.Down();
            SimpleTcpClient4.Down();
            SimpleTcpClient5.Down();
        }
    }
}

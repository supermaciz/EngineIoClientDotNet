﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quobject.EngineIoClientDotNet.Thread;
using Xunit;

namespace Quobject.EngineIoClientDotNet_Tests.ThreadTests
{
    public class EventTasksTests
    {
        [Fact]
        public void Test()
        {
            int result = 0;
            EventTasks.Exec(n => { int i = 0;
                                     i = i + 1;
                                     Console.WriteLine("in test A " + Thread.CurrentThread.ManagedThreadId);
                                     result = i;
                                     Console.WriteLine("in test B " + Thread.CurrentThread.ManagedThreadId);

                                     return;
            });

            Console.WriteLine("in test C " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("after exec result = " + result);

            EventTasks.Exec(n =>
            {
                int i = 0;
                i = i + 1;
                Console.WriteLine("in test A2 " + Thread.CurrentThread.ManagedThreadId);
                result = i;
                Console.WriteLine("in test B2 " + Thread.CurrentThread.ManagedThreadId);

                return;
            });

            Console.WriteLine("in test C " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("after exec result = " + result);

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.Equal(1,result);
            Console.WriteLine("after exec after delay result = " + result);
        }
    }
}

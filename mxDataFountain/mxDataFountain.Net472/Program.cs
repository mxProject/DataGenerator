using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagePipe;
using Microsoft.Extensions.DependencyInjection;

using mxProject.Tools.DataFountain.Forms;
using mxProject.Tools.DataFountain.Messaging;

namespace mxProject.Tools.DataFountain
{
    static class Program
    {

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection services = CreateMessagePipeServices();
            ServiceProvider provider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var context = new DataFountainContext(provider);

            Application.Run(new DataGeneratorEditorForm(context));
        }

        /// <summary>
        /// MessagePipe を使用するためのサービスを生成します。
        /// </summary>
        /// <returns></returns>
        static ServiceCollection CreateMessagePipeServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddMessagePipe(options =>
            {
                options.AddGlobalMessageHandlerFilter(typeof(MessageFilter<>));
            }
            );

            services.AddSingleton(typeof(MessagePipe.IPublisher<,>), typeof(MessageBroker<,>));
            services.AddSingleton(typeof(MessagePipe.ISubscriber<,>), typeof(MessageBroker<,>));

            return services;
        }

    }
}

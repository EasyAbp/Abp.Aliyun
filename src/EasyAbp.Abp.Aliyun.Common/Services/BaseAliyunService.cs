using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.Aliyun.Common.Services
{
    public abstract class BaseAliyunService : ISingletonDependency
    {
        public IServiceProvider ServiceProvider { get; set; }
        protected readonly object ServiceProviderLock = new object();

        protected TService LazyGetRequiredService<TService>(ref TService serviceRef)
        {
            if (serviceRef == null)
            {
                lock (ServiceProviderLock)
                {
                    if (serviceRef == null)
                    {
                        serviceRef = ServiceProvider.GetRequiredService<TService>();
                    }
                }
            }

            return serviceRef;
        }


        private IAliyunApiRequester _aliyunApiRequester;
        protected IAliyunApiRequester AliyunApiRequester => LazyGetRequiredService(ref _aliyunApiRequester);
    }
}
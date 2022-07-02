using System;

namespace PTC.Application.Services
{
    public abstract class BaseService
    {
        protected readonly IServiceProvider _serviceProvider;
        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}

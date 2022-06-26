using System;

namespace PTC.Application.Services
{
    public class Base
    {
        protected readonly IServiceProvider _serviceProvider;

        public Base(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}

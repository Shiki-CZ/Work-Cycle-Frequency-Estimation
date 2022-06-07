using Microsoft.Extensions.DependencyInjection;
using Prediction.ViewModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prediction.Views.Abstraction
{
    public class IocControl : UserControl
    {

        private static IServiceProvider _serviceProvider;

        public static void ConfigureServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UseViewModel<TViewModel>()
        where TViewModel : class, IViewModel
        {
#if DEBUG
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
#endif
            var dataContext = _serviceProvider.GetRequiredService<TViewModel>();
            DataContext = dataContext;
        }
    }
}

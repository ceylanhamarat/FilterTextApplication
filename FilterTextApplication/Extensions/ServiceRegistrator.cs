using FilterText.Enums;
using FilterText.Interfaces;
using FilterText.Services;
using FilterTextApplication.Helpers;
using FilterTextApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterTextApplication.Extensions
{
    public static class ServiceRegistrator
    {
        public static ServiceProvider RegisterServices(this ServiceCollection services)
        { 
            services.AddTransient<IFileReaderHelper, FileReaderHelper>();
            services.AddTransient<ITextHelper, TextHelper>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.AddTransient<IProcessorHelper, ProcessorHelper>();

            services.AddTransient<VowelFilter>(s => new VowelFilter(VowelFilterType.MiddleLetterIsNotVowel));
            services.AddTransient<LetterFilter>(s => new LetterFilter(LetterFilterType.NotContainsLetter, 't'));
            services.AddTransient<LengthFilter>(s => new LengthFilter(LengthFilterType.GreaterThanOrEqual, 3));

            services.AddTransient<IFilterService, FilterService>(); 
            

            return services.BuildServiceProvider();
        }
    }
}

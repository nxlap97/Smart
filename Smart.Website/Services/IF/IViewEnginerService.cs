using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Website.Services
{
    public interface IViewEnginerService
    {
        Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model);
    }
}

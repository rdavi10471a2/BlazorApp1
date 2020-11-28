using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorApp1.Data
{
    public interface IStoredPage<T> 
    {   
        T PageState { get; set; }
        DateTime LoadDateTime { get; set; }
    }
    public class PageStorageService<T> : IStoredPage<T>
    {
        public T PageState { get; set; }
        public DateTime LoadDateTime { get; set; } = DateTime.Now;
    }


}

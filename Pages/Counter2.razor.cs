using BlazorApp1.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Pages
{
    public  partial class Counter2 : ComponentBase,IDisposable
    {

        [Inject]
        private PageStorageService<Counter2> StorageService { get; set; }


        private int PageStateNullCount { get; set; } = 0;

        private List<string> TestDataSave { get; set; }

        private int currentCount { get; set; }

        private void IncrementCount()
        {
            TestDataSave.Add("<div>count before Inc : " + currentCount.ToString() + "</div>");
            currentCount++;
            TestDataSave.Add("<div>count after Inc :" + currentCount.ToString() + "<div>");

        }

        protected override Task OnInitializedAsync()
        {
            // reset what we want from stored copy
            if (StorageService.PageState != null)
            {
                currentCount = StorageService.PageState.currentCount;
                TestDataSave = StorageService.PageState.TestDataSave;
                PageStateNullCount = StorageService.PageState.PageStateNullCount;

                TimeSpan ts = DateTime.Now - @StorageService.LoadDateTime;
                if (ts.TotalSeconds > 10)
                {
                    TestDataSave = new List<string>();
                    TestDataSave.Add("<div>data reset on Timeout</div>");
                    StorageService.LoadDateTime = DateTime.Now;  //reset time
                }
            }
            else
            {

                PageStateNullCount++; // used in testing to make sure that we only ever hit this code once 
                //create for the first time aka read from database
                TestDataSave = new List<string>();
                TestDataSave.Add("<div>OnParametersSetAsync</div>");
            }


            //reconnect
            StorageService.PageState = this;

            return base.OnInitializedAsync();
        }

        public void Dispose()
        {
            
        }
    }

    
}

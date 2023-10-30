using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace EvilCompanies.Pages
{
    public partial class Companies
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected EvilCompanies.EvilApiService EvilApiService { get; set; }

        protected IEnumerable<EvilCompanies.Models.EvilApi.GetAll> getAlls;

        protected override async Task OnInitializedAsync()
        {
            getAlls = await EvilApiService.GetAll();
        }

        protected async System.Threading.Tasks.Task DataGrid0RowClick(Radzen.DataGridRowMouseEventArgs<EvilCompanies.Models.EvilApi.GetAll> args)
        {
            await DialogService.OpenAsync<Edit>("Edit", new Dictionary<string, object>{ {"id", args.Data.Id } } );
        }
    }
}
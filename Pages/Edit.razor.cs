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
    public partial class Edit
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

        protected EvilCompanies.Models.EvilApi.GetAll getAll = new EvilCompanies.Models.EvilApi.GetAll();

        [ParameterAttribute]
        public int id {get; set; }

        protected override async Task OnInitializedAsync()
        {
            getAll = await EvilApiService.Get(id);
        }

    }
}
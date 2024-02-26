using ForumMetier.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Data;
using UiPath.CodedWorkflows;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Excel;
using UiPath.Excel.Activities;
using UiPath.Excel.Activities.API;
using UiPath.Excel.Activities.API.Models;
using UiPath.Mail.Activities.Api;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;
using System.Threading.Tasks;
using UiPath.Activities.Contracts;

namespace ForumMetier
{
    public class WorkflowRunnerService
    {
        private readonly Func<string, IDictionary<string, object>, TimeSpan?, bool, InvokeTargetSession, IDictionary<string, object>> _runWorkflowHandler;
        public WorkflowRunnerService(Func<string, IDictionary<string, object>, TimeSpan?, bool, InvokeTargetSession, IDictionary<string, object>> runWorkflowHandler)
        {
            _runWorkflowHandler = runWorkflowHandler;
        }

        /// <summary>
        /// Invokes the twitch-computeFollowers.cs
        /// </summary>
        public void twitch_computeFollowers()
        {
            var result = _runWorkflowHandler(@"twitch-computeFollowers.cs", new Dictionary<string, object>{}, default, default, default);
        }

        /// <summary>
        /// Invokes the twitch.xaml
        /// </summary>
        public int twitch(string in_influencerName)
        {
            var result = _runWorkflowHandler(@"twitch.xaml", new Dictionary<string, object>{{"in_influencerName", in_influencerName}}, default, default, default);
            return (int)result["out_nbFollowers"];
        }

        /// <summary>
        /// Invokes the Main.xaml
        /// </summary>
        public void Main()
        {
            var result = _runWorkflowHandler(@"Main.xaml", new Dictionary<string, object>{}, default, default, default);
        }
    }
}
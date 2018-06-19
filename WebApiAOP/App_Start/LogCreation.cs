using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Extension;
using WebApiAOP.Helper;

namespace WebApiAOP.App_Start
{
    public class LogCreation : UnityContainerExtension
    {      
        protected override void Initialize()
        {
            Logger.Setup();
         }
    }
}
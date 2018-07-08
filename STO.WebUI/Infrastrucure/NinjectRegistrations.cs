namespace STO.WebUI.Infrastrucure
{
    using Ninject;
    using Ninject.Modules;
    using STO.Domain.DAL;
    using STO.Domain.Interfaces;
    using STO.Domain.Repositories;
    using System;
    using System.Collections.Generic;

    public class NinjectRegistrations : NinjectModule
    {        
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();            
        }
    }
}
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Syntax;
using Ninject;

namespace STO.WebUI.Infrastrucure
{
    public static class NinjectResolver
    {
        public static NinjectDependencyResolver Resolve() {

            return new NinjectDependencyResolver(new StandardKernel(new NinjectRegistrations()));
        } 
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Decopack.IoC.DependencyResolution {
    using Decopack.Framework.Logging;
    using Decopack.Services;
    using Decopack.Services.Contracts;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<ILoggingService>().Use<LoggingService>();
            For<IBitacoraService>().Use<BitacoraService>();
            For<IProductoService>().Use<ProductoService>();
            For<IUsuarioService>().Use<UsuarioServicio>();
            For<ICompradorService>().Use<CompradorService>();
            For<IPedidoService>().Use<PedidoService>();
            For<IMateriaPrimaService>().Use<MateriaPrimaService>();
            For<IDepositoService>().Use<DepositoService>();
            For<IEmpleadoService>().Use<EmpleadoService>();
            For<IEnvioService>().Use<EnvioService>();
            For<IMateriaPrimaProductoService>().Use<MateriaPrimaProductoService>();
            For<IMateriaPrimaProveedorService>().Use<MateriaPrimaProveedorService>();
            For<IReposicionService>().Use<ReposicionService>();
            For<IStockMateriaPrimaDepositoService>().Use<StockMateriaPrimaDepositoService>();
            For<IStockProductoDepositoService>().Use<StockProductoDepositoService>();
            For<IVentaService>().Use<VentaService>();
            For<IProveedorService>().Use<ProveedorService>();
            For<IProductoCCService>().Use<ProductoCCService>();
            For<IProductoDVVService>().Use<ProductoDVVService>();
            For<IPermisoService>().Use<PermisoService>();
            For<IUsuarioPermisoService>().Use<PermisoUsuarioService>();


        }

        #endregion
    }
}
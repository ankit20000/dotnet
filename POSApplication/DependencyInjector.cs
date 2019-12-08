using DataAccessLayer;
using PosApplication.Interfaces;
using POSApplication.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace POSApplication
{
    public static class DependencyInjector
    {
        private static readonly UnityContainer unityContainer = new UnityContainer();
        public static IUnityContainer Register()
        {
            unityContainer.RegisterType<FrmRefuellerToRefueller>();
            unityContainer.RegisterType<ILogin, LoginConcrete>();
            unityContainer.RegisterType<IConfiguration, ConfigurationConcrete>();
            unityContainer.RegisterType<IDailyAvailableFlights, DailyAvailableFlightsConcrete>();
            unityContainer.RegisterType<IFuelTransaction, FuelTransactionConcrete>();
            unityContainer.RegisterType<IScheduledFlightsSelf, ScheduledFlightSelfConcrete>();
            unityContainer.RegisterType<IScheduledFlightOther, ScheduledFlightOtherConcrete>();
            unityContainer.RegisterType<IFlowMeterCommunication, FlowMeterCommunicationConcrete>();
            unityContainer.RegisterType<IImportData, ImportData>();
            unityContainer.RegisterType<ICirculationTest, CirculationTestConcrete>();
            unityContainer.RegisterType<IExportData, ExportData>();
            unityContainer.RegisterType<IFuelEntryParameter, FuelEntryParameterConcrete>();
            unityContainer.RegisterType<IStockTransfer, StockTransferConcrete>();
            unityContainer.RegisterType<IPrintReceipt, PrintReceiptConcrete>();
            return unityContainer;
        }
    }
}

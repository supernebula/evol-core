using Evol.InfluxDB.Tests.Model;
using Evol.SimpleDapper;

namespace Evol.InfluxDB.Tests.Repository
{

    public class CarBatteryRepository : BaseDapperSimpleRepository<CxdbDbContext, CarBattery>
    {
    }
}

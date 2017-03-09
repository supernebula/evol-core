using System.Diagnostics;
using Xunit;
using XrmBigDataFreqStatisticsServiceReference;
using StandardService;

namespace WebService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var client = new XrmBigDataFreqStatisticsPortTypeClient();

            var input = "<query type=\"get\"><business businesscode=\"RMICS_STATION\" opttype=\"4\"><parameter name=\"MFID\" /><parameter name=\"FMSKIND\" value=\"11~21~13~14~15\" /><parameter name=\"STATIONTYPE\" value=\"G\" /></business></query>";

            try
            {
                var resposne = client.RscSmsQueryMStationInfoAsync(input).GetAwaiter().GetResult();
                Trace.WriteLine(resposne);
            }
            catch (System.Exception ex)
            {

                throw;
            }


        }

        [Fact]
        public void Test2()
        {
            var client = new StandardServiceSoapClient();

            var input = "<query type=\"get\"> < mfid val = \"33010008110001\" /> < equid val = \"2SAEBF83A46F878E2389AEB879CAE5F893EC\" /> < executetime val = \"0\" /> < detector val = \"fast\" />  < rfmode val = \"none\" />  < gain val = \"agc\" />  < mgcvalue val = \"0\" /> < rfattenuation val = \"off\" /> < rfattvalue val = \"0\" /> < frequency val = \"97100000\" />  < dfbw val = \"100000\" /> < demodmode val = \"FM\" /> < demodbw val = \"25000\" />  < resulttype >  < SFDF /> < audio /> </ resulttype >  < span val = \"100000\" /> < integrationtime val = \"500ms\" /> < dfampthreshold val = \"0dBuV\" /> < dfqualitythreshold val = \"5%\" /> < dfmode val = \"normal\" /> </ query > ";

            var resposne = client.S_SglFreqDFAsync(input).GetAwaiter().GetResult();
            Trace.WriteLine(resposne);
            
        }
    }
}

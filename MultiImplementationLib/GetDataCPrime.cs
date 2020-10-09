namespace MultiImplementationLib
{
    public class GetDataCPrime : IGetDataC
    {
        public Keys Tag => Keys.C;
        public string GetData()
        {
            return "GetDataC";


        }
    }
}

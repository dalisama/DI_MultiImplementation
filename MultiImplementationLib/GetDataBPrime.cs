namespace MultiImplementationLib
{
    public class GetDataBPrime : IGetDataB
    {
        public Keys Tag => Keys.B;
        public string GetData()
        {
            return "GetDataB";


        }
    }
}

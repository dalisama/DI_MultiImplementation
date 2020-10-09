namespace MultiImplementationLib
{
    public class GetDataA : IGetData
    {
        public Keys Tag => Keys.A;

        public string GetData()
        {
            return "GetDataA";
        }
    }
}

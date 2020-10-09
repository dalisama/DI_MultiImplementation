namespace MultiImplementationLib
{
    public class GetDataB : IGetData
    {
        public Keys Tag => Keys.B;
        public string GetData()
        {
            return "GetDataB";


        }
    }
}

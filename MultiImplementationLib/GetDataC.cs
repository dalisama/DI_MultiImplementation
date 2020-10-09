namespace MultiImplementationLib
{
    public class GetDataC : IGetData
    {
        public Keys Tag => Keys.C;
        public string GetData()
        {
            return "GetDataC";


        }
    }
}

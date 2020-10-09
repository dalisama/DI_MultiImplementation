namespace MultiImplementationLib
{
    public class GetDataAPrime : IGetDataA
    {
        public Keys Tag => Keys.A;

        public string GetData()
        {
            return "GetDataA";
        }
    }
}

namespace bookingticketAPI.Filter
{
    internal class ApiResponse
    {
        private object unauthorized;

        public ApiResponse(object unauthorized)
        {
            this.unauthorized = unauthorized;
        }
    }
}
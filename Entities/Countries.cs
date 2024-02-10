namespace Entities
{
    public class Countries
    {
        /// <summary>
        /// Domain Model for storing Country Data
        /// </summary>
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        //We do not  show Domain Model to  Controller  not in argument not in return
        //we will  use DTO for Request and Response   
        //between   Request && Respone DTO  we will map  that values to  domain Model
    }
}
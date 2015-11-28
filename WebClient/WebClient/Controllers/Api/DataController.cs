using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebClient.ViewModel;

namespace WebClient.Controllers.Api
{
     [RoutePrefix("api/data")]
    public class DataController : BaseApiController
    {
         [Route("GetAllData")]
         public List<OrderViewModel> GetAllData()
         {
             OrderManager mng = new OrderManager();
             return Converter.ToViewModel(mng.GetOrders());
         }

         [HttpPost]
         [Route("GetFilteredData")]
         public List<OrderViewModel> GetFilteredData(OrderViewModel Order)
         {
             OrderManager mng = new OrderManager();
             return Converter.ToViewModel(mng.GetFilteredData(Order.Name,Order.Price));
         }

         [Route("AddOrder")]
         public DataResult AddOrder(OrderViewModel Order)
         {
             try
             {
                 OrderManager mng = new OrderManager();
                 mng.AddOrder(Converter.ToModel(Order));
                 return new DataResult() { Sucess = true };
             }
             catch(Exception ex)
             {
                 List<string> messages = new List<string>();
                 messages.Add(ex.Message);
                 return new DataResult() { Sucess = false , Messages=messages };
             }
             
         }


         [Route("UpdateOrder")]
         public DataResult UpdateOrder(OrderViewModel Order)
         {
             try
             {
                 OrderManager mng = new OrderManager();
                 mng.UpdateOrder(Converter.ToModel(Order));
                 return new DataResult() { Sucess = true };
             }
             catch(Exception ex)
             {
                 List<string> messages = new List<string>();
                 messages.Add(ex.Message);
                 return new DataResult() { Sucess = false , Messages=messages };
             }
             
         }
         
         [HttpPost]
         [Route("DeleteOrder/{OrderID}")]
         public DataResult DeleteOrder(int OrderID)
         {
             try
             {
                 OrderManager mng = new OrderManager();
                 mng.DeleteOrder(OrderID);
                 return new DataResult() { Sucess = true };
             }
             catch (Exception ex)
             {
                 List<string> messages = new List<string>();
                 messages.Add(ex.Message);
                 return new DataResult() { Sucess = false, Messages = messages };
             }
            
         }

    }
}

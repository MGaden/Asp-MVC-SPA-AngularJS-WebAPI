using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.ViewModel;

namespace WebClient
{
    public class Converter
    {
        public static Order ToModel(OrderViewModel VM)
        {
            return new Order() { ID = VM.ID, Price = VM.Price, Name = VM.Name };
        }

        public static OrderViewModel ToViewModel(Order Model)
        {
            return new OrderViewModel() { ID = Model.ID, Price = Model.Price, Name = Model.Name };
        }

        public static List<OrderViewModel> ToViewModel(ICollection<Order> Models)
        {
            List<OrderViewModel> list = new List<OrderViewModel>();
            if(Models != null)
            {
                foreach (Order Model in Models)
                {
                    list.Add(ToViewModel(Model));
                }
                return list;
            }
            else
            {
                return null;
            }
            
        }

        public static LanguageViewModel ToViewModel(Language Model)
        {
            return new LanguageViewModel() { ID = Model.ID, CultureName = Model.CultureName, Name = Model.Name ,EngName=Model.EngName };
        }

        public static List<LanguageViewModel> ToViewModel(ICollection<Language> Models)
        {
            List<LanguageViewModel> list = new List<LanguageViewModel>();
            if (Models != null)
            {
                foreach (Language Model in Models)
                {
                    list.Add(ToViewModel(Model));
                }
                return list;
            }
            else
            {
                return null;
            }

        }

    }
}